using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Defectively;

namespace DefectivelyClient.Forms
{
    public partial class ChannelCreateDialog : Form
    {
        public ChannelCreateDialog() {
            InitializeComponent();

            cmxAccess.SelectedIndex = 0;

            tbxChannelName.TextChanged += OnTbxChannelNameTextChanged;
            rbtCustom.CheckedChanged += OnRbtCustomCheckedChanged;
            cmxAccess.SelectedIndexChanged += OnCmxAccessSelectedIndexChanged;
            tbxAccessDetails.TextChanged += OnTbxAccessDetailsTextChanged;
        }

        private void OnTbxAccessDetailsTextChanged(object sender, EventArgs e) {
            btnCreate.Enabled = CreationEnabled();
        }

        private void OnCmxAccessSelectedIndexChanged(object sender, EventArgs e) {
            tbxAccessDetails.Enabled = cmxAccess.SelectedIndex > 0;
            btnCreate.Enabled = CreationEnabled();
        }

        private void OnRbtCustomCheckedChanged(object sender, EventArgs e) {
            nudCapacity.Enabled = rbtCustom.Checked;
        }

        private void OnTbxChannelNameTextChanged(object sender, EventArgs e) {
            var Escaped = tbxChannelName.Text.ToLower().Replace("ä", "ae").Replace("ö", "oe").Replace("ü", "ue").Replace("ß", "ss").ToList();
            Escaped.RemoveAll(c => new List<char> { ' ', '|', '#', '!', ',', '\'', '\"', '$', '?', '§' }.Contains(c));
            tbxChannelId.Text = Escaped.Aggregate("", (s, c) => s + c);
            btnCreate.Enabled = CreationEnabled();
        }

        private bool CreationEnabled() {
            return tbxChannelName.Text != "" && (cmxAccess.SelectedIndex == 0 || tbxAccessDetails.Text != "");
        }

        public Channel GetChannel() {
            return new Channel {
                Name = tbxChannelName.Text,
                Id = tbxChannelId.Text,
                Capacity = rbtCustom.Checked ? (int)nudCapacity.Value : -1,
                JoinRestrictionMode = (Enumerations.ChannelJoinMode)cmxAccess.SelectedIndex,
                Predicate = tbxAccessDetails.Text
            };
        }
    }
}
