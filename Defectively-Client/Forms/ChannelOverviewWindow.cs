using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Defectively;
using Defectively.Extension;
using DefectivelyClient.Management;
using Newtonsoft.Json;

namespace DefectivelyClient.Forms
{
    public partial class ChannelOverviewWindow : Form
    {
        private ChannelListItem SelectedItem;

        public ChannelOverviewWindow() {
            InitializeComponent();

            btnJoin.Click += OnBtnJoinClick;
            btnCreate.Click += OnBtnCreateClick;
            btnEdit.Click += OnBtnEditClick;
            btnClose.Click += OnBtnCloseClick;
            btnHypermove.Click += OnBtnHypermoveClick;
        }

        private void OnBtnJoinClick(object sender, EventArgs e) {
            if (SelectedItem != null) {
                ExtensionPool.Client.SendPacketToServer(string.Join("|", Enumerations.Action.TryChannelJoin, SelectedItem.ChannelId, ""));
                Close();
            }
        }

        private void OnBtnHypermoveClick(object sender, EventArgs e) {
            if (MainWindow.LuvaValues.CheckValue("defectively.canHyper")) {

            }
        }

        private void OnBtnCloseClick(object sender, EventArgs e) {
            if (SelectedItem != null && (MainWindow.LuvaValues.CheckValue("defectively.canCloseChannels") || SelectedItem.ChannelCreator == MainWindow.MyId)) {
                ExtensionPool.Client.SendPacketToServer(string.Join("|", Enumerations.Action.CloseChannel, SelectedItem.ChannelId));
            }
        }

        private void OnBtnEditClick(object sender, EventArgs e) {
            if (MainWindow.LuvaValues.CheckValue("defectively.canEditChannels")) {

            }
        }

        private void OnBtnCreateClick(object sender, EventArgs e) {
            if (MainWindow.LuvaValues.CheckValue("defectively.canCreateChannels")) {
                var Dialog = new ChannelCreateDialog();
                if (Dialog.ShowDialog() == DialogResult.OK) {
                    var Channel = Dialog.GetChannel();
                    ExtensionPool.Client.SendPacketToServer(string.Join("|", Enumerations.Action.CreateChannel, JsonConvert.SerializeObject(Channel)));
                    Close();
                }
            }
        }

        private int YCoordinate;

        public void SetChannels(IEnumerable<Channel> channels) {
            YCoordinate = 0;
            foreach (var Item in pnlItemContainer.Controls.OfType<ChannelListItem>()) {
                Item.SelectionChanged -= OnItemSelectionChanged;
            }
            pnlItemContainer.Controls.Clear();
            var ItemSize = new Size(channels.Count() * 68 > pnlItemContainer.Height ? 507 : 524, 60);
            foreach (var Channel in channels) {
                var Item = new ChannelListItem {
                    ChannelName = Channel.Name,
                    ChannelId = Channel.Id,
                    ChannelCreator = Channel.OwnerId,
                    ChannelProtection = Channel.JoinRestrictionMode.ToString(),
                    MemberCount = Channel.MemberIds.Count,
                    MemberCapacity = Channel.Capacity
                };
                Item.SelectionChanged += OnItemSelectionChanged;
                Item.Location = new Point(0, YCoordinate);
                Item.Size = ItemSize;
                YCoordinate += 68;
                pnlItemContainer.Controls.Add(Item);
                Item.RefreshItem();
            }
        }

        private void OnItemSelectionChanged(ChannelListItem sender, bool selected) {
            SelectedItem = pnlItemContainer.Controls.OfType<ChannelListItem>().ToList().Find(i => i.Mode == ChannelListItem.SelectionMode.Selected && i.ChannelName != sender.ChannelName);
            if (SelectedItem != null) {
                SelectedItem.Mode = ChannelListItem.SelectionMode.None;
            }
            if (selected) {
                SelectedItem = sender;
            }
        }
    }
}
