using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SOProject
{
    class ExitPanelThread : AbstractSectionPanel
    {

        private int delay;
        private Panel panel;


        private Color colour;


        private Semaphore semaphore;
        private Buffer buffer;
        private String parkingspot;
        public Car cars;

        public ExitPanelThread(Point origin,
                           int delay,
                           Direction dir,
                           Panel panel,
                           Color colour,
                           Semaphore semaphore,
                           Buffer buffer,
                           int panelNum)
        {
            this.origin = origin;
            this.delay = delay;
            this.dir = dir;

            this.panel = panel;
            this.colour = colour;
            this.car = origin;
            this.panel.Paint += new PaintEventHandler(this.panel_Paint);



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
            this.panelNum = panelNum;
        }





        public override void Start()
        {

            //Thread.Sleep(delay);
            this.colour = Color.White;

            for (;;)
            {
                semaphore.Signal();
                this.resetCar();


                buffer.ReadColour(ref this.colour);
                buffer.ReadDelay(ref this.delay);
                buffer.ReadPark(ref this.parkingspot);

                //buffer.readALL(ref this.colour, ref this.delay, ref this.parkingspot);

                for (int i = 1; i <= 38; i++)
                {

                    panel.Invalidate();
                    this.moveCar(xDelta, yDelta);
                    Thread.Sleep(delay);

                }
                this.colour = Color.White;
                panel.Invalidate();


            }
            this.colour = Color.Gray;
            panel.Invalidate();
        }


        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(colour);
            SolidBrush b = new SolidBrush(Color.White);
            g.FillRectangle(brush, car.X, car.Y, 10, 10);

            brush.Dispose();    //  Dispose graphics resources. 
            g.Dispose();        //  
        }
    }// end class WaitPanelThread
}
