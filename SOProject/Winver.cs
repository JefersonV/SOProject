using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SOProject
{
    public partial class Winver : Form
    {
        public Winver()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //Process p = new Process();
            //p.StartInfo.FileName = "ipconfig";
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.Arguments = "\all";
            //p.StartInfo.RedirectStandardOutput = true;
            //p.Start();
            Process p = Process.Start("winver.exe");
            //p.StartInfo.Arguments = "/sys";
            Thread.Sleep(100);
            p.WaitForInputIdle();
            SetParent(p.MainWindowHandle, this.Handle);
        }

        private void Winver_Load(object sender, EventArgs e)
        {

        }
    }
}
