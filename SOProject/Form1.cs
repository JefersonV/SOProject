using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOProject
{
    public enum Direction
    {
        NS, SN, WE, EW

    }
    public partial class Form1 : Form
    {




        private void a2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void a1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void b3_CheckedChanged(object sender, EventArgs e)
        {
            b3.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void btnParkA1_Click(object sender, EventArgs e)
        {

        }




        public String parkingSpot;





        public Form1()
        {
            InitializeComponent();
            //2 entrance panels
            EnterPanel entranceA, entranceB;
            //24 wait panels
            WaitPanel waitPanel2, waitPanel3, waitPanel4, waitPanel5, waitPanel6, waitPanel8, waitPanel9, waitPanel10, waitPanel11, waitPanel12, waitPanel13, waitPanel14, waitPanel15, waitPanel16, waitPanel17, waitPanel18, waitPanel19, waitPanel20, waitPanel21, waitPanel23, waitPanel24, waitPanel25, waitPanel26, waitPanel27;
            //2 exit
            ExitPanelThread exitC, exitD;
            //11 park panel 
            ParkPanel ParkEA1, ParkEA2, ParkEA3, ParkEA4, ParkEA5, ParkEA6, ParkEB1, ParkEB2, ParkEB4, ParkEB5, ParkEB6;

            //38 semphores
            Semaphore sem1 = new Semaphore();
            Semaphore semp2 = new Semaphore();
            Semaphore semp3 = new Semaphore();
            Semaphore semp4 = new Semaphore();
            Semaphore semp5 = new Semaphore();
            Semaphore semp6 = new Semaphore();
            Semaphore semp7 = new Semaphore();
            Semaphore semp8 = new Semaphore();
            Semaphore semp9 = new Semaphore();
            Semaphore semp10 = new Semaphore();
            Semaphore semp11 = new Semaphore();
            Semaphore sem12 = new Semaphore();
            Semaphore semp13 = new Semaphore();
            Semaphore semp14 = new Semaphore();
            Semaphore semp15 = new Semaphore();
            Semaphore semp16 = new Semaphore();
            Semaphore semp17 = new Semaphore();
            Semaphore semp18 = new Semaphore();
            Semaphore semp19 = new Semaphore();
            Semaphore semp20 = new Semaphore();
            Semaphore semp21 = new Semaphore();
            Semaphore semp23 = new Semaphore();
            Semaphore semp24 = new Semaphore();
            Semaphore semp25 = new Semaphore();
            Semaphore semp26 = new Semaphore();
            Semaphore semp27 = new Semaphore();
            Semaphore semp28 = new Semaphore();
            Semaphore semParkA1 = new Semaphore();
            Semaphore semParkA2 = new Semaphore();
            Semaphore semParkA3 = new Semaphore();
            Semaphore semParkA4 = new Semaphore();
            Semaphore semParkA5 = new Semaphore();
            Semaphore semParkA6 = new Semaphore();
            Semaphore semParkB1 = new Semaphore();
            Semaphore semParkB2 = new Semaphore();
            Semaphore semParkB4 = new Semaphore();
            Semaphore semParkB5 = new Semaphore();
            Semaphore semParkB6 = new Semaphore();


            // 38  buffers
            Buffer buffer1n2 = new Buffer();
            Buffer buffer2n3 = new Buffer();
            Buffer buffer2n8 = new Buffer();
            Buffer buffer3n4 = new Buffer();
            Buffer buffer4n5 = new Buffer();
            Buffer buffer5n6 = new Buffer();
            Buffer buffer6n7 = new Buffer();
            Buffer buffer8n10 = new Buffer();
            Buffer buffer10n11 = new Buffer();
            Buffer buffer20n15 = new Buffer();
            Buffer buffer15n16 = new Buffer();
            Buffer nullBuffer = new Buffer();
            Buffer bufferA1 = new Buffer();
            Buffer bufferA2 = new Buffer();
            Buffer bufferA3 = new Buffer();
            Buffer bufferA4 = new Buffer();
            Buffer bufferA5 = new Buffer();
            Buffer bufferA6 = new Buffer();
            Buffer buffer11n12 = new Buffer();
            Buffer buffer12n13 = new Buffer();
            Buffer buffer13n14 = new Buffer();
            Buffer buffer14n9 = new Buffer();
            Buffer buffer22n23 = new Buffer();
            Buffer buffer23n24 = new Buffer();
            Buffer buffer23n20 = new Buffer();
            Buffer buffer24n25 = new Buffer();
            Buffer bufferB1 = new Buffer();
            Buffer bufferB2 = new Buffer();
            Buffer bufferB4 = new Buffer();
            Buffer bufferB5 = new Buffer();
            Buffer bufferB6 = new Buffer();
            Buffer buffer25n26 = new Buffer();
            Buffer buffer26n27 = new Buffer();
            Buffer buffer27n28 = new Buffer();
            Buffer buffer16n17 = new Buffer();
            Buffer buffer17n18 = new Buffer();
            Buffer buffer18n19 = new Buffer();
            Buffer buffer19n21 = new Buffer();



            //enternace panels 
            entranceA = new EnterPanel(new Point(50, -10), 50, Direction.NS, panel1, semp2, buffer1n2, btnA, pa1, ha1, pa2, pa3, pa4, pa5, "b", pab6, pab7, pab8, 1);
            //a and b for the extra fucntionality sections !
            entranceB = new EnterPanel(new Point(51, -10), 50, Direction.NS, panel22, semp23, buffer22n23, btnB, pb9, ha2, b3, pb6, pb7, pb8, "a", pba3, pba4, pba5, 22);

            //park panels stuffs
            ParkEA1 = new ParkPanel(new Point(-12, 25), 60, Direction.WE, panelA1, Color.Red, semParkA1, semp3, bufferA1, buffer2n3, btnParkA1, 9);
            ParkEA2 = new ParkPanel(new Point(-12, 25), 60, Direction.WE, panelA2, Color.Red, semParkA2, semp4, bufferA2, buffer3n4, btnParkA2, 10);
            ParkEA3 = new ParkPanel(new Point(-12, 25), 60, Direction.WE, panelA3, Color.Red, semParkA3, semp5, bufferA3, buffer4n5, btnParkA3, 11);
            ParkEA4 = new ParkPanel(new Point(82, 25), 60, Direction.EW, panelA4, Color.Red, semParkA4, semp11, bufferA4, buffer10n11, btnParkA4, 13);

            ParkEA5 = new ParkPanel(new Point(82, 25), 60, Direction.EW, panelA5, Color.Red, semParkA5, sem12, bufferA5, buffer11n12, btnParkA5, 14);

            ParkEA6 = new ParkPanel(new Point(82, 25), 60, Direction.EW, panelA6, Color.Red, semParkA6, semp13, bufferA6, buffer12n13, btnParkA6, 15);




            //none because not parking anywahwere
            waitPanel2 = new WaitPanel(new Point(50, -15), 40, Direction.NS, this.panel2, Color.White, semp2, semp3, sem1, semParkA1, buffer1n2, buffer2n3, nullBuffer, "null", "nexta1", true, semp8, buffer2n8, 2); // extra buf n sema for panel 8 turning point
            //null buffer = parkbuffer
            waitPanel3 = new WaitPanel(new Point(50, -10),
                                     50, Direction.NS, this.panel3,
                                     Color.White,
                                     semp3,
                                     semp4,
                                     semParkA1,
                                     semParkA2,
                                     buffer2n3, buffer3n4, bufferA1, "a1", "nexta2", 3);

            waitPanel4 = new WaitPanel(new Point(50, -10),
                                     50, Direction.NS, this.panel4,
                                     Color.White,
                                     semp4,
                                     semp5,
                                     semParkA2,
                                     semParkA3,
                                     buffer3n4, buffer4n5, bufferA2, "a2", "nexta3", 4);

            waitPanel5 = new WaitPanel(new Point(50, -10),
                                     50, Direction.NS, this.panel5,
                                     Color.White,
                                     semp5,
                                     semp6,
                                     semParkA3,
                                     sem1,
                                     buffer4n5, buffer5n6, bufferA3, "a3", "null", 5);

            waitPanel6 = new WaitPanel(new Point(50, -10),
                                     50, Direction.NS, panel6,
                                     Color.White,
                                     semp6,
                                     semp7,
                                     sem1,
                                     sem1,
                                     buffer5n6, buffer6n7, nullBuffer, "null", "null", 6);
            exitC = new ExitPanelThread(new Point(50, -10),
                                     40, Direction.NS, panel7,
                                     Color.White,
                                     semp7,
                                     buffer6n7, 7);

            waitPanel8 = new WaitPanel(new Point(-28, 25),
                                     50, Direction.WE, panel8,
                                     Color.White,
                                     semp8,
                                     semp10,
                                     sem1,
                                     sem1,
                                     buffer2n8, buffer8n10, nullBuffer, "null", "null", 8);
            waitPanel10 = new WaitPanel(new Point(17, -10),
                                      50, Direction.NS, panel10,
                                      Color.PeachPuff,
                                      semp10,
                                      semp11,
                                      sem1,
                                      semParkA4,
                                      buffer8n10, buffer10n11, nullBuffer, "null", "nexta4", true, 'a', semp16, buffer15n16, semParkB4, 16);
            waitPanel11 = new WaitPanel(new Point(17, -10),
                                     50, Direction.NS, panel11,
                                     Color.White,
                                     semp11,
                                     sem12,
                                     semParkA4,
                                     semParkA5,
                                     buffer10n11, buffer11n12, bufferA4, "a4", "nexta5", 17);

            waitPanel12 = new WaitPanel(new Point(17, -10),
                                     50, Direction.NS, panel12,
                                     Color.White,
                                     sem12,
                                     semp13,
                                     semParkA5,
                                     semParkA6,
                                     buffer11n12, buffer12n13, bufferA5, "a5", "nexta6", 18);

            waitPanel13 = new WaitPanel(new Point(17, -10),
                                     50, Direction.NS, panel13,
                                     Color.White,
                                     semp13,
                                     semp14,
                                     semParkA6,
                                     sem1,
                                     buffer12n13, buffer13n14, bufferA6, "a6", "null", 19);

            waitPanel14 = new WaitPanel(new Point(17, -10),
                                     50, Direction.NS, panel14,
                                     Color.White,
                                     semp14,
                                     semp9,
                                     sem1,
                                     sem1,
                                     buffer13n14, buffer14n9, nullBuffer, "null", "null", 20);
            waitPanel9 = new WaitPanel(new Point(165, 25),
                                     50, Direction.EW, panel9,
                                     Color.White,
                                     semp9,
                                     semp6,
                                     sem1,
                                     sem1,
                                     buffer14n9, buffer5n6, nullBuffer, "null", "null", 12);


            //right
            waitPanel23 = new WaitPanel(new Point(51, -10),
                                 40, Direction.NS, panel23,
                                 Color.White,
                                 semp23,
                                 semp24,
                                 sem1,
                                 semParkB1,
                                 buffer22n23, buffer23n24, nullBuffer, "null", "nextb1", true, semp20, buffer23n20, 34);
            waitPanel24 = new WaitPanel(new Point(51, -10),
                                     50, Direction.NS, panel24,
                                     Color.White,
                                     semp24,
                                     semp25,
                                     semParkB1,
                                     semParkB2,
                                     buffer23n24, buffer24n25, bufferB1, "b1", "nextb2", 35);
            ParkEB1 = new ParkPanel(new Point(82, 25),
                                     60, Direction.EW, panelB1,
                                     Color.Red,
                                     semParkB1,
                                     semp24,
                                     bufferB1, buffer23n24, btnParkB1, 31);
            waitPanel25 = new WaitPanel(new Point(51, -10),
                                     50, Direction.NS, panel25,
                                     Color.White,
                                     semp25,
                                     semp26,
                                     semParkB2,
                                     sem1,
                                     buffer24n25, buffer25n26, bufferB2, "b2", "none", 36);
            ParkEB2 = new ParkPanel(new Point(82, 25),
                                     60, Direction.EW, panelB2,
                                     Color.Red,
                                     semParkB2,
                                     semp25,
                                     bufferB2, buffer24n25, btnParkB2, 32);
            waitPanel26 = new WaitPanel(new Point(51, -10),
                                     50, Direction.NS, panel26,
                                     Color.White,
                                     semp26,
                                     semp27,
                                     sem1,
                                     sem1,
                                     buffer25n26, buffer26n27, nullBuffer, "null", "null", 37);
            waitPanel27 = new WaitPanel(new Point(51, -10),
                                     50, Direction.NS, panel27,
                                     Color.White,
                                     semp27,
                                     semp28,
                                     sem1,
                                     sem1,
                                     buffer26n27, buffer27n28, nullBuffer, "null", "null", 38);
            exitD = new ExitPanelThread(new Point(51, -10),
                                     40, Direction.NS, panel28,
                                     Color.White,
                                     semp28,
                                     buffer27n28, 39);
            //20
            waitPanel20 = new WaitPanel(new Point(165, 25),
                                     50, Direction.EW, panel20,
                                     Color.White,
                                     semp20,
                                     semp15,
                                     sem1,
                                     sem1,
                                     buffer23n20, buffer20n15, nullBuffer, "null", "null", 26);
            waitPanel15 = new WaitPanel(new Point(17, -10),
                                      50, Direction.NS, panel15,
                                      Color.White,
                                      semp15,
                                      semp16,
                                      sem1,
                                      semParkB4,
                                      buffer20n15, buffer15n16, nullBuffer, "null", "nextb4", true, 'b', semp11, buffer10n11, semParkA4, 21
                                      );
            waitPanel16 = new WaitPanel(new Point(18, -10),
                                      50, Direction.NS, panel16,
                                      Color.White,
                                      semp16,
                                      semp17,
                                      semParkB4,
                                      semParkB5,
                                      buffer15n16, buffer16n17, bufferB4, "b4", "nextb5", 22
                                      );
            ParkEB4 = new ParkPanel(new Point(-12, 25),
                                     60, Direction.WE, panelB4,
                                     Color.Red,
                                     semParkB4,
                                     semp16,
                                     bufferB4, buffer15n16, btnParkB4, 27);
            waitPanel17 = new WaitPanel(new Point(18, -10),
                                      50, Direction.NS, panel17,
                                      Color.White,
                                      semp17,
                                      semp18,
                                      semParkB5,
                                      semParkB6,
                                      buffer16n17, buffer17n18, bufferB5, "b5", "nextb6"
                                      , 23);
            ParkEB5 = new ParkPanel(new Point(-12, 25),
                                     60, Direction.WE, panelB5,
                                     Color.Red,
                                     semParkB5,
                                     semp17,
                                     bufferB5, buffer16n17, btnParkB5, 28);
            waitPanel18 = new WaitPanel(new Point(18, -10),
                                      50, Direction.NS, panel18,
                                      Color.White,
                                      semp18,
                                      semp19,
                                      semParkB6,
                                      sem1,
                                      buffer17n18, buffer18n19, bufferB6, "b6", "null"
                                      , 24);
            ParkEB6 = new ParkPanel(new Point(-12, 25),
                                     60, Direction.WE, panelB6,
                                     Color.Red,
                                     semParkB6,
                                     semp18,
                                     bufferB6, buffer17n18, btnParkB6, 29);
            waitPanel19 = new WaitPanel(new Point(18, -10),
                                      50, Direction.NS, panel19,
                                      Color.White,
                                      semp19,
                                      semp21,
                                      sem1,
                                      sem1,
                                      buffer18n19, buffer19n21, nullBuffer, "null", "null", 25
                                      );

            waitPanel21 = new WaitPanel(new Point(-28, 25),
                                     50, Direction.WE, panel21,
                                     Color.White,
                                     semp21,
                                     semp27,
                                     sem1,
                                     sem1,
                                     buffer19n21, buffer26n27, nullBuffer, "null", "null", 30);






            //39 threads
            Thread entAThread = new Thread(new ThreadStart(entranceA.Start));
            Thread thread2 = new Thread(new ThreadStart(waitPanel2.Start));
            Thread thread3 = new Thread(new ThreadStart(waitPanel3.Start));
            Thread exit1Thread = new Thread(new ThreadStart(exitC.Start));
            Thread parkA1Thread = new Thread(new ThreadStart(ParkEA1.Start));
            Thread thread4 = new Thread(new ThreadStart(waitPanel4.Start));
            Thread parkA2Thread = new Thread(new ThreadStart(ParkEA2.Start));
            Thread thread5 = new Thread(new ThreadStart(waitPanel5.Start));
            Thread parkA3Thread = new Thread(new ThreadStart(ParkEA3.Start));
            Thread thread6 = new Thread(new ThreadStart(waitPanel6.Start));
            Thread thread8 = new Thread(new ThreadStart(waitPanel8.Start));
            Thread thread10 = new Thread(new ThreadStart(waitPanel10.Start));
            Thread thread11 = new Thread(new ThreadStart(waitPanel11.Start));
            Thread parkA4Thread = new Thread(new ThreadStart(ParkEA4.Start));
            Thread thread12 = new Thread(new ThreadStart(waitPanel12.Start));
            Thread parkA5Thread = new Thread(new ThreadStart(ParkEA5.Start));
            Thread thread13 = new Thread(new ThreadStart(waitPanel13.Start));
            Thread parkA6Thread = new Thread(new ThreadStart(ParkEA6.Start));
            Thread thread14 = new Thread(new ThreadStart(waitPanel14.Start));
            Thread thread9 = new Thread(new ThreadStart(waitPanel9.Start));



            Thread entBThread = new Thread(new ThreadStart(entranceB.Start));
            Thread thread22 = new Thread(new ThreadStart(waitPanel23.Start));
            Thread thread23 = new Thread(new ThreadStart(waitPanel24.Start));
            Thread thread24 = new Thread(new ThreadStart(ParkEB1.Start));
            Thread thread25 = new Thread(new ThreadStart(waitPanel25.Start));
            Thread thread26 = new Thread(new ThreadStart(ParkEB2.Start));
            Thread thread27 = new Thread(new ThreadStart(waitPanel26.Start));
            Thread thread28 = new Thread(new ThreadStart(waitPanel27.Start));
            Thread thread29 = new Thread(new ThreadStart(exitD.Start));
            Thread thread30 = new Thread(new ThreadStart(waitPanel20.Start));
            Thread thread31 = new Thread(new ThreadStart(waitPanel15.Start));
            Thread thread32 = new Thread(new ThreadStart(waitPanel16.Start));
            Thread thread33 = new Thread(new ThreadStart(ParkEB4.Start));
            Thread thread34 = new Thread(new ThreadStart(waitPanel17.Start));
            Thread thread35 = new Thread(new ThreadStart(ParkEB5.Start));
            Thread thread36 = new Thread(new ThreadStart(waitPanel18.Start));
            Thread thread37 = new Thread(new ThreadStart(ParkEB6.Start));
            Thread thread38 = new Thread(new ThreadStart(waitPanel19.Start));
            Thread thread39 = new Thread(new ThreadStart(waitPanel21.Start));



            entAThread.Start();
            thread2.Start();
            thread3.Start();
            exit1Thread.Start();
            parkA1Thread.Start();
            thread4.Start();
            parkA2Thread.Start();
            thread5.Start();
            parkA3Thread.Start();
            thread6.Start();
            thread8.Start();
            thread10.Start();
            thread11.Start();
            parkA4Thread.Start();
            thread12.Start();
            parkA5Thread.Start();
            thread13.Start();
            parkA6Thread.Start();
            thread14.Start();
            thread9.Start();
            entBThread.Start();
            thread22.Start();
            thread23.Start();
            thread24.Start();
            thread25.Start();
            thread26.Start();
            thread27.Start();
            thread28.Start();
            thread29.Start();
            thread30.Start();
            thread31.Start();
            thread32.Start();
            thread33.Start();
            thread34.Start();
            thread35.Start();
            thread36.Start();
            thread37.Start();
            thread38.Start();
            thread39.Start();



            this.Closing += new CancelEventHandler(this.Form1_Closing);
        }
        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            // Stops all threads to completely stop the program on Exiting the form
            Environment.Exit(Environment.ExitCode);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

