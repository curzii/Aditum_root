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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.tbxDateFrom = new System.Windows.Forms.TextBox();
            this.tbxDateTo = new System.Windows.Forms.TextBox();
            this.MonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.btnRefreshLogs = new System.Windows.Forms.Button();
            this.lblShowSelected = new System.Windows.Forms.Label();
            this.clbxShowSelected = new System.Windows.Forms.CheckedListBox();
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
            this.Logs.Controls.Add(this.btnClearFilters);
            this.Logs.Controls.Add(this.lblDateTo);
            this.Logs.Controls.Add(this.lblDateFrom);
            this.Logs.Controls.Add(this.tbxDateFrom);
            this.Logs.Controls.Add(this.tbxDateTo);
            this.Logs.Controls.Add(this.MonthCalendar);
            this.Logs.Controls.Add(this.btnRefreshLogs);
            this.Logs.Controls.Add(this.lblShowSelected);
            this.Logs.Controls.Add(this.clbxShowSelected);
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
            // btnClearFilters
            // 
            this.btnClearFilters.Location = new System.Drawing.Point(855, 519);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(139, 40);
            this.btnClearFilters.TabIndex = 18;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(607, 209);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(28, 16);
            this.lblDateTo.TabIndex = 17;
            this.lblDateTo.Text = "To:";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(607, 177);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(42, 16);
            this.lblDateFrom.TabIndex = 16;
            this.lblDateFrom.Text = "From:";
            // 
            // tbxDateFrom
            // 
            this.tbxDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDateFrom.Location = new System.Drawing.Point(652, 177);
            this.tbxDateFrom.Name = "tbxDateFrom";
            this.tbxDateFrom.Size = new System.Drawing.Size(185, 26);
            this.tbxDateFrom.TabIndex = 15;
            this.tbxDateFrom.TextChanged += new System.EventHandler(this.tbxDateFrom_TextChanged);
            // 
            // tbxDateTo
            // 
            this.tbxDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDateTo.Location = new System.Drawing.Point(652, 209);
            this.tbxDateTo.Name = "tbxDateTo";
            this.tbxDateTo.Size = new System.Drawing.Size(185, 26);
            this.tbxDateTo.TabIndex = 14;
            this.tbxDateTo.TextChanged += new System.EventHandler(this.tbxDateTo_TextChanged);
            // 
            // MonthCalendar
            // 
            this.MonthCalendar.Location = new System.Drawing.Point(610, 9);
            this.MonthCalendar.MaxSelectionCount = 10000;
            this.MonthCalendar.Name = "MonthCalendar";
            this.MonthCalendar.TabIndex = 12;
            this.MonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar_DateSelected);
            // 
            // btnRefreshLogs
            // 
            this.btnRefreshLogs.Location = new System.Drawing.Point(610, 519);
            this.btnRefreshLogs.Name = "btnRefreshLogs";
            this.btnRefreshLogs.Size = new System.Drawing.Size(239, 40);
            this.btnRefreshLogs.TabIndex = 4;
            this.btnRefreshLogs.Text = "Refresh Logs";
            this.btnRefreshLogs.UseVisualStyleBackColor = true;
            this.btnRefreshLogs.Click += new System.EventHandler(this.btnRefreshLogs_Click);
            // 
            // lblShowSelected
            // 
            this.lblShowSelected.AutoSize = true;
            this.lblShowSelected.Location = new System.Drawing.Point(855, 9);
            this.lblShowSelected.Name = "lblShowSelected";
            this.lblShowSelected.Size = new System.Drawing.Size(106, 13);
            this.lblShowSelected.TabIndex = 3;
            this.lblShowSelected.Text = "Only Show Selected:";
            // 
            // clbxShowSelected
            // 
            this.clbxShowSelected.CheckOnClick = true;
            this.clbxShowSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbxShowSelected.FormattingEnabled = true;
            this.clbxShowSelected.Location = new System.Drawing.Point(855, 25);
            this.clbxShowSelected.Name = "clbxShowSelected";
            this.clbxShowSelected.Size = new System.Drawing.Size(139, 487);
            this.clbxShowSelected.TabIndex = 2;
            this.clbxShowSelected.SelectedIndexChanged += new System.EventHandler(this.clbxShowSelected_SelectedIndexChanged);
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgv.Location = new System.Drawing.Point(1, 9);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 33;
            this.dgv.Size = new System.Drawing.Size(600, 550);
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
            this.rtbxOutput.Size = new System.Drawing.Size(351, 512);
            this.rtbxOutput.TabIndex = 1;
            this.rtbxOutput.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1238, 541);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 40);
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
        private System.Windows.Forms.Label lblShowSelected;
        private System.Windows.Forms.CheckedListBox clbxShowSelected;
        private System.Windows.Forms.Button btnClearFilters;
    }
}

