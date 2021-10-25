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

//Consulte Environment.UserInteractive.
//Eso identificará si el proceso tiene una interfaz, por ejemplo, los servicios no son interactivos con el usuario.
//También puede mirar Process.MainWindowHandle que le dirá si hay una interfaz gráfica.

//**Una combinación de estos dos controles debería cubrir todas las posibilidades.
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
        /*[System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        */
        private Process pDocked;
        private IntPtr hWndOriginalParent;
        private IntPtr hWndDocked;


        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private void iconButton1_Click(object sender, EventArgs e)
        {
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
        
        }

        private void dockIt()
        {
            if (hWndDocked != IntPtr.Zero) //don't do anything if there's already a window docked.
                return;
            hWndOriginalParent = IntPtr.Zero;

            pDocked = Process.Start(@"perfmon","/sys");
            while (hWndDocked == IntPtr.Zero)
            {
                pDocked.WaitForInputIdle(1000); //wait for the window to be ready for input;
                pDocked.Refresh();              //update process info
                if (pDocked.HasExited)
                {
                    return; //abort if the process finished before we got a handle.
                }
                hWndDocked = pDocked.MainWindowHandle;  //cache the window handle
            }
            //Windows API call to change the parent of the target window.
            //It returns the hWnd of the window's parent prior to this call.
            hWndOriginalParent = SetParent(hWndDocked, panel1.Handle);

            //Wire up the event to keep the window sized to match the control
            panel1.SizeChanged += new EventHandler(panel1_Resize);
            //Perform an initial call to set the size.
            panel1_Resize(new Object(), new EventArgs());
        }

        private void undockIt()
        {
            //Restores the application to it's original parent.
            SetParent(hWndDocked, hWndOriginalParent);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            dockIt();
            undockIt();

        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            //Change the docked windows size to match its parent's size. 
            MoveWindow(hWndDocked, 0, 0, panel1.Width, panel1.Height, true);
        }
    }
}
