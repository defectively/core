using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Defectively;
using Defectively.Compatibility;
using Newtonsoft.Json;

namespace DefectivelyClient.Forms
{
    public partial class LoginDialogue : Form
    {
        public ServerMetaData MetaData { get; set; }

        private readonly RSACryptoServiceProvider ServiceProvider = new RSACryptoServiceProvider();
        private readonly RSACryptoServiceProvider PreServiceProvider = new RSACryptoServiceProvider();

        private const string PublicKey = "<RSAKeyValue><Modulus>n1G5qxqPSnvu3A0ympXV/qHCeMasaXOqrmlIF/2sAMgrjYmCXcAeyplvirGPDOUPHHUIBmZzqbtmU5Ol2l9VpMEesuDneEZh8nB9dpvtNe+LpoDAX4qVvrf78SXDzT9biFwJj8AAUgYI1JA2lN/+rHYCOYTlfrn1cln3q2F1sbtOKfJyYdt5PsbALI2In3b134k4XP93W5fLqNSFHbG3LcWTLkU06/cobg8etttjyyg5svUAEN+LnhtfrGilLW67oi4vHnjzhggEy7zo2RGfs2PJ8CnwlmAOGGtN/DaPTjobeHZRrIsIWy9/SPpSozaUV/mNxkrvYFEgE0BP6KCgS7HVXcJbsOcNIKIdUhRgRkXKT5XF7wakw9SjD3BCNZRIbfruBbN/dUx0jHgdU1zLJ1gVQcE0P/Fyrubq6VcKSTLrhygz2CkRSqUmE9MVmbISmDv13cI/lg/sTbEEpxWF+6lZdxmts5GVxjvTLbbv0CglRu8SyYGycWtHkSYsVEKYwBV5DRXfEWN8/uJcgrWxYNKH8+1nld/RSKVQ2lYKK2b0cJF4OHuhNGubNDDUn99LZviQmNQAzaK4hTFtRGaTVhcMOgl6KdEafQ6/oy9l9ynk+dw9HUJSq521ef1tFEvFYp3jNIjG8fcMikr5XuOoETaLFsdBNRPqMGQm7BuRzc8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private const string PrivateKey = "<RSAKeyValue><Modulus>pFLs/4KQ1sQy5EQxPlGNpwD3/aP52csVtFTMLmR0vKaoAD0CjggLxq0v14R/idIc1rN7KYA+Yv3ZqTHchTCx5DIhMX5f31uPNWvrKxbw7mmOjL2/cgP5KI399pbcBse/3sfOiPMgzZPaKuFI4x/cET03WJoG2Uexwu4/pZHVVBiCkqOSI4pUGxhR4ZsCE+sFczhy6HhHNH29wRzTKL7dZpERobZlcgjWAxyX6iPS7emnbuxdVfES2r/X5uW812KMPDaSEW0NYK2mQ/cnZtdQp1TbiOv/NsFaTlDlOKlbKAwmq/bJZoyfqi8U0Z00B0iWypXL3O9fbodNNFZDftq/4flpsiRxrEqqeYp3zsAaewdgtvmha0rs90xH08Vhgi+i+xesvxLR/pxL5iw3x2dE6PMmLkCrh0T2sNqauqE2LEKANo2r29Nr83aa9X8Cs+Oqe/y30xEInWcF7iKMQCiaRfWORuxdgjaSXybGkbEe2iDhK8X8aTbkq7xKGSzmP53FxDi0U2kkIRZoCnrkk54MYPDAgPR0lWOOq9Cc9A5iipOTyMiioNP+d7OH7/97EwEC2sIC2daYA3kwA0mrTB2GV1wCSOBgZGY/j2zmSfonPXH8YitLWj++vlM3XOz0Fd73G9fRLHk84zNopxXH2xbom2j8LItaHP4SxRwFN0IQQuk=</Modulus><Exponent>AQAB</Exponent><P>xxB475hFuJVtqXDHFzJq/WhRA3hfU1qko9zy90oHiMxyHnC9/XwbeP5iH2ftb27+boq9oRvbEbOrB/Lvvp6CoqsRFIcArVyXbI5+OOI1G47tkiXcdql0vYQoyBPXOBqmFK4P/dRjfuicWOfFgqLwnRPClJc7wvROPtAOlxj+XGop8+/yxi/kl+MzR6k5gYb8V5UmhycJ7OgZa1PHzj41eoik3xJz9spVmmeFK+ro37Y5Fb8LlRJty24PCB+XsDRmPN28XNx6XKVO5zNBT4HdTLYRx13mWKnmB0jdHjCv7agyrrsWDgDpiWRL5Dj22ReL1Q/lZRbLQ8/Kre9EuEimmQ==</P><Q>01LA9Y1ERnvYCDjdD2gb0pp8zEbLjefPYCpfOQrM0ORSo8fXEjXb6n/DcdVgs9wGWZXG8CC1mtJ25WKfbs5oUp0O8HBzEIaaPTYdETSjOwpS2pHkEwRI59fL0hUxSRJBKHI7U4DkLUcw7kJsQZiAti3QnNTfrn0CwS2NcXu9iiSLlCiAomhWU9IS8vMPLcLnexzzIgTeB3hZo4fNh1BmLW7Xqgou4J6VFZixVJ0uSlQQy4AKFaGF2T5ldbyDWAOr5YStnwJl5E7OpHqsmL0Q5HlMWIp6FvpQ7zYGfHwFQ+fgt+xIn+B9rgAwzSKM8ZhDlPzhMQLWKj5IecO70CpA0Q==</Q><DP>ukq8It2KQhf1rKCScS8J2WUKjAjWjRdDBOb9qldpfah3E+3Gn7bJrw3BnkqQdbyV97V3iZKcDZDq+mFr5CRLdRhKv78n7xW70Cf6EBoCQWwdAKzWCWbEjadk0vlebG7kBm5vIMjm5BmkV79vo7YBH78iVhTCJMylfTsQrG8DfFEOOe/Qb5DaiRpjHylLW+CLvxsiF1F9hGwhfcPGNUkamzXNtcV7KPZp7jn68wLANLw/6A4GNNguUDcLcjq+pnQjScrpQK5FBPbfRJc/A70w8V1ifgVuUIOPdjnGVT6TJgJGjCchmLFZ3O4z5703pirW/eoGb/hI+Yk40FYfJac34Q==</DP><DQ>VGxtFixXqGj1h2NgPTV0WBDL5rgpvglr+Zkz7Y/4/0MYGMJPk8DcmLRuGl4KghBWoReLIIeQxcdrJHzgAN6JIugH/dqOvX1oxSeHOUZ0J7QaIaPDIC3ICodVsBozVGPskAIC3XtSrRwR2j3DDfmlAiMPgngw3H6oyRAvv7SVpkivUoNT0I4qXtZAJ7sex0NkQvTv1RloskdMWF56p6JhD6mGkzH6RFZWbQhRX+JjieJHy2TdooKi/IVG92BWgKUG2WzGCA5nMmyhdWhk56gwxXYIIB9CY0ehac+Fi9noKJbMWe4VnXmL/CWrWWiCMkqIRU85j+D4OmwjfDHMKH+Y4Q==</DQ><InverseQ>DQxNMuxiB7lHErftSyONV+aTlcfv8y4qtPwr/ZKd9f0A1KFnrPaKm2+F6YCyHHTUfVoQj2QuqpJwWfPAcA5OU6aHMmZzE2lq8ii5btqfb1hy7M9Pk7ng8EdKP+ovZ1og94MpmY+I6Bwsr0u5/Cv/GCiCF56grXrG9GWmZmgKFC725h8219RSmNQTjWERHGhksNhvLmM1sc4tD8TqJCSKnXP0+dywI7tXNbCmGAoJi12g7iqRhH8AtgUCXcX8UVVhfrvduyMk0O6JTnJjcGHzinyS9z5iKdq3AsBo6kLkkDt1VlNk90yuHIwAQ/YqIYNXld2qxWsEk5nek0xmcFwHSQ==</InverseQ><D>A11740UrHmzU7noLiJ9Or3R8f6YhpiFLs95XMp2Fyv2+O8gEEwDM7fAKxmb9HidOhiKVk31f+bLBZ/7AiX08bWQN7DeucrJrMcDAp4igHT/N5qm1n5n/eqJCyM+g2KYzUpaErycMfU1Jdt6XeahDv1ohtaes23sFg8yRgtxkUiUw2lwtcFsjOw1R0vUT0zDZUxldOA/LhIKNNeTXWbKj8ddndSh5Nh9Cc7yci1PZvFvQPRwr0qhd1ps+aoj6p64J2WtULTVupFPWD3cCqG9hJFYfa1PK7ZYC2Y78TL9iIaUzDws+J2Kam/d8HYlSwRHuXZ549vCzg33Tmc5o8jJ8YrXLef+w2VRzQh2u5i4v0cJnAtED5EYNswPSJ100LeSvYce4+enHuIIkK4048y4OUmsDogyY0QXA61pmU9wai2Lvkr2QtT94piBh5OXHzT6bs1yw9bAuLx4mExlFD+UWvy13eiM8BUfjeiGKUCgXpaQtYChttpwEL1/jEJ6DaVdBkkRRYuJb+xYVhGGdIWS3mKyahqjC56Na3thv83bFR1Otpx2XasLHFMTVXRoBk6D8xOnHdI9iC6VyXsSjfPm22UHTeXL0SI6jd4TxXKhUubfF4w7xI1TM0EgYsopZ8hvG/AQmQyPGnzjDZJNbKSQDV0EkqbG+tPEXeYX7f4moVHE=</D></RSAKeyValue>";

        private bool Connected;
        private bool AutoConnect;

        public LoginDialogue() {
            InitializeComponent();

            btnLogin.Click += OnBtnLoginClick;
            Closing += OnClosing;
            Shown += OnShown;

            this.Text += $" - Version {new Version().ToMediumString()}";

            var SessionsPath = Path.Combine(Application.StartupPath, "Sessions");
            if (Directory.Exists(SessionsPath)) {
                var SessionFolders = Directory.GetDirectories(SessionsPath);
                if (SessionFolders.Length > 0) {
                    foreach (var FolderPath in SessionFolders) {
                        if (File.Exists(FolderPath + "\\session.done")) {
                            Directory.Delete(FolderPath, true);
                        }
                    }
                }
            }

            if (File.Exists(Application.StartupPath + "\\.connections")) {
                var Connections = File.ReadAllLines(Application.StartupPath + "\\.connections").ToList();
                if (Connections.Count > 0) {
                    var Dialog = new ReconnectDialogue();
                    if (Dialog.ShowDialog(Connections) == DialogResult.OK) {
                        tbxAddress.Text = Connections[Dialog.SelectedIndex].Split(':')[0];
                        tbxPort.Text = Connections[Dialog.SelectedIndex].Split(':')[1];
                        AutoConnect = true;
                        Connections.RemoveAll(c => Dialog.RemovedIndexes.Contains(Connections.IndexOf(c)));
                        File.WriteAllLines(Application.StartupPath + "\\.connections", Connections);
                    }
                }
            }
        }

        private void OnShown(object sender, EventArgs e) {
            if (AutoConnect)
                btnLogin.PerformClick();
        }

        private void OnClosing(object sender, CancelEventArgs e) {
            Application.Exit();
        }

        private void OnBtnLoginClick(object sender, EventArgs e) {
            if (!Connected) {
                int Port;
                if (string.IsNullOrEmpty(tbxAddress.Text))
                    tbxAddress.Text = "localhost";
                if (Regex.IsMatch(tbxAddress.Text, "^localhost$|^(\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}$)")) {
                    if (int.TryParse(tbxPort.Text, out Port)) {
                        var FClient = new TcpClient();
                        try {
                            FClient.Connect(tbxAddress.Text, Port);
                        } catch {
                            MessageBox.Show("Defectively couldn't connect to the server. Make sure the entered address and port is correct and the server is up and running.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ServiceProvider.FromXmlString(PublicKey);
                        PreServiceProvider.FromXmlString(PrivateKey);
                        var DConnection = new DiscardableConnection(FClient.GetStream());
                        DConnection.SetRawStreamContent(Cryptography.RSAEncrypt(string.Join("|", Enumerations.Action.GetServerMetaData,""), ServiceProvider));
                        MetaData = JsonConvert.DeserializeObject<ServerMetaData>(Cryptography.RSADecrypt(DConnection.GetRawStreamContent(), PreServiceProvider));
                        btnRegister.Enabled = MetaData.AcceptsRegistration;
                        try {
                            DConnection.Dispose();
                            FClient.Dispose();
                        } catch { }


                        if (MetaData.AcceptsGuests) {
                            // Implement   
                        }
                        if (!MetaData.AcceptsRegistration) {
                            // Implement
                        }

                        if (!MetaData.ServerVersion.InRange(new Version())) {
                            var Dialog = new VersionConflictDialogue();
                            Dialog.Initialize(new Version(), MetaData.ServerVersion, MetaData.ServerCoreVersion, "Your client is running on a version that does not support the server you're connecting to. To be able to connect to this server please update the server to the least supported version or use an older client.");
                            Dialog.ShowDialog();
                            tbxAddress.Clear();
                            tbxPort.Clear();
                            return;
                        }

                        if (!new Version().InRange(MetaData.ServerVersion)) {
                            var Dialog = new VersionConflictDialogue();
                            Dialog.Initialize(new Version(), MetaData.ServerVersion, MetaData.ServerCoreVersion, "The server you're connecting to is running on a version that does not support your client. To be able to connect to this server please update your client to the least supported version or use an older server.");
                            Dialog.ShowDialog();
                            tbxAddress.Clear();
                            tbxPort.Clear();
                            return;
                        }

                        if (MetaData.IsLockdown) {
                            MessageBox.Show("Defectively has successfully established a connection to the server. However, the server is on Lockdown and does not accept any new connection at the moment.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        Connected = true;
                        btnLogin.Text = "Login";
                        tbxAccountId.Enabled = tbxPassword.Enabled = true;
                        tbxAddress.Enabled = tbxPort.Enabled = false;
                    } else {
                        MessageBox.Show("The given port is invalid. Valid ports only contain numbers.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("The given address is invalid. Valid could be:\n- a top-level domain like \"festival.ml\"\n- an IP like \"127.0.0.1\"\n- or \"localhost\".", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                var MainWindow = new MainWindow();
                var Port = int.Parse(tbxPort.Text);
                if (!string.IsNullOrEmpty(tbxAccountId.Text) && !string.IsNullOrWhiteSpace(tbxAccountId.Text)) {
                    if (!string.IsNullOrEmpty(tbxPassword.Text) && !string.IsNullOrWhiteSpace(tbxPassword.Text)) {
                        MainWindow.Show();
                        MainWindow.Connect(tbxAddress.Text, Port, tbxAccountId.Text, tbxPassword.Text);


                        var Connections = new List<string>();
                        if (File.Exists(Application.StartupPath + "\\.connections")) {
                            Connections = File.ReadAllLines(Application.StartupPath + "\\.connections").ToList();
                        }
                        if (!Connections.Contains($"{tbxAddress.Text}:{tbxPort.Text}")) {
                            Connections.Add($"{tbxAddress.Text}:{tbxPort.Text}");
                        }
                        File.WriteAllLines(Application.StartupPath + "\\.connections", Connections);


                        Hide();
                    } else {
                        MessageBox.Show("You must enter a password in order to connect.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("You must enter an account-id in order to connect.", "Defectively", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
