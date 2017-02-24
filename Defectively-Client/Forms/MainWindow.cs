using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using Defectively;
using Defectively.Extension;
using DefectivelyClient.Management;
using Newtonsoft.Json;

namespace DefectivelyClient.Forms
{
    public partial class MainWindow : Form, IClient
    {
        private readonly RSACryptoServiceProvider ServiceProvider = new RSACryptoServiceProvider(4096);

        private const string PublicKey = "<RSAKeyValue><Modulus>n1G5qxqPSnvu3A0ympXV/qHCeMasaXOqrmlIF/2sAMgrjYmCXcAeyplvirGPDOUPHHUIBmZzqbtmU5Ol2l9VpMEesuDneEZh8nB9dpvtNe+LpoDAX4qVvrf78SXDzT9biFwJj8AAUgYI1JA2lN/+rHYCOYTlfrn1cln3q2F1sbtOKfJyYdt5PsbALI2In3b134k4XP93W5fLqNSFHbG3LcWTLkU06/cobg8etttjyyg5svUAEN+LnhtfrGilLW67oi4vHnjzhggEy7zo2RGfs2PJ8CnwlmAOGGtN/DaPTjobeHZRrIsIWy9/SPpSozaUV/mNxkrvYFEgE0BP6KCgS7HVXcJbsOcNIKIdUhRgRkXKT5XF7wakw9SjD3BCNZRIbfruBbN/dUx0jHgdU1zLJ1gVQcE0P/Fyrubq6VcKSTLrhygz2CkRSqUmE9MVmbISmDv13cI/lg/sTbEEpxWF+6lZdxmts5GVxjvTLbbv0CglRu8SyYGycWtHkSYsVEKYwBV5DRXfEWN8/uJcgrWxYNKH8+1nld/RSKVQ2lYKK2b0cJF4OHuhNGubNDDUn99LZviQmNQAzaK4hTFtRGaTVhcMOgl6KdEafQ6/oy9l9ynk+dw9HUJSq521ef1tFEvFYp3jNIjG8fcMikr5XuOoETaLFsdBNRPqMGQm7BuRzc8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        private readonly TcpClient FClient = new TcpClient();
        private Connection FConnection;
        private readonly Thread Listening;
        private delegate void DParseStreamContent(string content);

        private bool IsSupposedClosing;
        private List<Account> Accounts;
        private List<Rank> Ranks;
        private List<Channel> Channels;
        public static List<string> LuvaValues;

        public static string MyId;

        private int ExtensionCount;
        private string SessionPath;

        private ChannelControl ChannelControl;

        public enum AccountState
        {
            Offline,
            Online,
            Banned
        }
        private int YCoordinate;


        public MainWindow() {
            InitializeComponent();
            Closing += OnClosing;
            Listening = new Thread(Listen);
            tbxInput.KeyDown += OnTbxInputKeyDown;
            btnSend.Click += OnBtnSendClick;
            ChannelControl = new ChannelControl { Dock = DockStyle.Fill };
            pnlConversation.Controls.Add(ChannelControl);
            cbxSidebar.CheckedChanged += (sender, args) => pnlAccounts.Width = (cbxSidebar.Checked ? 300 : 0);
            btnChannels.Click += OnBtnChannelsClicked;
        }

        private void OnBtnChannelsClicked(object sender, EventArgs e) {
            var Window = new ChannelOverviewWindow();
            Window.Show();
            Window.SetChannels(Channels);
        }

        private void OnBtnSendClick(object sender, EventArgs e) {
            var Content = tbxInput.Text;
            if (!string.IsNullOrEmpty(Content) && !string.IsNullOrWhiteSpace(Content)) {
                FConnection.SetStreamContent(string.Join("|", Enumerations.Action.Plain, Content));
                tbxInput.Clear();
            }
        }

        private void OnTbxInputKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btnSend.PerformClick();
            }
        }

        private void OnClosing(object sender, CancelEventArgs e) {
            try {
                File.WriteAllText(SessionPath + "\\session.done", "");
                IsSupposedClosing = true;
                Listening.Abort();
                FConnection.Dispose();
                FClient.Dispose();
            } catch { }
            File.WriteAllText(SessionPath + "\\session.done", "");
            Application.Exit();
        }

        public void Connect(string address, int port, string accountId, string password) {
            try {
                FClient.Connect(address, port);
                FConnection = new Connection(FClient.GetStream());
                Listening.Start();
                ServiceProvider.FromXmlString(PublicKey);
                var SessionData = Cryptography.GenerateAesData();
                FConnection.AesData = SessionData;
                FConnection.HmacKey = Cryptography.GenerateHmacKey();
                FConnection.SetRawStreamContent(Cryptography.RSAEncrypt(string.Join("|", Convert.ToBase64String(SessionData.Key),Convert.ToBase64String(SessionData.IV),Convert.ToBase64String(FConnection.HmacKey)), ServiceProvider));
                FConnection.SetStreamContent(string.Join("|", accountId, Cryptography.ComputeHash(password)));

                // Clear Channel Control
                ChannelControl.Clear();

                // Add Handlers

                //Directory.EnumerateFiles(Path.Combine(Application.StartupPath, "Extensions")).ToList().ForEach(File.Delete);
                ExtensionPool.RegisterClient(this);

            } catch {
                var Result = MessageBox.Show("Defectively couldn't connect to the server. Make sure the entered address and port is correct and the server is up and running and that your account isn't connected already.", "Defectively", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (Result == DialogResult.Retry) {
                    Connect(address, port, accountId, password);
                } else {
                    Application.Restart();
                }
            }
        }

        private void Listen() {
            while (FClient.Connected) {
                try {
                    Invoke(new DParseStreamContent(ParseStreamContent), FConnection.GetStreamContent());
                } catch {
                    if (!IsSupposedClosing) {
                        MessageBox.Show("Defectively lost the connection to the server.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    File.WriteAllText(SessionPath + "\\session.done", "");
                    FConnection.Dispose();
                    FClient.Dispose();
                    Application.Exit();
                }
            }
        }

        private void ParseStreamContent(string content) {
            if (!string.IsNullOrEmpty(content) && !string.IsNullOrWhiteSpace(content)) {

                var Packet = content.Split('|');
                var Type = (Enumerations.Action) Enum.Parse(typeof(Enumerations.Action), Packet[0]);

                switch (Type) {
                case Enumerations.Action.SetState:
                    if (Packet[1] == Enumerations.ClientState.Banned.ToString()) {
                        var Punishment = JsonConvert.DeserializeObject<Punishment>(Packet[2]);
                        var Message = $"You're banned by {Punishment.CreatorId}. This ban lasts {(Punishment.Type == Enumerations.PunishmentType.Bann ? "permanently." : $"until\n{Punishment.EndDate.ToShortDateString()} {Punishment.EndDate.ToLongTimeString()}")}\nReason: {Punishment.Reason}";
                        MessageBox.Show(Message, "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    } else if (Packet[1] == Enumerations.ClientState.Muted.ToString()) {
                        var Punishment = JsonConvert.DeserializeObject<Punishment>(Packet[2]);
                        var Message = $"You're muted by {Punishment.CreatorId}. This mute lasts until:\n{Punishment.EndDate.ToShortDateString()} {Punishment.EndDate.ToLongTimeString()}\nReason: {Punishment.Reason}";
                        MessageBox.Show(Message, "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case Enumerations.Action.LoginResult:
                    if (Packet[1] == "hej") {
                        FConnection.SessionId = Packet[2];
                        MyId = Packet[3];
                        Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Sessions", $"{FConnection.SessionId}.session"));
                        SessionPath = Path.Combine(Application.StartupPath, "Sessions", $"{FConnection.SessionId}.session");
                        File.WriteAllText(SessionPath + "\\meta.json", JsonConvert.SerializeObject(Application.OpenForms.OfType<LoginDialogue>().ToList()[0].MetaData, Formatting.Indented));
                    } else if (Packet[1] == "authentificationFailed") {
                        MessageBox.Show("Authentification failed. The given password isn't correct.\nMake sure you entered the correct password and try again.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Restart();
                    } else {
                        MessageBox.Show("Authentification failed. The given account-id does not exist.\nMake sure you entered the correct id and try again.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Restart();
                    }
                    break;
                case Enumerations.Action.ExtensionTransport:
                    GC.Collect();
                    var Bytes = JsonConvert.DeserializeObject<byte[]>(Packet[1]);
                    if (!Directory.Exists(Path.Combine(SessionPath, "Extensions")))
                        Directory.CreateDirectory(Path.Combine(SessionPath, "Extensions"));
                    File.WriteAllBytes(Path.Combine(SessionPath, $"Extensions\\Extension{ExtensionCount}.dll"), Bytes);
                    ExtensionManager.LoadExtension(Path.Combine(SessionPath, $"Extensions\\Extension{ExtensionCount}.dll"));
                    ExtensionCount++;
                    break;
                case Enumerations.Action.Extension:
                    ListenerManager.InvokeSpecialEvent(JsonConvert.DeserializeObject<EventArguments>(Packet[1]));
                    break;
                case Enumerations.Action.Plain:
                    Invoke(new Action(() => ChannelControl.AddMessage(JsonConvert.DeserializeObject<MessagePacket>(Packet[1]))));
                    break;
                case Enumerations.Action.ClearConversation:
                    Invoke(new Action(() => ChannelControl.Clear()));
                    break;
                case Enumerations.Action.SetRankList:
                    Ranks = JsonConvert.DeserializeObject<List<Rank>>(Packet[1]);
                    break;
                case Enumerations.Action.SetAccountList:
                    Accounts = JsonConvert.DeserializeObject<List<Account>>(Packet[1]);
                    DisplayAccounts();
                    break;
                case Enumerations.Action.SetChannelList:
                    Channels = JsonConvert.DeserializeObject<List<Channel>>(Packet[1]);
                    DisplayAccounts();
                    // Refresh Channels
                    break;
                case Enumerations.Action.SetLuvaValues:
                    LuvaValues = JsonConvert.DeserializeObject<List<string>>(Packet[1]);
                    SetControlAccessability();
                    break;
                case Enumerations.Action.SetChannel:
                    var Channel = JsonConvert.DeserializeObject<Channel>(Packet[1]);
                    Invoke(new Action(() => ChannelControl.Clear()));
                    Invoke(new Action(() => ChannelControl.AddMessage(new MessagePacket {
                        Content = $"You've entered \"{Channel.Name}\". (#{Channel.Id})",
                        Time = DateTime.Now.ToShortTimeString(),
                        Type = Enumerations.MessageType.Center
                    })));

                    break;
                case Enumerations.Action.SetAccountData:
                    GC.Collect();
                    var Window = new ProfileWindow();
                    if (!Directory.Exists(Path.Combine(SessionPath, "Storage")))
                        Directory.CreateDirectory(Path.Combine(SessionPath, "Storage"));
                    var AvatarPath = Path.Combine(SessionPath, "Storage\\Avatar.png");
                    File.WriteAllBytes(AvatarPath, JsonConvert.DeserializeObject<byte[]>(Packet[1]));
                    var HeaderPath = Path.Combine(SessionPath, "Storage\\Header.png");
                    File.WriteAllBytes(HeaderPath, JsonConvert.DeserializeObject<byte[]>(Packet[2]));
                    Window.ShowDialog(Image.FromFile(AvatarPath), Image.FromFile(HeaderPath), bool.Parse(Packet[3]), Packet[4], bool.Parse(Packet[5]), Packet[6], Packet[7], Packet[8]);
                    break;
                case Enumerations.Action.ShowLuvaNotice:
                    var Severity = JsonConvert.DeserializeObject<Severity>(Packet[2]);
                    var LDialog = new LuvaDialog {
                        LuvaValue = Packet[1],
                        Severity = Severity
                    };
                    LDialog.ShowDialog();
                    break;
                case Enumerations.Action.ChannelJoinResult:

                    switch (Packet[1]) {
                    case "redundant":
                        MessageBox.Show("You're already in this channel.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "unknown":
                        MessageBox.Show("This channel does no longer exist.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "full":
                        MessageBox.Show("This channel is full.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "authFailed":
                        MessageBox.Show("The password you've entered is incorrect.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "authRequired":
                        MessageBox.Show("This channel requires a password to enter.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case "ranked":
                        MessageBox.Show("This channel is only open to members of a specific rank.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    break;
                case Enumerations.Action.Disconnect:
                    File.WriteAllText(SessionPath + "\\session.done", "");
                    MessageBox.Show($"The connection was closed by the server.\n\n{Packet[1]}", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FConnection.Dispose();
                    FClient.Dispose();
                    Application.Exit();
                    break;
                }
            }
        }

        private void DisplayAccounts() {
            try {
                pnlAccounts.Controls.Clear();
                YCoordinate = 0;
                foreach (var Rank in Ranks) {
                    var Header = GetHeaderPanel(Rank.Name, ColorTranslator.FromHtml(Rank.Color));
                    Header.Location = new Point(0, YCoordinate);
                    YCoordinate += 20;
                    pnlAccounts.Controls.Add(Header);
                    foreach (var Account in Accounts.FindAll(a => a.RankId == Rank.Id)) {
                        var Item = GetItemPanel(Account.Name, ColorTranslator.FromHtml(Rank.Color), Account.Online);
                        Item.Location = new Point(0, YCoordinate);
                        YCoordinate += 51;
                        pnlAccounts.Controls.Add(Item);
                    }
                    YCoordinate -= 1;
                }
            } catch { }
        }

        private Panel GetHeaderPanel(string header, Color background) {
            var Panel = new Panel();
            Panel.Width = pnlAccounts.Width - 17;
            Panel.Height = 20;
            Panel.BackColor = background;
            var Label = new Label();
            Label.Text = header;
            Label.ForeColor = Color.White;
            Label.AutoSize = false;
            Label.TextAlign = ContentAlignment.MiddleCenter;
            Label.Dock = DockStyle.Fill;
            Panel.Controls.Add(Label);
            return Panel;
        }

        private Panel GetItemPanel(string accountName, Color background, bool online) {
            var Panel = new Panel {
                Width = pnlAccounts.Width - 17,
                Height = 50,
                BackColor = Color.Gainsboro,
                Name = $"pnlListEntry:{accountName}",
                Cursor = Cursors.Hand
            };
            Panel.Click += OnAccountListEntryClicked;
            var Label = new Label {
                ForeColor = Color.White,
                Padding = new Padding(3),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Text = accountName,
                AutoSize = true,
                BackColor = background,
                Location = new Point(15, 15),
                Name = $"lblListEntry:{accountName}",
                Cursor = Cursors.Hand
            };
            Label.Click += OnAccountListEntryClicked;
            Panel.Controls.Add(Label);
            var Status = new DoubleBufferedPanel {
                Size = new Size(20, 20),
                Location = new Point(Panel.Width - 35, 15),
                State = online ? AccountState.Online : AccountState.Offline
            };
            Status.Paint += StatusElementPaint;
            Panel.Controls.Add(Status);
            if (online) {
                var Label2 = new Label {
                    ForeColor = Color.DimGray,
                    Padding = new Padding(3),
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    Text = $"in {Channels.Find(c => c.MemberIds.Contains(Accounts.Find(a => a.Name == accountName).Id)).Name}",
                    AutoSize = true,
                    BackColor = Color.White,
                    Location = new Point(Label.Width + 21, 15),
                    Name = $"lblListStatusEntry:{accountName}",
                    Cursor = Cursors.Hand
                };
                Label2.Click += OnAccountListEntryClicked;
                Panel.Controls.Add(Label2);
            } else {
                Status.State = AccountState.Offline;
            }
            return Panel;
        }

        private void OnAccountListEntryClicked(object sender, EventArgs e) {
            var AccountName = ((Control) sender).Name.Split(':')[1];
            SendPacketToServer(string.Join("|", Enumerations.Action.GetAccountData, AccountName));
        }

        private void StatusElementPaint(object sender, PaintEventArgs e) {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            SolidBrush Brush;
            var Panel = (DoubleBufferedPanel) sender;
            if (Panel.State == AccountState.Online) {
                Brush = new SolidBrush(ColorTranslator.FromHtml("#1ED760"));
            } else if (Panel.State == AccountState.Offline) {
                Brush = new SolidBrush(Color.DimGray);
            } else {
                Brush = new SolidBrush(ColorTranslator.FromHtml("#FC3539"));
            }
            e.Graphics.FillEllipse(Brush, new RectangleF(0, 0, 19F, 19F));
        }

        private void SetControlAccessability() {

        }

        public void DisplayForm(Form form) {
            Invoke(new Action<Form>(f => f.Show()), form);
        }

        public void SendPacketToServer(string packet) {
            FConnection.SetStreamContent(packet);
        }

        public string Serialize(dynamic content, bool indented) {
            if (indented)
                return JsonConvert.SerializeObject(content, Formatting.Indented);
            return JsonConvert.SerializeObject(content);
        }

        public dynamic Deserialize(string content) {
            return JsonConvert.DeserializeObject(content);
        }
    }
}
