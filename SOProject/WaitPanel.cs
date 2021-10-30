using System;
using System.Drawing;
using System.Threading;

using System.Windows.Forms;

namespace CarParkSimulation
{
    public class WaitPanel : AbstractSectionPanel
    {

        private int delay;
        private Panel wp;//wait panelss


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
        private String panelDestination;

        private String nextSpot;

        private bool turn = false;
        private bool isPassing = false;


        private char secName;


        public WaitPanel(Point origin,
                           int delay,
                           Direction dir,
                           Panel panel,
                           Color colour,
                           Semaphore sem,
                           Semaphore sem2,
                           Semaphore parkSemaphore,
                           Semaphore nextSlot,
                           Buffer readBuffer,
                           Buffer writeBuffer,
                           Buffer parkBuffer,
                           String panelDestination,
                           String nextSpot,
                           int panelNum)
        {
            this.origin = origin;
            this.delay = delay;
            this.nextSpot = nextSpot;
            this.parkBuffer = parkBuffer;
            this.semNextDestination = nextSlot;//semaphore
            this.panelDestination = panelDestination;
            this.dir = dir;
            this.parkSem = parkSemaphore;

            this.wp = panel;
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
            this.wp.Paint += new PaintEventHandler(this.panel_Paint);
            this.sem1 = sem;
            this.sem2 = sem2;
            this.readBuffer = readBuffer;
            this.writeBuffer = writeBuffer;

        }

        //Overloaded constructor for the panels which turn inside the parking lot ... for panel 2
        //4 buffers and 5 semaphoire for panel 2 ..reading from entrance buffer,writing to panel 2s shared buffer,one buffer for parked in destination 1,alternatiev buffer for turning if destination is elsewhere
        public WaitPanel(Point origin,
                           int delay,
                           Direction dir,
                           Panel panel,
                           Color colour,
                           Semaphore sem,
                           Semaphore sem2,
                           Semaphore parkSemaphore,
                           Semaphore semNextDestination,
                           Buffer readBuffer,
                           Buffer writeBuffer,
                           Buffer parkBuffer,
                           String panelDestination,
                           String nextSpot,
                           bool isTurn,
                           Semaphore altSem,
                           Buffer altBuf, int panelNum)
        {
            this.origin = origin;
            this.delay = delay;
            this.nextSpot = nextSpot;
            this.parkBuffer = parkBuffer;
            this.semNextDestination = semNextDestination;
            this.panelDestination = panelDestination;
            this.dir = dir;
            this.parkSem = parkSemaphore;
            this.turn = isTurn;

            this.wp = panel;
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
            this.wp.Paint += new PaintEventHandler(this.panel_Paint);
            this.sem1 = sem;
            this.sem2 = sem2;
            this.readBuffer = readBuffer;
            this.writeBuffer = writeBuffer;

        }

        //overlaoded Constructor for passing from different entrance

        public WaitPanel(Point origin,
                             int delay,
                             Direction dir,
                             Panel panel,
                            Color colour,
                             Semaphore sem,
                             Semaphore sem2,
                             Semaphore parkSem,
                             Semaphore semNextDestination,
                             Buffer readBuffer,
                             Buffer writeBuffer,
                             Buffer parkBuffer,
                             String panelDestination,
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
            this.semNextDestination = semNextDestination;
            this.panelDestination = panelDestination;
            this.dir = dir;
            this.parkSem = parkSem;
            this.isPassing = isPassing;
            this.secName = laneName;
            this.semExtra = sem5;
            this.wp = panel;
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
            this.wp.Paint += new PaintEventHandler(this.panel_Paint);
            this.sem1 = sem;
            this.sem2 = sem2;
            this.readBuffer = readBuffer;
            this.writeBuffer = writeBuffer;

        }


        public override void Start()
        {


            for (; ; )//infinite for loop  continue
            {
                sem1.Signal();
                this.initCar();//make car 0

                //if (panelNum == 16 || panelNum == 21)
                //{
                //    this.xDelta = 0;
                //    this.yDelta = 30;
                //    //this.colour = Color.PeachPuff;
                //   // this.delay =  50;
                //    Thread.Sleep(30);
                //    wp.Invalidate();

                //}

                //read from previous written panels buffer
                readBuffer.ReadColour(ref this.colour);

                readBuffer.ReadDestination(ref this.destination);
                //readall
                sem1.active = true;


                // If the car is going to park in the next destination
                if (String.Compare(destination, panelDestination) == 0)
                {
                    for (int i = 1; i <= 22; i++)//22 bcz size
                    {
                        wp.Invalidate();
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
                        wp.Invalidate();
                        this.moveCar(xDelta, yDelta);

                        Thread.Sleep(delay);
                    }
                    this.xDelta = tempStoreX;
                    this.yDelta = tempStoreY;

                    //store the car object details in the buffer
                    parkSem.Wait();
                    parkBuffer.WriteColour(this.colour);

                    parkBuffer.WriteDestination(this.destination);
                    wp.Invalidate();
                }
                // If the car isn't parking here
                else
                {

                    //if car is going to panel by turning
                    if (turn && ((destination == "a4") || (destination == "a5") || (destination == "a6") || (destination == "b4") || (destination == "b5") || (destination == "b6")))
                    {

                        for (int i = 1; i <= 22; i++)//bcz size 22
                        {
                            wp.Invalidate();
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
                            wp.Invalidate();
                            this.moveCar(xDelta, yDelta);
                            Thread.Sleep(delay);
                        }
                        this.xDelta = tempStoreX;
                        this.yDelta = tempStoreY;

                        //write in the turning points buffer
                        turnSemaphore.Wait();
                        turnBuffer.WriteColour(this.colour);

                        turnBuffer.WriteDestination(this.destination);
                        wp.Invalidate();
                    }

                    // If it is going from entrance A to Entrance b site or vice versa
                    else if ((isPassing) && !(this.destination[0] == secName))
                    {
                        for (int i = 1; i <= 32; i++)//32 size 
                        {
                            wp.Invalidate();
                            this.moveCar(xDelta, yDelta);
                            Thread.Sleep(delay);
                        }

                        //this is for the next sections ones only,,free 4 slots
                        if (this.destination[1] == '4')
                        {
                            int pause = 1000;
                            Boolean flag = false;
                            while (turnSemaphore.active)
                            {
                                flag = true;
                                Thread.Sleep(pause);
                            }

                            while (semExtra.active)
                            {
                                flag = true;
                                Thread.Sleep(pause);
                            }

                            if (flag)
                            {
                                Thread.Sleep(pause);
                            }

                            //write the turn to the turnbuffer
                            semExtra.Wait();
                            turnBuffer.WriteColour(this.colour);
                            turnBuffer.WriteDestination(this.destination);
                            wp.Invalidate();
                            semExtra.Signal();

                        }
                        else//normal thing
                        {
                            turnSemaphore.Wait();
                            turnBuffer.WriteColour(this.colour);
                            turnBuffer.WriteDestination(this.destination);
                            wp.Invalidate();

                        }

                    }
                    // not in parking
                    else
                    {

                        //If it is a straight line turn move less
                        //panel 21,20,8,9
                        if (origin.X == -28 || origin.X == 165)
                        {

                            for (int i = 1; i <= 16; i++)
                            {
                                wp.Invalidate();
                                this.moveCar(xDelta, yDelta);
                                Thread.Sleep(delay);
                            }
                        }
                        //If it is not a horizontal turning panel
                        else
                        {
                            //If the car is just coming out of a parking spot
                            if (this.destination == "Turn")
                            {
                                wp.Invalidate();
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
                                    wp.Invalidate();
                                    this.moveCar(xDelta, yDelta);
                                    Thread.Sleep(delay);
                                }
                                this.xDelta = xTemp;
                                this.yDelta = yTemp;
                                for (int i = 1; i < 15; i++)
                                {
                                    wp.Invalidate();
                                    this.moveCar(xDelta, yDelta);
                                    Thread.Sleep(delay);
                                }
                                this.origin = tempPoint;
                                this.destination = "Exit";
                            }
                            //If the car isn't coming out of a parking slot and is moving normally
                            else
                            {
                                for (int i = 1; i <= 32; i++)
                                {
                                    wp.Invalidate();
                                    this.moveCar(xDelta, yDelta);
                                    Thread.Sleep(delay);
                                }
                            }

                        }
                        // Is the current car trying to park in the panel two spots ahead, if empty write to next buffer
                        String check = "next" + this.destination;
                        if (String.Compare(check, nextSpot) == 0)
                        {
                            bool flag2 = false;
                            int pause = 1000;
                            while (sem2.active)
                            {
                                Thread.Sleep(pause);
                                flag2 = true;
                            }
                            while (semNextDestination.active)
                            {
                                Thread.Sleep(pause);
                                flag2 = true;
                            }
                            if (flag2)
                            {
                                Thread.Sleep(pause);
                            }

                            semNextDestination.Wait();

                            writeBuffer.WriteColour(this.colour);

                            writeBuffer.WriteDestination(this.destination);
                            wp.Invalidate();

                            semNextDestination.Signal();
                        }
                        // If the car isn't trying to park in the next spot as in just moving normally
                        else
                        {
                            sem2.Wait();
                            writeBuffer.WriteColour(this.colour);
                            writeBuffer.WriteDestination(this.destination);
                            wp.Invalidate();
                        }
                    }
                }
                sem1.active = false;
                //this.colour = Color.White;
                wp.Invalidate();
            }
            this.colour = Color.PeachPuff;
            wp.Invalidate();
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
            g.FillRectangle(brush, car.X, car.Y, 10, 10);
            brush.Dispose();
            g.Dispose();
        }
    }// end class 
}
