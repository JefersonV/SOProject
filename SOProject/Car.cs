using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOProject
{
    public class Car
    {

        public Color Color;
        public string parkslot;
        public int delay;


        public Car(Color Color, String parkslot, int delay)
        {
            this.Color = Color;
            this.parkslot = parkslot;
            this.delay = delay;

        }
    }
}
