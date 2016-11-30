namespace Aditum
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRegister = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxStudentID = new System.Windows.Forms.TextBox();
            this.tbxStudentPIN = new System.Windows.Forms.TextBox();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.Register = new System.Windows.Forms.TabPage();
            this.lblStudentPIN = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.Logs = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnApplyDateFilter = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnClearDateFilter = new System.Windows.Forms.Button();
            this.btnRefreshLogs = new System.Windows.Forms.Button();
            this.lblHideSelected = new System.Windows.Forms.Label();
            this.clbxHideSelected = new System.Windows.Forms.CheckedListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Options = new System.Windows.Forms.TabPage();
            this.btnRebootPi = new System.Windows.Forms.Button();
            this.btnRunAditumServer = new System.Windows.Forms.Button();
            this.lblHostPassword = new System.Windows.Forms.Label();
            this.lblHostUsername = new System.Windows.Forms.Label();
            this.lblHostIP = new System.Windows.Forms.Label();
            this.tbxHostIP = new System.Windows.Forms.TextBox();
            this.tbxHostPassword = new System.Windows.Forms.TextBox();
            this.btnOptionsVerify = new System.Windows.Forms.Button();
            this.tbxHostUsername = new System.Windows.Forms.TextBox();
            this.rtbxOutput = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbcMain.SuspendLayout();
            this.Register.SuspendLayout();
            this.Logs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(22, 196);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(141, 40);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(22, 35);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(141, 20);
            this.tbxName.TabIndex = 0;
            // 
            // tbxStudentID
            // 
            this.tbxStudentID.Location = new System.Drawing.Point(22, 97);
            this.tbxStudentID.Name = "tbxStudentID";
            this.tbxStudentID.Size = new System.Drawing.Size(141, 20);
            this.tbxStudentID.TabIndex = 1;
            // 
            // tbxStudentPIN
            // 
            this.tbxStudentPIN.Location = new System.Drawing.Point(22, 159);
            this.tbxStudentPIN.Name = "tbxStudentPIN";
            this.tbxStudentPIN.Size = new System.Drawing.Size(141, 20);
            this.tbxStudentPIN.TabIndex = 2;
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.Register);
            this.tbcMain.Controls.Add(this.Logs);
            this.tbcMain.Controls.Add(this.Options);
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(789, 589);
            this.tbcMain.TabIndex = 0;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            // 
            // Register
            // 
            this.Register.Controls.Add(this.lblStudentPIN);
            this.Register.Controls.Add(this.lblStudentID);
            this.Register.Controls.Add(this.lblName);
            this.Register.Controls.Add(this.tbxName);
            this.Register.Controls.Add(this.tbxStudentPIN);
            this.Register.Controls.Add(this.btnRegister);
            this.Register.Controls.Add(this.tbxStudentID);
            this.Register.Location = new System.Drawing.Point(4, 22);
            this.Register.Name = "Register";
            this.Register.Padding = new System.Windows.Forms.Padding(3);
            this.Register.Size = new System.Drawing.Size(944, 563);
            this.Register.TabIndex = 0;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // lblStudentPIN
            // 
            this.lblStudentPIN.AutoSize = true;
            this.lblStudentPIN.Location = new System.Drawing.Point(17, 131);
            this.lblStudentPIN.Name = "lblStudentPIN";
            this.lblStudentPIN.Size = new System.Drawing.Size(65, 13);
            this.lblStudentPIN.TabIndex = 6;
            this.lblStudentPIN.Text = "Student PIN";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(17, 69);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(58, 13);
            this.lblStudentID.TabIndex = 5;
            this.lblStudentID.Text = "Student ID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Student Name";
            // 
            // Logs
            // 
            this.Logs.Controls.Add(this.comboBox2);
            this.Logs.Controls.Add(this.comboBox1);
            this.Logs.Controls.Add(this.btnApplyDateFilter);
            this.Logs.Controls.Add(this.lblTo);
            this.Logs.Controls.Add(this.lblFrom);
            this.Logs.Controls.Add(this.btnClearDateFilter);
            this.Logs.Controls.Add(this.btnRefreshLogs);
            this.Logs.Controls.Add(this.lblHideSelected);
            this.Logs.Controls.Add(this.clbxHideSelected);
            this.Logs.Controls.Add(this.dataGridView1);
            this.Logs.Location = new System.Drawing.Point(4, 22);
            this.Logs.Name = "Logs";
            this.Logs.Padding = new System.Windows.Forms.Padding(3);
            this.Logs.Size = new System.Drawing.Size(781, 563);
            this.Logs.TabIndex = 1;
            this.Logs.Text = "Logs";
            this.Logs.UseVisualStyleBackColor = true;
            this.Logs.Enter += new System.EventHandler(this.Logs_Enter);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(549, 48);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.comboBox1.Location = new System.Drawing.Point(549, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // btnApplyDateFilter
            // 
            this.btnApplyDateFilter.Location = new System.Drawing.Point(549, 231);
            this.btnApplyDateFilter.Name = "btnApplyDateFilter";
            this.btnApplyDateFilter.Size = new System.Drawing.Size(227, 23);
            this.btnApplyDateFilter.TabIndex = 11;
            this.btnApplyDateFilter.Text = "Apply Date Filter";
            this.btnApplyDateFilter.UseVisualStyleBackColor = true;
            this.btnApplyDateFilter.Click += new System.EventHandler(this.btnApplyDateFilter_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(545, 215);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(545, 4);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 7;
            this.lblFrom.Text = "From:";
            // 
            // btnClearDateFilter
            // 
            this.btnClearDateFilter.Location = new System.Drawing.Point(549, 260);
            this.btnClearDateFilter.Name = "btnClearDateFilter";
            this.btnClearDateFilter.Size = new System.Drawing.Size(227, 23);
            this.btnClearDateFilter.TabIndex = 6;
            this.btnClearDateFilter.Text = "Clear Date Filter";
            this.btnClearDateFilter.UseVisualStyleBackColor = true;
            this.btnClearDateFilter.Click += new System.EventHandler(this.btnClearDateFilter_Click);
            // 
            // btnRefreshLogs
            // 
            this.btnRefreshLogs.Location = new System.Drawing.Point(549, 525);
            this.btnRefreshLogs.Name = "btnRefreshLogs";
            this.btnRefreshLogs.Size = new System.Drawing.Size(227, 33);
            this.btnRefreshLogs.TabIndex = 4;
            this.btnRefreshLogs.Text = "Refresh Logs";
            this.btnRefreshLogs.UseVisualStyleBackColor = true;
            this.btnRefreshLogs.Click += new System.EventHandler(this.btnRefreshLogs_Click);
            // 
            // lblHideSelected
            // 
            this.lblHideSelected.AutoSize = true;
            this.lblHideSelected.Location = new System.Drawing.Point(546, 313);
            this.lblHideSelected.Name = "lblHideSelected";
            this.lblHideSelected.Size = new System.Drawing.Size(77, 13);
            this.lblHideSelected.TabIndex = 3;
            this.lblHideSelected.Text = "Hide Selected:";
            // 
            // clbxHideSelected
            // 
            this.clbxHideSelected.CheckOnClick = true;
            this.clbxHideSelected.FormattingEnabled = true;
            this.clbxHideSelected.Location = new System.Drawing.Point(549, 329);
            this.clbxHideSelected.Name = "clbxHideSelected";
            this.clbxHideSelected.Size = new System.Drawing.Size(227, 94);
            this.clbxHideSelected.TabIndex = 2;
            this.clbxHideSelected.SelectedIndexChanged += new System.EventHandler(this.clbxHideSelected_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(543, 563);
            this.dataGridView1.TabIndex = 1;
            // 
            // Options
            // 
            this.Options.Controls.Add(this.btnRebootPi);
            this.Options.Controls.Add(this.btnRunAditumServer);
            this.Options.Controls.Add(this.lblHostPassword);
            this.Options.Controls.Add(this.lblHostUsername);
            this.Options.Controls.Add(this.lblHostIP);
            this.Options.Controls.Add(this.tbxHostIP);
            this.Options.Controls.Add(this.tbxHostPassword);
            this.Options.Controls.Add(this.btnOptionsVerify);
            this.Options.Controls.Add(this.tbxHostUsername);
            this.Options.Location = new System.Drawing.Point(4, 22);
            this.Options.Name = "Options";
            this.Options.Padding = new System.Windows.Forms.Padding(3);
            this.Options.Size = new System.Drawing.Size(798, 563);
            this.Options.TabIndex = 2;
            this.Options.Text = "Options";
            this.Options.UseVisualStyleBackColor = true;
            this.Options.Click += new System.EventHandler(this.Options_Click);
            // 
            // btnRebootPi
            // 
            this.btnRebootPi.Location = new System.Drawing.Point(26, 300);
            this.btnRebootPi.Name = "btnRebootPi";
            this.btnRebootPi.Size = new System.Drawing.Size(201, 40);
            this.btnRebootPi.TabIndex = 15;
            this.btnRebootPi.Text = "Reboot Raspberry";
            this.btnRebootPi.UseVisualStyleBackColor = true;
            this.btnRebootPi.Click += new System.EventHandler(this.btnRebootPi_Click);
            // 
            // btnRunAditumServer
            // 
            this.btnRunAditumServer.Location = new System.Drawing.Point(24, 254);
            this.btnRunAditumServer.Name = "btnRunAditumServer";
            this.btnRunAditumServer.Size = new System.Drawing.Size(201, 40);
            this.btnRunAditumServer.TabIndex = 14;
            this.btnRunAditumServer.Text = "Run Aditum Server";
            this.btnRunAditumServer.UseVisualStyleBackColor = true;
            this.btnRunAditumServer.Click += new System.EventHandler(this.btnRunAditumServer_Click);
            // 
            // lblHostPassword
            // 
            this.lblHostPassword.AutoSize = true;
            this.lblHostPassword.Location = new System.Drawing.Point(21, 143);
            this.lblHostPassword.Name = "lblHostPassword";
            this.lblHostPassword.Size = new System.Drawing.Size(53, 13);
            this.lblHostPassword.TabIndex = 13;
            this.lblHostPassword.Text = "Password";
            // 
            // lblHostUsername
            // 
            this.lblHostUsername.AutoSize = true;
            this.lblHostUsername.Location = new System.Drawing.Point(21, 81);
            this.lblHostUsername.Name = "lblHostUsername";
            this.lblHostUsername.Size = new System.Drawing.Size(107, 13);
            this.lblHostUsername.TabIndex = 12;
            this.lblHostUsername.Text = "Username (default pi)";
            // 
            // lblHostIP
            // 
            this.lblHostIP.AutoSize = true;
            this.lblHostIP.Location = new System.Drawing.Point(21, 19);
            this.lblHostIP.Name = "lblHostIP";
            this.lblHostIP.Size = new System.Drawing.Size(149, 13);
            this.lblHostIP.TabIndex = 11;
            this.lblHostIP.Text = "Host IP (default 192.168.42.1)";
            // 
            // tbxHostIP
            // 
            this.tbxHostIP.Location = new System.Drawing.Point(26, 47);
            this.tbxHostIP.Name = "tbxHostIP";
            this.tbxHostIP.Size = new System.Drawing.Size(141, 20);
            this.tbxHostIP.TabIndex = 0;
            this.tbxHostIP.Text = "192.168.42.1";
            // 
            // tbxHostPassword
            // 
            this.tbxHostPassword.Location = new System.Drawing.Point(26, 171);
            this.tbxHostPassword.Name = "tbxHostPassword";
            this.tbxHostPassword.Size = new System.Drawing.Size(141, 20);
            this.tbxHostPassword.TabIndex = 2;
            this.tbxHostPassword.Text = "raspberry";
            // 
            // btnOptionsVerify
            // 
            this.btnOptionsVerify.Location = new System.Drawing.Point(26, 208);
            this.btnOptionsVerify.Name = "btnOptionsVerify";
            this.btnOptionsVerify.Size = new System.Drawing.Size(201, 40);
            this.btnOptionsVerify.TabIndex = 3;
            this.btnOptionsVerify.Text = "Verify and Apply";
            this.btnOptionsVerify.UseVisualStyleBackColor = true;
            this.btnOptionsVerify.Click += new System.EventHandler(this.btnOptionsVerify_Click);
            // 
            // tbxHostUsername
            // 
            this.tbxHostUsername.Location = new System.Drawing.Point(26, 109);
            this.tbxHostUsername.Name = "tbxHostUsername";
            this.tbxHostUsername.Size = new System.Drawing.Size(141, 20);
            this.tbxHostUsername.TabIndex = 1;
            this.tbxHostUsername.Text = "pi";
            // 
            // rtbxOutput
            // 
            this.rtbxOutput.BackColor = System.Drawing.SystemColors.WindowText;
            this.rtbxOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbxOutput.Font = new System.Drawing.Font("Consolas", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbxOutput.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rtbxOutput.HideSelection = false;
            this.rtbxOutput.Location = new System.Drawing.Point(791, 21);
            this.rtbxOutput.Name = "rtbxOutput";
            this.rtbxOutput.ReadOnly = true;
            this.rtbxOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbxOutput.Size = new System.Drawing.Size(371, 504);
            this.rtbxOutput.TabIndex = 1;
            this.rtbxOutput.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1045, 531);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 49);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1169, 583);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rtbxOutput);
            this.Controls.Add(this.tbcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMain";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aditum";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.tbcMain.ResumeLayout(false);
            this.Register.ResumeLayout(false);
            this.Register.PerformLayout();
            this.Logs.ResumeLayout(false);
            this.Logs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxStudentID;
        private System.Windows.Forms.TextBox tbxStudentPIN;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage Register;
        private System.Windows.Forms.TabPage Logs;
        private System.Windows.Forms.Label lblStudentPIN;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TabPage Options;
        private System.Windows.Forms.Label lblHostPassword;
        private System.Windows.Forms.Label lblHostUsername;
        private System.Windows.Forms.Label lblHostIP;
        private System.Windows.Forms.TextBox tbxHostIP;
        private System.Windows.Forms.TextBox tbxHostPassword;
        private System.Windows.Forms.Button btnOptionsVerify;
        private System.Windows.Forms.TextBox tbxHostUsername;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox rtbxOutput;
        private System.Windows.Forms.Label lblHideSelected;
        private System.Windows.Forms.CheckedListBox clbxHideSelected;
        private System.Windows.Forms.Button btnRunAditumServer;
        private System.Windows.Forms.Button btnRebootPi;
        private System.Windows.Forms.Button btnRefreshLogs;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClearDateFilter;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnApplyDateFilter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

