namespace DefectivelyClient.Forms
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlConversation = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbxInput = new System.Windows.Forms.TextBox();
            this.pnlAccounts = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnManagement = new System.Windows.Forms.Button();
            this.btnChannels = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.cbxSidebar = new System.Windows.Forms.CheckBox();
            this.ntiNotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlConversation);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pnlAccounts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 521);
            this.panel1.TabIndex = 0;
            // 
            // pnlConversation
            // 
            this.pnlConversation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConversation.Location = new System.Drawing.Point(300, 0);
            this.pnlConversation.Name = "pnlConversation";
            this.pnlConversation.Size = new System.Drawing.Size(584, 481);
            this.pnlConversation.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Controls.Add(this.tbxInput);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(300, 481);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 40);
            this.panel2.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(475, 7);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 27);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // tbxInput
            // 
            this.tbxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbxInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxInput.Location = new System.Drawing.Point(11, 8);
            this.tbxInput.Name = "tbxInput";
            this.tbxInput.Size = new System.Drawing.Size(458, 25);
            this.tbxInput.TabIndex = 0;
            // 
            // pnlAccounts
            // 
            this.pnlAccounts.AutoScroll = true;
            this.pnlAccounts.BackColor = System.Drawing.Color.White;
            this.pnlAccounts.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccounts.Location = new System.Drawing.Point(0, 0);
            this.pnlAccounts.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAccounts.Name = "pnlAccounts";
            this.pnlAccounts.Size = new System.Drawing.Size(300, 521);
            this.pnlAccounts.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnSettings);
            this.panel3.Controls.Add(this.btnManagement);
            this.panel3.Controls.Add(this.btnChannels);
            this.panel3.Controls.Add(this.btnAccounts);
            this.panel3.Controls.Add(this.cbxSidebar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(884, 40);
            this.panel3.TabIndex = 1;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(326, 8);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(100, 25);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnManagement
            // 
            this.btnManagement.Location = new System.Drawing.Point(220, 8);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(100, 25);
            this.btnManagement.TabIndex = 3;
            this.btnManagement.Text = "Management";
            this.btnManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManagement.UseVisualStyleBackColor = true;
            // 
            // btnChannels
            // 
            this.btnChannels.Location = new System.Drawing.Point(114, 8);
            this.btnChannels.Name = "btnChannels";
            this.btnChannels.Size = new System.Drawing.Size(100, 25);
            this.btnChannels.TabIndex = 2;
            this.btnChannels.Text = "Channels";
            this.btnChannels.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChannels.UseVisualStyleBackColor = true;
            // 
            // btnAccounts
            // 
            this.btnAccounts.Location = new System.Drawing.Point(8, 8);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(100, 25);
            this.btnAccounts.TabIndex = 1;
            this.btnAccounts.Text = "Accounts";
            this.btnAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccounts.UseVisualStyleBackColor = true;
            // 
            // cbxSidebar
            // 
            this.cbxSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSidebar.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbxSidebar.Checked = true;
            this.cbxSidebar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSidebar.Location = new System.Drawing.Point(802, 8);
            this.cbxSidebar.Name = "cbxSidebar";
            this.cbxSidebar.Size = new System.Drawing.Size(75, 25);
            this.cbxSidebar.TabIndex = 0;
            this.cbxSidebar.Text = "Sidebar";
            this.cbxSidebar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbxSidebar.UseVisualStyleBackColor = true;
            // 
            // ntiNotification
            // 
            this.ntiNotification.Icon = ((System.Drawing.Icon)(resources.GetObject("ntiNotification.Icon")));
            this.ntiNotification.Text = "notifyIcon1";
            this.ntiNotification.Visible = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Defectively";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlAccounts;
        private System.Windows.Forms.Panel pnlConversation;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbxInput;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cbxSidebar;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnManagement;
        private System.Windows.Forms.Button btnChannels;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.NotifyIcon ntiNotification;
    }
}