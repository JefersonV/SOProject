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
    public partial class Perfmon : Form
    {
        public Perfmon()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Process p = Process.Start("winver.exe");
            Thread.Sleep(100);
            p.WaitForInputIdle();
            SetParent(p.MainWindowHandle, this.Handle);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Process test = new Process();
            test.StartInfo.FileName = "cmd.exe";
            test.StartInfo.CreateNoWindow = true;
            test.StartInfo.RedirectStandardInput = true;
            test.StartInfo.RedirectStandardOutput = true;
            test.StartInfo.UseShellExecute = false;
            test.Start();
            test.StandardInput.WriteLine("perfmon");
            test.StandardInput.Flush();
            test.StandardInput.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
