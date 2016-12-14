﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci;
using Renci.SshNet;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

namespace Aditum
{
    public partial class frmMain : Form
    {
        public bool HostIsLive = false;
        public DataTable dt = new DataTable();

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            HostIsLive = IsHostLive();
            if (HostIsLive)
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[ ] Attempting registration...");
                string hostip = tbxHostIP.Text;
                string hostusername = tbxHostUsername.Text;
                string hostpassword = tbxHostPassword.Text;
                string cmd = "cd Aditum && echo \"" + tbxStudentID.Text + "," + tbxStudentPIN.Text + "," + tbxName.Text + "\" >> database.csv";
                try
                {
                    SshClient cSSH = new SshClient(hostip, 22, hostusername, hostpassword);
                    cSSH.Connect();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[+] SSH connection established.");
                    SshCommand x = cSSH.RunCommand(cmd);
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[+] Command exucution succesful.");
                    cSSH.Disconnect();
                    cSSH.Dispose();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[+] Released unmanaged resources.");
                    tbxName.Text = "";
                    tbxStudentID.Text = "";
                    tbxStudentPIN.Text = "";
                    tbxName.Focus();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[+] Registration succesful.");
                }
                catch (Exception)
                {
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[-] Unable to perform SSH operations.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[-] Are you certain host "+tbxHostIP.Text+" is running an SSH server on port 22?");
                    throw;
                }
            }
            else
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[-] Host " + tbxHostIP.Text + " is down.");
            }
        }

        private void Logs_Enter(object sender, EventArgs e)
        {
            getlogs();
        }

        private void btnOptionsVerify_Click(object sender, EventArgs e)
        {
            rtbxOutput.AppendText(System.Environment.NewLine);
            rtbxOutput.AppendText(System.Environment.NewLine);
            rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[ ] Pinging " + tbxHostIP.Text + "...");
            HostIsLive = IsHostLive();
            if (HostIsLive)
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Host has responded.");
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[ ] Attempting SSH connection...");
                string hostip = tbxHostIP.Text;
                string hostusername = tbxHostUsername.Text;
                string hostpassword = tbxHostPassword.Text;
                try
                {
                    SshClient cSSH = new SshClient(hostip, 22, hostusername, hostpassword);
                    cSSH.Connect();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] SSH connection established.");
                    SshCommand x = cSSH.RunCommand("ls");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Command exucution succesful.");
                    cSSH.Disconnect();
                    cSSH.Dispose();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Released unmanaged resources.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Connection is solid.");
                }
                catch (Exception)
                {
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Unable to perform SSH operations.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Are you certain host " + tbxHostIP.Text + " is running an SSH server on port 22?");
                    throw;
                }
            }
            else
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Host is not responding.");
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Check network connection.");
            }
        }

        public bool IsHostLive()
        {
            try
            {
                var ping = new Ping();
                var reply = ping.Send(tbxHostIP.Text, 400);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            tbxName.Focus();
        }

        private void Options_Click(object sender, EventArgs e)
        {
            tbxHostIP.Focus();
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcMain.SelectedTab == Register)
            {
                tbxName.Focus();
            }
            if (tbcMain.SelectedTab == Options)
            {
                tbxHostIP.Focus();
            }
        }

        private void clbxHideSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            int checkeditemcount = clbxHideSelected.CheckedItems.Count;
            if (checkeditemcount != 0)
            {
                try
                {
                    string s = "1=1";
                    foreach (string item in clbxHideSelected.CheckedItems)
                    {
                        if (checkeditemcount == 1)
                            s += string.Format(" AND STUDENTNAME NOT LIKE '%{0}%'", item);
                        else if (checkeditemcount > 1)
                            s += string.Format(" AND STUDENTNAME NOT LIKE '%{0}%'", item);                           
                    }
                    dt.DefaultView.RowFilter = string.Format(s);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
        }

        private void btnRunAditumServer_Click(object sender, EventArgs e)
        {
            rtbxOutput.AppendText(System.Environment.NewLine);
            HostIsLive = IsHostLive();
            if (HostIsLive)
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[ ] Starting server on "+tbxHostIP.Text+"...");
                string hostip = tbxHostIP.Text;
                string hostusername = tbxHostUsername.Text;
                string hostpassword = tbxHostPassword.Text;
                //string cmd = "nohup /home/pi/runserver.sh &"; 
                try
                {
                    SshClient cSSH = new SshClient(hostip, 22, hostusername, hostpassword);
                    cSSH.ConnectionInfo.Timeout = TimeSpan.FromSeconds(2);
                    cSSH.Connect();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] SSH connection established.");
                    SshCommand x = cSSH.CreateCommand("sudo nohup killall Aditum_nogui.out  &");
                    x.Execute();
                    x = cSSH.CreateCommand("/home/pi/runserver.sh >/dev/null 2>&1 &");
                    x.Execute();
                    //var output = x.Result;
                    //rtbxOutput.AppendText(System.Environment.NewLine);
                    //rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + output);    
                    cSSH.Disconnect();
                    cSSH.Dispose();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Command exucution succesful.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Released unmanaged resources.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Aditum server start succesful.");
                }
                catch (Exception)
                { 
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Unable to perform SSH operations.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Are you certain host " + tbxHostIP.Text + " is running an SSH server on port 22?");
                    throw;
                }
            }
            else
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Host " + tbxHostIP.Text + " unreachable.");
            }
        }

        private void btnRebootPi_Click(object sender, EventArgs e)
        {
            HostIsLive = IsHostLive();
            if (HostIsLive)
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[ ] Attempting to reboot...");
                string hostip = tbxHostIP.Text;
                string hostusername = tbxHostUsername.Text;
                string hostpassword = tbxHostPassword.Text;
                string cmd = "/home/pi/reboot.sh >/dev/null 2>&1 &";
                SshClient cSSH = new SshClient(hostip, 22, hostusername, hostpassword);
                try
                {
                    cSSH.ConnectionInfo.Timeout = TimeSpan.FromSeconds(2);
                    cSSH.Connect();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] SSH connection established.");
                    SshCommand x = cSSH.RunCommand(cmd);
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Command exucution succesful.");
                    cSSH.Disconnect();
                    cSSH.Dispose();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Released unmanaged resources.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Reboot succesful.");
                }
                catch (Exception)
                {
                    cSSH.Disconnect();
                    cSSH.Dispose();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Released unmanaged resources.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] It would appear that the Reboot was succesful.");
                    //throw;
                }
            }
            else
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Host " + tbxHostIP.Text + " is down.");
            }
        }

        private void btnRefreshLogs_Click(object sender, EventArgs e)
        {
            getlogs();
        }

        public void getlogs()
        {      
            HostIsLive = IsHostLive();
            if (HostIsLive)
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[ ] Acquiring log data...");
                try
                {
                    for (int i = 0; i < clbxHideSelected.Items.Count; i++)
                    {
                        clbxHideSelected.SetItemChecked(i, false);
                    }
                    string hostip = tbxHostIP.Text;
                    string hostusername = tbxHostUsername.Text;
                    string hostpassword = tbxHostPassword.Text;
                    Stream file = File.Open("log.csv", FileMode.Create);
                    SftpClient cSSH = new SftpClient(hostip, 22, hostusername, hostpassword);
                    cSSH.Connect();
                    cSSH.DownloadFile("Aditum/log.csv", file);
                    cSSH.Disconnect();
                    cSSH.Dispose();
                    file.Close();
                    file.Dispose();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Retrieved log file through SFTP.");

                    List<string[]> rows = File.ReadAllLines("log.csv").Select(x => x.Split(',')).ToList();
                    dt.Reset();                 
                    dt.Columns.Add("STATUS", typeof(string));
                    dt.Columns.Add("ID", typeof(string));
                    dt.Columns.Add("PIN", typeof(string));
                    dt.Columns.Add("DETAILS", typeof(string));
                    dt.Columns.Add("TIME", typeof(string));
                    rows.ForEach(x => {
                        dt.Rows.Add(x);
                    });
                    dt.AcceptChanges();
                    dgv.Refresh();
                    DataView dv = new DataView(dt);
                    dgv.DataSource = dv;

                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Succesfully parsed CSV.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Log data acquired.");
                }
                catch (Exception)
                {
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Unable to retrieve logs. Are you sure host " + tbxHostIP.Text + " is running an SSH server on port 22?");
                    throw;
                }
                            }
            else
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Host " + tbxHostIP.Text + " is down.");
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClearDateFilter_Click(object sender, EventArgs e)
        {
            
        }


        private void btnApplyDateFilter_Click(object sender, EventArgs e)
        {
            //DateTime start  = DateTime.ParseExact(tbxDateFrom.Text);
            //DateTime stop   = DateTime.ParseExact(tbxDateTo.Text);
            //calendar.SelectionStart. = start;
            //calendar.SelectionStart = stop;
        }

        private void btnTimeSync_Click(object sender, EventArgs e)
        {
            SyncTime();
        }

        public void SyncTime()
        {
            HostIsLive = IsHostLive();
            rtbxOutput.AppendText(System.Environment.NewLine);
            if (HostIsLive)
            {
                string hostip = tbxHostIP.Text;
                string hostusername = tbxHostUsername.Text;
                string hostpassword = tbxHostPassword.Text;          
                DateTime thisDate = new DateTime();
                thisDate = DateTime.Now;
                string day = thisDate.ToString("dddd").Substring(0, 3);
                string daynr = thisDate.ToString("dd");
                string month = thisDate.ToString("MMMM").Substring(0, 3);
                string year = thisDate.ToString("yyyy");
                string time = thisDate.ToString("HH:mm:ss");
                string timestring = "\""+day + " " + month + " " + daynr + " " + time + " GMT " + year+"\""; //"Thu Aug  9 21:31:26 UTC 2012+"\";
                string cmd = "sudo date -s "+timestring;
                try
                {
                    SshClient cSSH = new SshClient(hostip, 22, hostusername, hostpassword);
                    cSSH.Connect();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] SSH connection established.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] "+timestring);
                    SshCommand x = cSSH.RunCommand(cmd);
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Command exucution succesful.");
                    cSSH.Disconnect();
                    cSSH.Dispose();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Released unmanaged resources.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Time synchronization complete.");
                }
                catch (Exception)
                {
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Unable to perform SSH operations.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Are you certain host " + tbxHostIP.Text + " is running an SSH server on port 22?");
                    throw;
                }
            }
            else
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Host " + tbxHostIP.Text + " unreachable.");
            }
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            HostIsLive = IsHostLive();
            if (HostIsLive)
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[ ] Attempting to shutdown...");
                string hostip = tbxHostIP.Text;
                string hostusername = tbxHostUsername.Text;
                string hostpassword = tbxHostPassword.Text;
                string cmd = "/home/pi/shutdown.sh >/dev/null 2>&1 &";
                SshClient cSSH = new SshClient(hostip, 22, hostusername, hostpassword);
                try
                {
                    cSSH.ConnectionInfo.Timeout = TimeSpan.FromSeconds(2);
                    cSSH.Connect();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] SSH connection established.");
                    SshCommand x = cSSH.RunCommand(cmd);
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Command exucution succesful.");
                    cSSH.Disconnect();
                    cSSH.Dispose();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Released unmanaged resources.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Shutdown succesful.");
                }
                catch (Exception)
                {
                    cSSH.Disconnect();
                    cSSH.Dispose();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Released unmanaged resources.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] It would appear that the Shutdown was succesful.");
                }
            }
            else
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Host " + tbxHostIP.Text + " is down.");
            }
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            tbxDateFrom.Text = MonthCalendar.SelectionStart.ToString("dd/MM/yyy");
            tbxDateTo.Text = MonthCalendar.SelectionEnd.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DGV Time format: Wed Dec 14 12:00:00 2016
            //TBX Time format: 07-12-2016
            string from_day = "01";
            string from_month = "01";
            string from_year = "2000";
            try
            {

                from_day = tbxDateFrom.Text.Substring(0, 2);
                from_month = tbxDateFrom.Text.Substring(3, 2);
                from_year = tbxDateFrom.Text.Substring(6, 4);
                
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect Time Format.");
            }

            DateTime DateFrom = new DateTime(Convert.ToInt32(from_year), Convert.ToInt32(from_month), Convert.ToInt32(from_day), 00, 00, 00); //(2000, 01, 01, 13, 37, 42); 2000-01-01 13:37:42
            string sDateFrom = DateFrom.ToString("ddd MMM d " +"*"+ " yyyy");
            MessageBox.Show(sDateFrom);
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("TIME LIKE '%{0}%' AND TIME LIKE '%{1}%'", DateFrom.ToString("ddd MMM d"+"%"), DateFrom.ToString("%" + "yyyy"));
            dgv.DataSource = dv;    
        }
    }
}
