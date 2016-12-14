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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.button1 = new System.Windows.Forms.Button();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.tbxDateFrom = new System.Windows.Forms.TextBox();
            this.tbxDateTo = new System.Windows.Forms.TextBox();
            this.MonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.btnRefreshLogs = new System.Windows.Forms.Button();
            this.lblHideSelected = new System.Windows.Forms.Label();
            this.clbxHideSelected = new System.Windows.Forms.CheckedListBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Options = new System.Windows.Forms.TabPage();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.btnTimeSync = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
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
            this.tbcMain.Size = new System.Drawing.Size(1005, 589);
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
            this.Register.Size = new System.Drawing.Size(997, 563);
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
            this.Logs.Controls.Add(this.button1);
            this.Logs.Controls.Add(this.lblDateTo);
            this.Logs.Controls.Add(this.lblDateFrom);
            this.Logs.Controls.Add(this.tbxDateFrom);
            this.Logs.Controls.Add(this.tbxDateTo);
            this.Logs.Controls.Add(this.MonthCalendar);
            this.Logs.Controls.Add(this.btnRefreshLogs);
            this.Logs.Controls.Add(this.lblHideSelected);
            this.Logs.Controls.Add(this.clbxHideSelected);
            this.Logs.Controls.Add(this.dgv);
            this.Logs.Location = new System.Drawing.Point(4, 22);
            this.Logs.Name = "Logs";
            this.Logs.Padding = new System.Windows.Forms.Padding(3);
            this.Logs.Size = new System.Drawing.Size(997, 563);
            this.Logs.TabIndex = 1;
            this.Logs.Text = "Logs";
            this.Logs.UseVisualStyleBackColor = true;
            this.Logs.Enter += new System.EventHandler(this.Logs_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(781, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 46);
            this.button1.TabIndex = 18;
            this.button1.Text = "Apply Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(613, 201);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(23, 13);
            this.lblDateTo.TabIndex = 17;
            this.lblDateTo.Text = "To:";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(613, 177);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(33, 13);
            this.lblDateFrom.TabIndex = 16;
            this.lblDateFrom.Text = "From:";
            // 
            // tbxDateFrom
            // 
            this.tbxDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDateFrom.Location = new System.Drawing.Point(646, 177);
            this.tbxDateFrom.Name = "tbxDateFrom";
            this.tbxDateFrom.Size = new System.Drawing.Size(129, 21);
            this.tbxDateFrom.TabIndex = 15;
            // 
            // tbxDateTo
            // 
            this.tbxDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDateTo.Location = new System.Drawing.Point(646, 201);
            this.tbxDateTo.Name = "tbxDateTo";
            this.tbxDateTo.Size = new System.Drawing.Size(129, 21);
            this.tbxDateTo.TabIndex = 14;
            // 
            // MonthCalendar
            // 
            this.MonthCalendar.Location = new System.Drawing.Point(616, 9);
            this.MonthCalendar.MaxSelectionCount = 10000;
            this.MonthCalendar.Name = "MonthCalendar";
            this.MonthCalendar.TabIndex = 12;
            this.MonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar_DateSelected);
            // 
            // btnRefreshLogs
            // 
            this.btnRefreshLogs.Location = new System.Drawing.Point(627, 525);
            this.btnRefreshLogs.Name = "btnRefreshLogs";
            this.btnRefreshLogs.Size = new System.Drawing.Size(149, 33);
            this.btnRefreshLogs.TabIndex = 4;
            this.btnRefreshLogs.Text = "Refresh Logs";
            this.btnRefreshLogs.UseVisualStyleBackColor = true;
            this.btnRefreshLogs.Click += new System.EventHandler(this.btnRefreshLogs_Click);
            // 
            // lblHideSelected
            // 
            this.lblHideSelected.AutoSize = true;
            this.lblHideSelected.Location = new System.Drawing.Point(624, 409);
            this.lblHideSelected.Name = "lblHideSelected";
            this.lblHideSelected.Size = new System.Drawing.Size(77, 13);
            this.lblHideSelected.TabIndex = 3;
            this.lblHideSelected.Text = "Hide Selected:";
            // 
            // clbxHideSelected
            // 
            this.clbxHideSelected.CheckOnClick = true;
            this.clbxHideSelected.FormattingEnabled = true;
            this.clbxHideSelected.Location = new System.Drawing.Point(627, 425);
            this.clbxHideSelected.Name = "clbxHideSelected";
            this.clbxHideSelected.Size = new System.Drawing.Size(149, 94);
            this.clbxHideSelected.TabIndex = 2;
            this.clbxHideSelected.SelectedIndexChanged += new System.EventHandler(this.clbxHideSelected_SelectedIndexChanged);
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 33;
            this.dgv.Size = new System.Drawing.Size(604, 563);
            this.dgv.TabIndex = 1;
            // 
            // Options
            // 
            this.Options.Controls.Add(this.btnShutdown);
            this.Options.Controls.Add(this.btnTimeSync);
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
            this.Options.Size = new System.Drawing.Size(997, 563);
            this.Options.TabIndex = 2;
            this.Options.Text = "Options";
            this.Options.UseVisualStyleBackColor = true;
            this.Options.Click += new System.EventHandler(this.Options_Click);
            // 
            // btnShutdown
            // 
            this.btnShutdown.Location = new System.Drawing.Point(6, 152);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(201, 40);
            this.btnShutdown.TabIndex = 17;
            this.btnShutdown.Text = "Shutdown Raspberry";
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnTimeSync
            // 
            this.btnTimeSync.Location = new System.Drawing.Point(6, 6);
            this.btnTimeSync.Name = "btnTimeSync";
            this.btnTimeSync.Size = new System.Drawing.Size(201, 40);
            this.btnTimeSync.TabIndex = 16;
            this.btnTimeSync.Text = "Synchronize Time";
            this.btnTimeSync.UseVisualStyleBackColor = true;
            this.btnTimeSync.Click += new System.EventHandler(this.btnTimeSync_Click);
            // 
            // btnRebootPi
            // 
            this.btnRebootPi.Location = new System.Drawing.Point(6, 106);
            this.btnRebootPi.Name = "btnRebootPi";
            this.btnRebootPi.Size = new System.Drawing.Size(201, 40);
            this.btnRebootPi.TabIndex = 15;
            this.btnRebootPi.Text = "Reboot Raspberry";
            this.btnRebootPi.UseVisualStyleBackColor = true;
            this.btnRebootPi.Click += new System.EventHandler(this.btnRebootPi_Click);
            // 
            // btnRunAditumServer
            // 
            this.btnRunAditumServer.Location = new System.Drawing.Point(6, 56);
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
            this.lblHostPassword.Location = new System.Drawing.Point(240, 82);
            this.lblHostPassword.Name = "lblHostPassword";
            this.lblHostPassword.Size = new System.Drawing.Size(140, 13);
            this.lblHostPassword.TabIndex = 13;
            this.lblHostPassword.Text = "Password (default raspberry)";
            // 
            // lblHostUsername
            // 
            this.lblHostUsername.AutoSize = true;
            this.lblHostUsername.Location = new System.Drawing.Point(240, 45);
            this.lblHostUsername.Name = "lblHostUsername";
            this.lblHostUsername.Size = new System.Drawing.Size(107, 13);
            this.lblHostUsername.TabIndex = 12;
            this.lblHostUsername.Text = "Username (default pi)";
            // 
            // lblHostIP
            // 
            this.lblHostIP.AutoSize = true;
            this.lblHostIP.Location = new System.Drawing.Point(240, 6);
            this.lblHostIP.Name = "lblHostIP";
            this.lblHostIP.Size = new System.Drawing.Size(149, 13);
            this.lblHostIP.TabIndex = 11;
            this.lblHostIP.Text = "Host IP (default 192.168.42.1)";
            // 
            // tbxHostIP
            // 
            this.tbxHostIP.Location = new System.Drawing.Point(243, 22);
            this.tbxHostIP.Name = "tbxHostIP";
            this.tbxHostIP.Size = new System.Drawing.Size(141, 20);
            this.tbxHostIP.TabIndex = 0;
            this.tbxHostIP.Text = "192.168.42.1";
            // 
            // tbxHostPassword
            // 
            this.tbxHostPassword.Location = new System.Drawing.Point(243, 98);
            this.tbxHostPassword.Name = "tbxHostPassword";
            this.tbxHostPassword.Size = new System.Drawing.Size(141, 20);
            this.tbxHostPassword.TabIndex = 2;
            this.tbxHostPassword.Text = "raspberry";
            // 
            // btnOptionsVerify
            // 
            this.btnOptionsVerify.Location = new System.Drawing.Point(243, 121);
            this.btnOptionsVerify.Name = "btnOptionsVerify";
            this.btnOptionsVerify.Size = new System.Drawing.Size(141, 25);
            this.btnOptionsVerify.TabIndex = 3;
            this.btnOptionsVerify.Text = "Verify and Apply";
            this.btnOptionsVerify.UseVisualStyleBackColor = true;
            this.btnOptionsVerify.Click += new System.EventHandler(this.btnOptionsVerify_Click);
            // 
            // tbxHostUsername
            // 
            this.tbxHostUsername.Location = new System.Drawing.Point(243, 61);
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
            this.rtbxOutput.Location = new System.Drawing.Point(1007, 22);
            this.rtbxOutput.Name = "rtbxOutput";
            this.rtbxOutput.ReadOnly = true;
            this.rtbxOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbxOutput.Size = new System.Drawing.Size(351, 504);
            this.rtbxOutput.TabIndex = 1;
            this.rtbxOutput.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1241, 536);
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
            this.ClientSize = new System.Drawing.Size(1358, 585);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.RichTextBox rtbxOutput;
        private System.Windows.Forms.Label lblHideSelected;
        private System.Windows.Forms.CheckedListBox clbxHideSelected;
        private System.Windows.Forms.Button btnRunAditumServer;
        private System.Windows.Forms.Button btnRebootPi;
        private System.Windows.Forms.Button btnRefreshLogs;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTimeSync;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.MonthCalendar MonthCalendar;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.TextBox tbxDateFrom;
        private System.Windows.Forms.TextBox tbxDateTo;
        private System.Windows.Forms.Button button1;
    }
}

