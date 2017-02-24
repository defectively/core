namespace DefectivelyClient
{
    partial class ChannelListItem
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.lblCreator = new System.Windows.Forms.Label();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.lblMemberCount = new System.Windows.Forms.Label();
            this.lblProtection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.lblCreator.Location = new System.Drawing.Point(8, 34);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(96, 13);
            this.lblCreator.TabIndex = 5;
            this.lblCreator.Text = "Created by Server";
            // 
            // lblChannelName
            // 
            this.lblChannelName.AutoSize = true;
            this.lblChannelName.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblChannelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblChannelName.Location = new System.Drawing.Point(7, 10);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(81, 20);
            this.lblChannelName.TabIndex = 4;
            this.lblChannelName.Text = "#Defectively";
            // 
            // lblMemberCount
            // 
            this.lblMemberCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMemberCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMemberCount.ForeColor = System.Drawing.Color.White;
            this.lblMemberCount.Location = new System.Drawing.Point(447, 0);
            this.lblMemberCount.Name = "lblMemberCount";
            this.lblMemberCount.Size = new System.Drawing.Size(60, 60);
            this.lblMemberCount.TabIndex = 8;
            this.lblMemberCount.Text = "12/∞";
            this.lblMemberCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProtection
            // 
            this.lblProtection.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblProtection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProtection.ForeColor = System.Drawing.Color.White;
            this.lblProtection.Location = new System.Drawing.Point(387, 0);
            this.lblProtection.Name = "lblProtection";
            this.lblProtection.Size = new System.Drawing.Size(60, 60);
            this.lblProtection.TabIndex = 9;
            this.lblProtection.Text = "Open";
            this.lblProtection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChannelListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.lblProtection);
            this.Controls.Add(this.lblMemberCount);
            this.Controls.Add(this.lblCreator);
            this.Controls.Add(this.lblChannelName);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "ChannelListItem";
            this.Size = new System.Drawing.Size(507, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label lblChannelName;
        private System.Windows.Forms.Label lblMemberCount;
        private System.Windows.Forms.Label lblProtection;
    }
}
