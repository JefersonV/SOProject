using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOProject
{
    public abstract class AbstractSectionPanel
    {
        public Point car;
        public Point origin;
        public int xDelta;
        public int yDelta;
        public int panelNum;
        public Direction dir;
        public String destination;
        public void resetCar()
        {
            car.X = origin.X;
            car.Y = origin.Y;

        }

        public void moveCar(int xDelta, int yDelta)
        {
            car.X += xDelta;
            car.Y += yDelta;
        }
        public abstract void Start();//abstract method have to override in every panel 
    }
}
