using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SOProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
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
    }
}
