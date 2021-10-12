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
        /*
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        */
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        
        private void iconButton1_Click(object sender, EventArgs e)
        {

            /*
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.StandardInput.WriteLine("perfmon");
            p.StandardInput.Flush();
            p.StandardInput.Close();
        */
        }

        public void iconButton2_Click(object sender, EventArgs e)
        {
            /*
            OpenFileDialog od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {

                Process proc = Process.Start(od.FileName);
                proc.WaitForInputIdle();

                while (proc.MainWindowHandle == IntPtr.Zero)
                {
                    Thread.Sleep(100);
                    proc.Refresh();
                }


                SetParent(proc.MainWindowHandle, this.Handle);
            }
            */
                //%windir%\system32\perfmon.msc /s
                
                Process p = Process.Start("dxdiag.exe");
                p.WaitForInputIdle();
                while (p.MainWindowHandle == IntPtr.Zero)
                {
                Thread.Sleep(100);
                p.Refresh();
                }
                //Thread.Sleep(100);
                //p.InitializeLifetimeService();
                //p.WaitForInputIdle();
                //p.WaitForExit();
                SetParent(p.MainWindowHandle, this.panel1.Handle);
                
        }

    }
}
