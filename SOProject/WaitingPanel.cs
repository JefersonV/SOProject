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
    class WaitPanel : AbstractSectionPanel
    {

        private int delay;
        private Panel panel;


        private Color colour;

        private Semaphore sem1;
        private Semaphore sem2;
        private Semaphore parkSem;
        private Semaphore semNextDestination;
        private Semaphore semExtra;
        private Semaphore turnSemaphore;
        private Buffer readBuffer;
        private Buffer writeBuffer;
        private Buffer parkBuffer;
        private Buffer turnBuffer;
        private String panelParkSpot;
        private String parkingspot;
        private String nextSpot;

        private bool turn = false;
        private bool isPassing = false;


        private char laneName;





        public WaitPanel(Point origin,
                           int delay,
                           Direction dir,
                           Panel panel,
                           Color colour,
                           Semaphore semaphore,
                           Semaphore semaphore2,
                           Semaphore parkSemaphore,
                           Semaphore nextSlot,
                           Buffer buffer,
                           Buffer buffer2,
                           Buffer parkBuffer,
                           String panelParkSpot,
                           String nextSpot,
                           int panelNum)
        {
            this.origin = origin;
            this.delay = delay;
            this.nextSpot = nextSpot;
            this.parkBuffer = parkBuffer;
            this.semNextDestination = nextSlot;//semaphore
            this.panelParkSpot = panelParkSpot;
            this.dir = dir;
            this.parkSem = parkSemaphore;

            this.panel = panel;
            this.colour = colour;
            this.car = origin;
            this.panelNum = panelNum;
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
            this.sem1 = semaphore;
            this.sem2 = semaphore2;
            this.readBuffer = buffer;
            this.writeBuffer = buffer2;

        }

        //Overloaded constructor for the panels which turn inside the parking lot ... for panel 2
        //4 buffers and 5 semaphoire for panel 2 ..reading from entrance buffer,writing to panel 2s shared buffer,one buffer for parked in destination 1,alternatiev buffer for turning if destination is elsewhere
        public WaitPanel(Point origin,
                           int delay,
                           Direction dir,
                           Panel panel,
                           Color colour,
                           Semaphore semaphore,
                           Semaphore semaphore2,
                           Semaphore parkSemaphore,
                           Semaphore nextSlot,
                           Buffer buffer,
                           Buffer buffer2,
                           Buffer parkBuffer,
                           String panelParkSpot,
                           String nextSpot,
                           bool isTurn,
                           Semaphore altSem,
                           Buffer altBuf, int panelNum)
        {
            this.origin = origin;
            this.delay = delay;
            this.nextSpot = nextSpot;
            this.parkBuffer = parkBuffer;
            this.semNextDestination = nextSlot;
            this.panelParkSpot = panelParkSpot;
            this.dir = dir;
            this.parkSem = parkSemaphore;
            this.turn = isTurn;

            this.panel = panel;
            this.colour = colour;
            this.car = origin;
            this.turnSemaphore = altSem;
            this.turnBuffer = altBuf;
            this.panelNum = panelNum;

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
            this.sem1 = semaphore;
            this.sem2 = semaphore2;
            this.readBuffer = buffer;
            this.writeBuffer = buffer2;

        }

        //overlaoded Constructor for passing from different entrance

        public WaitPanel(Point origin,
                             int delay,
                             Direction dir,
                             Panel panel,
                            Color colour,
                             Semaphore semaphore,
                             Semaphore semaphore2,
                             Semaphore parkSemaphore,
                             Semaphore nextSlot,
                             Buffer buffer,
                             Buffer buffer2,
                             Buffer parkBuffer,
                             String panelParkSpot,
                             String nextSpot,
                             bool isPassing,
                             char laneName,
                             Semaphore tSem,
                             Buffer tBuf,
                             Semaphore sem5,
                             int panelNum)
        {
            this.origin = origin;
            this.delay = delay;
            this.nextSpot = nextSpot;
            this.parkBuffer = parkBuffer;
            this.semNextDestination = nextSlot;
            this.panelParkSpot = panelParkSpot;
            this.dir = dir;
            this.parkSem = parkSemaphore;
            this.isPassing = isPassing;
            this.laneName = laneName;
            this.semExtra = sem5;
            this.panel = panel;
            this.colour = colour;
            this.car = origin;
            this.turnSemaphore = tSem;
            this.turnBuffer = tBuf;
            this.panelNum = panelNum;

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
            this.sem1 = semaphore;
            this.sem2 = semaphore2;
            this.readBuffer = buffer;
            this.writeBuffer = buffer2;

        }


        public override void Start()
        {
            //
            //if (panelNum == 16 || panelNum == 21)
            //{
            //    this.xDelta = 0;
            //    this.yDelta = 30;
            //    this.colour = Color.PeachPuff;

            //    panel.Invalidate();

            //}
            for (;;)//infinite for loop  continue
            {
                sem1.Signal();
                this.initCar();//make car 0



                //read from previous written panels buffer
                readBuffer.ReadColour(ref this.colour);
                readBuffer.ReadDelay(ref this.delay);
                readBuffer.ReadPark(ref this.parkingspot);
                //readall
                //semaphore.isRunning = true;


                // If the car is going to park in the next destination
                if (String.Compare(parkingspot, panelParkSpot) == 0)
                {
                    for (int i = 1; i <= 22; i++)//22 bcz size
                    {
                        panel.Invalidate();
                        this.moveCar(xDelta, yDelta);
                        Thread.Sleep(delay);
                    }
                    //store in temp x n y points
                    int tempStoreX = this.xDelta;
                    int tempStoreY = this.yDelta;

                    this.xDelta = origin.X == 17 || origin.X == 51 ? -10 : 10;
                    this.yDelta = 0;

                    //for moving into slot,(can be either right or left )before goign itno the parkign slot  if parking slot is the same
                    for (int i = 1; i < 7; i++)
                    {
                        panel.Invalidate();
                        this.moveCar(xDelta, yDelta);

                        Thread.Sleep(delay);
                    }
                    this.xDelta = tempStoreX;
                    this.yDelta = tempStoreY;

                    //store the car object details in the buffer
                    parkSem.Wait();
                    parkBuffer.WriteColour(this.colour);
                    parkBuffer.WriteDelay(this.delay);
                    parkBuffer.WriteDestination(this.parkingspot);
                    panel.Invalidate();
                }
                // If the car isn't parking here
                else
                {

                    //if car is going to panel by turning
                    if (turn && ((parkingspot == "a4") || (parkingspot == "a5") || (parkingspot == "a6") || (parkingspot == "b4") || (parkingspot == "b5") || (parkingspot == "b6")))
                    {


                        for (int i = 1; i <= 22; i++)//bcz size 22
                        {
                            panel.Invalidate();
                            this.moveCar(xDelta, yDelta);
                            Thread.Sleep(delay);
                        }

                        int tempStoreX = this.xDelta;
                        int tempStoreY = this.yDelta;
                        //if entrance B minus 51 update x coordinate
                        this.xDelta = origin.X == 51 ? -10 : 10;
                        this.yDelta = 0;
                        for (int i = 1; i < 6; i++)
                        {
                            panel.Invalidate();
                            this.moveCar(xDelta, yDelta);
                            Thread.Sleep(delay);
                        }
                        this.xDelta = tempStoreX;
                        this.yDelta = tempStoreY;

                        //write in the turning points buffer
                        turnSemaphore.Wait();
                        turnBuffer.WriteColour(this.colour);
                        turnBuffer.WriteDelay(this.delay);
                        turnBuffer.WriteDestination(this.parkingspot);
                        panel.Invalidate();
                    }

                    // If it is going from entrance A to Entrance b site or vice versa
                    else if ((isPassing) && !(this.parkingspot[0] == laneName))
                    {
                        for (int i = 1; i <= 32; i++)
                        {
                            panel.Invalidate();
                            this.moveCar(xDelta, yDelta);
                            Thread.Sleep(delay);
                        }
                        // If it is parking in the 4th slot, make sure it is free first.
                        //this is for the next sections ones only
                        if (this.parkingspot[1] == '4')
                        {

                            //Boolean check = false;
                            //while (turnSemaphore.isRunning)
                            //{
                            //    check = true;
                            //    Thread.Sleep(1000);
                            //}

                            //while (extraCheck.isRunning)
                            //{
                            //    check = true;
                            //    Thread.Sleep(1000);
                            //}

                            //if (check)
                            //{
                            //    Thread.Sleep(10000);
                            //}

                            //write the turn to the turnbuffer
                            semExtra.Wait();
                            turnBuffer.WriteColour(this.colour);
                            turnBuffer.WriteDelay(this.delay);
                            turnBuffer.WriteDestination(this.parkingspot);
                            panel.Invalidate();
                            semExtra.Signal();

                        }
                        else
                        {
                            turnSemaphore.Wait();
                            turnBuffer.WriteColour(this.colour);
                            turnBuffer.WriteDelay(this.delay);
                            turnBuffer.WriteDestination(this.parkingspot);
                            panel.Invalidate();

                        }

                    }
                    // If the car is not turning inside the parking lot
                    else
                    {

                        //If it is a straight line turn move less
                        //panel 21,20,8,9
                        if (origin.X == -28 || origin.X == 165)
                        {

                            for (int i = 1; i <= 17; i++)
                            {
                                panel.Invalidate();
                                this.moveCar(xDelta, yDelta);
                                Thread.Sleep(delay);
                            }
                        }
                        //If it is not a horizontal turning panel
                        else
                        {
                            //If the car is just coming out of a parking spot
                            if (this.parkingspot == "Turn")
                            {
                                panel.Invalidate();
                                Point tempPoint = this.origin;
                                if (tempPoint.X == 50)
                                    this.origin = new Point(90, 29);
                                else if (tempPoint.X == 18)
                                    this.origin = new Point(50, 29);
                                else if (tempPoint.X == 17)
                                    this.origin = new Point(-15, 29);
                                else if (tempPoint.X == 51)
                                    this.origin = new Point(10, 29);


                                initCar();
                                int xTemp = this.xDelta;
                                int yTemp = this.yDelta;
                                this.xDelta = tempPoint.X == 50 || tempPoint.X == 18 ? -4 : 4;
                                this.yDelta = 0;
                                int move = tempPoint.X == 17 || tempPoint.X == 18 ? 9 : 11;
                                for (int i = 1; i < move; i++)
                                {
                                    panel.Invalidate();
                                    this.moveCar(xDelta, yDelta);
                                    Thread.Sleep(delay);
                                }
                                this.xDelta = xTemp;
                                this.yDelta = yTemp;
                                for (int i = 1; i < 15; i++)
                                {
                                    panel.Invalidate();
                                    this.moveCar(xDelta, yDelta);
                                    Thread.Sleep(delay);
                                }
                                this.origin = tempPoint;
                                this.parkingspot = "Exit";
                            }
                            //If the car isn't coming out of a parking slot and is moving normally
                            else
                            {
                                for (int i = 1; i <= 32; i++)
                                {
                                    panel.Invalidate();
                                    this.moveCar(xDelta, yDelta);
                                    Thread.Sleep(delay);
                                }
                            }

                        }
                        // Is the current car trying to park in the panel two spots ahead, if empty write to next buffer
                        String check = "next" + this.parkingspot;
                        if (String.Compare(check, nextSpot) == 0)
                        {
                            //bool chk2 = false;
                            //while (semaphore2.isRunning)
                            //{
                            //    Thread.Sleep(1000);
                            //    chk2 = true;
                            //}
                            //while (nextSlot.isRunning)
                            //{
                            //    Thread.Sleep(1000);
                            //    chk2 = true;
                            //}
                            //if (chk2)
                            //{
                            //    Thread.Sleep(1000);
                            //}

                            semNextDestination.Wait();

                            writeBuffer.WriteColour(this.colour);
                            writeBuffer.WriteDelay(this.delay);
                            writeBuffer.WriteDestination(this.parkingspot);
                            panel.Invalidate();

                            semNextDestination.Signal();
                        }
                        // If the car isn't trying to park in the next spot as in just moving normally
                        else
                        {
                            sem2.Wait();
                            writeBuffer.WriteColour(this.colour);
                            writeBuffer.WriteDelay(this.delay);
                            writeBuffer.WriteDestination(this.parkingspot);
                            panel.Invalidate();
                        }
                    }
                }
                sem1.isRunning = false;
                //this.colour = Color.White;
                panel.Invalidate();
            }
            this.colour = Color.Orange;
            panel.Invalidate();
            //semaphore.Signal();
        }

        private void initCar()
        {
            car.X = origin.X;
            car.Y = origin.Y;
        }

        private void moveCar(int xDelta, int yDelta)
        {
            car.X += xDelta;
            car.Y += yDelta;
        }


        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(colour);
            SolidBrush b = new SolidBrush(Color.White);
            g.FillRectangle(brush, car.X, car.Y, 10, 10);
            brush.Dispose();
            b.Dispose();
            g.Dispose();
        }
    }// end class 
}
