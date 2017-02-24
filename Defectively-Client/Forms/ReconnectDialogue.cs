using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DefectivelyClient.Forms
{
    public partial class ReconnectDialogue : Form
    {
        public int SelectedIndex {
            get {
                if (lbxServers != null) {
                    return lbxServers.SelectedIndex;
                }
                return -1;
            }
            set { }
        }

        public List<int> RemovedIndexes { get; set; } = new List<int>();

        public ReconnectDialogue() {
            InitializeComponent();

            lbxServers.SelectedIndexChanged += OnLbxServersSelectedIndexChanged;
            btnRemove.Click += OnBtnRemoveClick;
        }

        private void OnBtnRemoveClick(object sender, EventArgs e) {
            if (!RemovedIndexes.Contains(SelectedIndex)) {
                if (lbxServers.Items.Count > 1) {
                    if (MessageBox.Show("This will remove the connection details after pressing \"Connect\".\nYou cannot connect to a an entry that is marked as \"will be removed\" and you cannot revert this action without canceling.\nAre you sure you want to remove this entry?", "Defectively", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        RemovedIndexes.Add(SelectedIndex);
                        lbxServers.Items[SelectedIndex] = lbxServers.Items[SelectedIndex] + " (will be removed)";
                    }
                } else {
                    if (MessageBox.Show("This will remove the connection details and connect to this server.\nYou cannot revert this action.\nAre you sure you want to remove this entry?", "Defectively", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        RemovedIndexes.Add(SelectedIndex);
                        lbxServers.Items[SelectedIndex] = lbxServers.Items[SelectedIndex] + " (will be removed)";
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void OnLbxServersSelectedIndexChanged(object sender, EventArgs e) {
            btnRemove.Enabled = lbxServers.SelectedItems.Count > 0;
            btnConnect.Enabled = lbxServers.SelectedItems.Count > 0 && !RemovedIndexes.Contains(SelectedIndex);
        }

        public DialogResult ShowDialog(IEnumerable<string> connections) {
            foreach (var Connection in connections) {
                lbxServers.Items.Add(Connection);
            }
            lbxServers.SelectedIndex = 0;
            return base.ShowDialog();
        }
    }
}
