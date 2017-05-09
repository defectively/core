using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DefectivelyClient.Forms
{
    public partial class LastMessagesWindow : Form
    {
        public string SelectedMessage { get; private set; }

        public LastMessagesWindow() {
            InitializeComponent();
            
            btnInsert.Click += OnBtnInsertClick;
            this.Shown += (sender, e) => lsbHistory.SelectedIndex = 0;
        }

        private void OnBtnInsertClick(object sender, EventArgs e) {
            SelectedMessage = lsbHistory.SelectedItem.ToString();
        }

        public DialogResult ShowDialog(IEnumerable<string> messages) {
            lsbHistory.Items.AddRange(messages.ToArray());
            return ShowDialog();
        }
    }
}
