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
    class ParkPanel : AbstractSectionPanel
    {
        //private Point origin;
        private int delay;
        private Panel panel;

        private Color colour;


        private Boolean locked = true;
        private Semaphore semaphore;
        private Semaphore semaphore2;
        private Buffer buffer;
        private Buffer buffer2;
        private String parkingspot;
        private Button btn;
        private Color fontColor;




        public ParkPanel(Point origin,
                           int delay,

                           Direction dir,
                           Panel panel,
                           Color colour,
                           Semaphore semaphore,
                           Semaphore semaphore2,
                           Buffer buffer,
                           Buffer buffer2,
                           Button btn,
                           int panelNum)
        {
            this.origin = origin;
            this.delay = delay;

            this.dir = dir;
            this.btn = btn;


            this.panel = panel;
            this.colour = colour;
            this.car = origin;




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
            this.panel.Paint += new PaintEventHandler(this.panel_Paint);
            //this.xDelta = westEast ? +10 : -10;
            //this.yDelta = 0;
            this.semaphore = semaphore;
            this.semaphore2 = semaphore2;
            this.buffer = buffer;
            this.buffer2 = buffer2;
            this.btn.Click += new System.
                                  EventHandler(this.btn_Click);
            this.panelNum = panelNum;
        }
        private void btn_Click(object sender,
                              System.EventArgs e)
        {
            if (btn.BackColor == Color.Green)
                MessageBox.Show("Empty Car Park slot!");

            locked = !locked;
            lock (this)
            {

                if (!locked)
                {
                    Monitor.Pulse(this);

                }
            }
        }

        public override void Start()
        {


            for (;;)
            {
                semaphore.Signal();
                this.resetCar();
                this.fontColor = Color.White;
                buffer.ReadColour(ref this.colour);
                buffer.ReadDelay(ref this.delay);
                buffer.ReadPark(ref this.parkingspot);

                //buffer.readALL(ref this.colour, ref this.delay, ref this.parkingspot);

                //returning movement change <---
                this.xDelta = origin.X == -12 ? 10 : -10;
                for (int i = 1; i <= 7; i++)
                {
                    panel.Invalidate();
                    this.moveCar(xDelta, yDelta);
                    Thread.Sleep(delay);
                    //delay bit for parkign time
                    Thread.Sleep(100);

                }
                btn.BackColor = Color.Red;
                locked = true;
                lock (this)
                {
                    while (locked)
                    {
                        Monitor.Wait(this);
                    }
                }
                //returning movement change -->
                this.xDelta = origin.X == 82 ? 10 : -10;
                for (int i = 1; i <= 5; i++)
                {
                    panel.Invalidate();
                    this.moveCar(xDelta, yDelta);
                    Thread.Sleep(delay);
                    //manual delay for parkign time
                    Thread.Sleep(100);
                }
                //this.xDelta = -10;
                this.fontColor = Color.FromArgb(0, 100, 100, 100);
                semaphore2.Wait();
                btn.BackColor = Color.Green;

                buffer2.WriteColour(this.colour);
                buffer2.WriteDelay(this.delay);
                buffer2.WriteDestination("Turn");//
                locked = true;

                panel.Invalidate();

                //this.colour = Color.White;

            }
            this.colour = Color.FromArgb(0, 100, 100, 100);

            panel.Invalidate();
            //semaphore.Signal();
        }



        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(colour);
            SolidBrush b = new SolidBrush(fontColor);
            g.FillRectangle(brush, car.X, car.Y, 10, 10);

            brush.Dispose();
            b.Dispose();
            g.Dispose();
        }
    }// end class Parlpanel
}
