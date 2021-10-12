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
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }
        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void iconButton1_Click(object sender, EventArgs e)
        {
               
            Process p = Process.Start("dxdiag");
            Thread.Sleep(100);
            p.WaitForInputIdle();
            SetParent(p.MainWindowHandle, this.Handle);
        }
    }
}
