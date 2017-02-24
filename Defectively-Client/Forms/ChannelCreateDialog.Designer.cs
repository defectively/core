namespace DefectivelyClient.Forms
{
    partial class ChannelCreateDialog
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.tbxChannelName = new System.Windows.Forms.TextBox();
            this.tbxChannelId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtUnlimited = new System.Windows.Forms.RadioButton();
            this.nudCapacity = new System.Windows.Forms.NumericUpDown();
            this.rbtCustom = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmxAccess = new System.Windows.Forms.ComboBox();
            this.tbxAccessDetails = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Label1.Location = new System.Drawing.Point(12, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(116, 21);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Create Channel";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label2.Location = new System.Drawing.Point(13, 48);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(86, 15);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Channel Name";
            // 
            // tbxChannelName
            // 
            this.tbxChannelName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxChannelName.Location = new System.Drawing.Point(16, 70);
            this.tbxChannelName.MaxLength = 50;
            this.tbxChannelName.Name = "tbxChannelName";
            this.tbxChannelName.Size = new System.Drawing.Size(250, 25);
            this.tbxChannelName.TabIndex = 7;
            // 
            // tbxChannelId
            // 
            this.tbxChannelId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxChannelId.Location = new System.Drawing.Point(276, 70);
            this.tbxChannelId.Name = "tbxChannelId";
            this.tbxChannelId.ReadOnly = true;
            this.tbxChannelId.Size = new System.Drawing.Size(250, 25);
            this.tbxChannelId.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(273, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Channel Id";
            // 
            // rbtUnlimited
            // 
            this.rbtUnlimited.AutoSize = true;
            this.rbtUnlimited.Location = new System.Drawing.Point(86, 138);
            this.rbtUnlimited.Name = "rbtUnlimited";
            this.rbtUnlimited.Size = new System.Drawing.Size(75, 17);
            this.rbtUnlimited.TabIndex = 10;
            this.rbtUnlimited.Text = "Unlimited";
            this.rbtUnlimited.UseVisualStyleBackColor = true;
            // 
            // nudCapacity
            // 
            this.nudCapacity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudCapacity.Location = new System.Drawing.Point(16, 165);
            this.nudCapacity.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudCapacity.Name = "nudCapacity";
            this.nudCapacity.Size = new System.Drawing.Size(250, 25);
            this.nudCapacity.TabIndex = 11;
            this.nudCapacity.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // rbtCustom
            // 
            this.rbtCustom.AutoSize = true;
            this.rbtCustom.Checked = true;
            this.rbtCustom.Location = new System.Drawing.Point(16, 138);
            this.rbtCustom.Name = "rbtCustom";
            this.rbtCustom.Size = new System.Drawing.Size(64, 17);
            this.rbtCustom.TabIndex = 12;
            this.rbtCustom.TabStop = true;
            this.rbtCustom.Text = "Custom";
            this.rbtCustom.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(13, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Channel Capacity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(273, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Channel Access";
            // 
            // cmxAccess
            // 
            this.cmxAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmxAccess.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmxAccess.FormattingEnabled = true;
            this.cmxAccess.Items.AddRange(new object[] {
            "Open (Default)",
            "Protected (Password)",
            "Ranked"});
            this.cmxAccess.Location = new System.Drawing.Point(276, 132);
            this.cmxAccess.Name = "cmxAccess";
            this.cmxAccess.Size = new System.Drawing.Size(250, 25);
            this.cmxAccess.TabIndex = 15;
            // 
            // tbxAccessDetails
            // 
            this.tbxAccessDetails.Enabled = false;
            this.tbxAccessDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxAccessDetails.Location = new System.Drawing.Point(276, 164);
            this.tbxAccessDetails.MaxLength = 50;
            this.tbxAccessDetails.Name = "tbxAccessDetails";
            this.tbxAccessDetails.Size = new System.Drawing.Size(250, 25);
            this.tbxAccessDetails.TabIndex = 16;
            // 
            // btnCreate
            // 
            this.btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(436, 219);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(90, 25);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // ChannelCreateDialog
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 260);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tbxAccessDetails);
            this.Controls.Add(this.cmxAccess);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbtCustom);
            this.Controls.Add(this.nudCapacity);
            this.Controls.Add(this.rbtUnlimited);
            this.Controls.Add(this.tbxChannelId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxChannelName);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelCreateDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Defectively";
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox tbxChannelName;
        private System.Windows.Forms.TextBox tbxChannelId;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtUnlimited;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.RadioButton rbtCustom;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmxAccess;
        private System.Windows.Forms.TextBox tbxAccessDetails;
        private System.Windows.Forms.Button btnCreate;
    }
}