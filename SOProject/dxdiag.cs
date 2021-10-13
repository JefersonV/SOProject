using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SOProject
{
    public partial class dxdiag : Form
    {
        public dxdiag()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Process p = Process.Start("dxdiag");
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
            SetParent(p.MainWindowHandle, this.Handle);
        }

        private void dxdiag_Load(object sender, EventArgs e)
        {

        }
    }
}
