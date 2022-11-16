using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickPatcher
{
    public partial class Form1 : Form
    {
        double version = 1.1;
        double versioncheck = 0;
        string versionstring;

        string filename = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2MessageDialog msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            msg.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            msg.Caption = "Notice";

            WebClient webclient = new WebClient();
            versionstring = webclient.DownloadString("https://pastebin.com/raw/aygBHxRz");
            versioncheck = double.Parse(webclient.DownloadString("https://pastebin.com/raw/aygBHxRz"));
            if (versioncheck != version)
            {
                msg.Text = "You have an outdated version!\nRedirecting to GitHub!";
                msg.Show();
                Process.Start("https://github.com/ValenityGameTrainers/PickCrafter/tree/main");
                Environment.Exit(0);
            }
            this.Text = "PickPatcher | v" + versionstring;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog op = new FolderBrowserDialog();
            op.ShowDialog();
            guna2TextBox1.Text = op.SelectedPath;
            filename = op.SelectedPath;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2MessageDialog msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            msg.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            msg.Caption = "Notice";

            if (guna2TextBox1.Text == "")
            {
                msg.Text = "I can't find the game!";
                msg.Show();
            }

            WebClient webclient = new WebClient();

            webclient.DownloadFileAsync(new Uri("https://onedrive.live.com/download?cid=CCA73EC99549FCF8&resid=CCA73EC99549FCF8%2120530&authkey=ADoEMsMlQm-vMaA"),filename + @"\PickCrafter\PickCrafter_Data\Managed\Assembly-CSharp.dll");
            webclient.DownloadFileCompleted += Complete;
        }

        private void Complete(object s,AsyncCompletedEventArgs e)
        {
            Guna.UI2.WinForms.Guna2MessageDialog msg = new Guna.UI2.WinForms.Guna2MessageDialog();
            msg.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            msg.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            msg.Caption = "Notice";
            msg.Text = "Successfully Patched!";
            msg.Show();
        }
    }
}
