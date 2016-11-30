using System;
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
            dataGridView1.DataSource = dt;
            HostIsLive = IsHostLive();
            if (HostIsLive)
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[ ] Acquiring log data...");

                try
                {
                    dt.Clear();
                    dt.Reset();
                    for (int i = 0; i < clbxHideSelected.Items.Count; i++)
                    {
                        clbxHideSelected.SetItemChecked(i, false);
                    }
                    string hostip = tbxHostIP.Text;
                    string hostusername = tbxHostUsername.Text;
                    string hostpassword = tbxHostPassword.Text;
                    Stream file = File.OpenWrite("log.csv");

                    SftpClient cSSH = new SftpClient(hostip, 22, hostusername, hostpassword);
                    cSSH.Connect();
                    cSSH.DownloadFile("Aditum/log.csv", file);
                    cSSH.Disconnect();
                    cSSH.Dispose();
                    file.Close();
                    file.Dispose();

                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[+] Retrieved log file through SFTP.");

                    StreamReader sr = new StreamReader("log.csv");
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                        for (int i = 0; i < rows.Length; i++)
                        {
                            rows[i] = rows[i].TrimStart('0');
                        }
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);

                        if (!clbxHideSelected.Items.Contains(rows[3]))
                        {
                            clbxHideSelected.Items.Add(rows[3], false);
                        }
                       
                    }
                    dt.DefaultView.RowFilter = string.Empty;
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    dt.Columns[0].SetOrdinal(4 - i);
                    //}
                    sr.Close();
                    sr.Dispose();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[+] Succesfully parsed CSV.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[+] Log data has been successfully acquired.");

                   
                }
                catch (Exception)
                {
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[-] Unable to retrieve logs. Are you sure host "+tbxHostIP.Text+" is running an SSH server on port 22?");
                    throw;
                }
                
            }
            else
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Host " +tbxHostIP.Text+" is down.");
            }
        }

        private void btnOptionsVerify_Click(object sender, EventArgs e)
        {
            rtbxOutput.AppendText(System.Environment.NewLine);
            rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[ ] Pinging " + tbxHostIP.Text + "...");
            HostIsLive = IsHostLive();
            if (HostIsLive)
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[+] Host " + tbxHostIP.Text + " is up.");
            }
            else
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ")+"[-] Host " + tbxHostIP.Text + " is down.");
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
            HostIsLive = IsHostLive();
            if (HostIsLive)
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[ ] Attempting to start Aditum Server on "+tbxHostIP.Text+"...");
                string hostip = tbxHostIP.Text;
                string hostusername = tbxHostUsername.Text;
                string hostpassword = tbxHostPassword.Text;
                string cmd = "sudo screen -d -m -S Aditum bash -c 'cd Aditum && sudo make run'";
                try
                {
                    SshClient cSSH = new SshClient(hostip, 22, hostusername, hostpassword);
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
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Aditum server start succesful.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[ ] Please reboot all nodes.");
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
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[-] Host " + tbxHostIP.Text + " is down.");
            }
        }

        private void btnRebootPi_Click(object sender, EventArgs e)
        {
            HostIsLive = IsHostLive();
            if (HostIsLive)
            {
                rtbxOutput.AppendText(System.Environment.NewLine);
                rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[ ] Attempting to reboot " + tbxHostIP.Text + "...");
                string hostip = tbxHostIP.Text;
                string hostusername = tbxHostUsername.Text;
                string hostpassword = tbxHostPassword.Text;
                string cmd = "sudo reboot";
                SshClient cSSH = new SshClient(hostip, 22, hostusername, hostpassword);
                try
                {
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
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Raspberry reboot succesful.");
                }
                catch (Exception)
                {
                    cSSH.Disconnect();
                    cSSH.Dispose();
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] Released unmanaged resources.");
                    rtbxOutput.AppendText(System.Environment.NewLine);
                    rtbxOutput.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + "[+] It would appear that the Raspberry reboot was succesful.");
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
    }
}
