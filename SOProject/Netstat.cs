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
    public partial class Netstat : Form
    {
        public Netstat()
        {
            InitializeComponent();
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            Process cmdProcess = new Process();

            cmdProcess.StartInfo.FileName = "ipconfig";
            cmdProcess.StartInfo.UseShellExecute = false;
            // RedIRECCIONAR stdout
            cmdProcess.StartInfo.RedirectStandardOutput = true;

            // INICIAR PROCESO
            cmdProcess.Start();
            
            textBox1.Text = cmdProcess.StandardOutput.ReadToEnd();
            
        }
    }
}
