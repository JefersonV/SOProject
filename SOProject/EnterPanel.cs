using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOProject
{
    class EnterPanel : AbstractSectionPanel
    {
        private int delay;
        private Panel panel;


        private Color colour;

        private Semaphore semaphore;
        private Buffer buffer;
        private Button btn;
        private bool locked = true;



        public String nextLot;
        RadioButton r1, r2, r3, r4, r5, r6, rNextSec1, rNextSec2, rNextSec3;






        //generate a  random colour and return the colour
        public Color randomColourGen()
        {

            Random random = new Random();
            return Color.FromArgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
        }



        public EnterPanel(Point origin,
                                 int delay,
                                 Direction dir,
                                 Panel panel,
                                 Semaphore semaphore,
                                 Buffer buffer,
                                 Button btn,
            RadioButton p1, RadioButton p2, RadioButton p3, RadioButton p4, RadioButton p5, RadioButton p6, String nextSec, RadioButton extra4, RadioButton extra5, RadioButton extra6, int panelNum)
        {
            this.origin = origin;
            this.delay = delay;
            this.dir = dir;
            this.panel = panel;
            this.car = origin;
            this.panel.Paint += new PaintEventHandler(this.panel_Paint);
            this.panelNum = panelNum;
            //update directoionss
            switch (dir)
            {
                case Direction.NS:
                    this.xDelta = 0;
                    this.yDelta = 2;
                    break;

                case Direction.WE:
                    this.xDelta = 10;
                    this.yDelta = 0;
                    break;

                case Direction.EW:
                    this.xDelta = -10;
                    this.yDelta = 0;
                    break;

                default:

                    break;
            }



            this.semaphore = semaphore;
            this.buffer = buffer;
            this.btn = btn;
            this.r1 = p1;
            this.r2 = p2;
            this.r3 = p3;
            this.r4 = p4;
            this.r5 = p5;
            this.r6 = p6;
            this.nextLot = nextSec;
            this.rNextSec1 = extra4;
            this.rNextSec2 = extra5;
            this.rNextSec3 = extra6;
            this.btn.Click += new System.
                                  EventHandler(this.btn_Click);


        }


        private void btn_Click(object sender,
                               System.EventArgs e)
        {
            locked = !locked;
            lock (this)
            {
                if (!locked)
                {
                    Monitor.Pulse(this);
                }
            }

            //changing the colour of the button after click
            this.btn.BackColor = Color.Aquamarine;

        }


        public override void Start()
        {
            Thread.Sleep(delay);


            for (;;)//infin forloopd
            {
                //Rand col
                colour = randomColourGen();
                destination = "Exit";

                this.zeroCar();

                //speed set
                delay = 50;

                panel.Invalidate();
                lock (this)
                {
                    while (locked)
                    {
                        Monitor.Wait(this);
                    }
                }



                //entrance b has been initialised to origin point of 51
                if (r1.Checked)
                {
                    destination = origin.X == 51 ? "b1" : "a1";
                }
                if (r2.Checked)
                {
                    destination = origin.X == 51 ? "b2" : "a2";
                }
                if (r3.Checked)
                {
                    destination = origin.X == 51 ? "b3" : "a3";
                }
                if (r4.Checked)
                {
                    destination = origin.X == 51 ? "b4" : "a4";

                }
                if (r5.Checked)
                {
                    destination = origin.X == 51 ? "b5" : "a5";
                }
                if (r6.Checked)
                {
                    destination = origin.X == 51 ? "b6" : "a6";
                }
                if (rNextSec1.Checked)
                {
                    destination = nextLot + 4;
                    delay = 60;
                }
                if (rNextSec2.Checked)
                {
                    destination = nextLot + 5;
                    delay = 60;
                }
                if (rNextSec3.Checked)
                {
                    destination = nextLot + 6;
                    delay = 60;
                }


                //length of panel is 32
                for (int i = 1; i <= 32; i++)
                {

                    this.moveCar(xDelta, yDelta);
                    Thread.Sleep(delay);

                    //panel.Invalidate();
                }

                //locking mechanism with semaphore
                semaphore.Wait();
                //locked true bcz if not infinite no of cars come
                locked = true;


                //writing buffer
                buffer.WriteColour(this.colour);
                buffer.WriteDelay(this.delay);
                buffer.WriteDestination(this.destination);
            }

            panel.Invalidate();

        }

        private void zeroCar()
        {
            car.X = origin.X;
            car.Y = origin.Y;
        }

        private void moveCar(int xDelta, int yDelta)
        {
            car.X += xDelta; car.Y += yDelta;
            panel.Invalidate();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush brush = new SolidBrush(colour);

            SolidBrush blackBrush = new SolidBrush(Color.White);

            g.FillRectangle(brush, car.X, car.Y, 10, 10);


            brush.Dispose();    //  Dispose graphics resources. 
            g.Dispose();        //  
        }
    }// end class 
}
