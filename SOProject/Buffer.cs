using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOProject
{
    public class Buffer
    {
        private Color carColor;
        private int delay;
        private bool empty = true;
        private String parkingspot;
        private Car car;

        //public void readALL(ref Car car) {

        //    lock (this)
        //    {
        //        // Check whether the buffer is empty.
        //        if (empty)
        //            Monitor.Wait(this);
        //        empty = true;
        //        car = this.car;

        //        Monitor.Pulse(this);
        //    }



        //}


        //public void writeAll(Car car)
        //{

        //    lock (this)
        //    {
        //        // Check whether the buffer is full.

        //        if (!empty)
        //            Monitor.Wait(this);
        //        empty = false;
        //        this.car = car;
        //        Monitor.Pulse(this);
        //    }
        //}

        public void ReadColour(ref Color carColor)
        {
            lock (this)
            {
                // Check whether the buffer is empty.
                if (empty)
                    Monitor.Wait(this);
                empty = true;
                carColor = this.carColor;
                Monitor.Pulse(this);
            }
        }
        public void ReadDelay(ref int delay)
        {
            lock (this)
            {
                // Check whether the buffer is empty.
                if (empty)
                    Monitor.Wait(this);
                empty = true;
                delay = this.delay;
                Monitor.Pulse(this);
            }
        }
        public void ReadPark(ref String parkingspot)
        {
            lock (this)
            {
                // Check whether the buffer is empty.
                if (empty)
                    Monitor.Wait(this);
                empty = true;
                parkingspot = this.parkingspot;
                Monitor.Pulse(this);
            }
        }
        public void WriteColour(Color carColor)
        {
            lock (this)
            {
                // Check whether the buffer is full.
                if (!empty)
                    Monitor.Wait(this);
                empty = false;
                this.carColor = carColor;
                Monitor.Pulse(this);
            }
        }
        public void WriteDelay(int delay)
        {
            lock (this)
            {
                // Check whether the buffer is full.
                if (!empty)
                    Monitor.Wait(this);
                empty = false;
                this.delay = delay;
                Monitor.Pulse(this);
            }
        }
        public void WriteDestination(String parkingspot)
        {
            lock (this)
            {
                // Check whether the buffer is full.
                if (!empty)
                    Monitor.Wait(this);
                empty = false;
                this.parkingspot = parkingspot;
                Monitor.Pulse(this);
            }
        }
        public void emptyBuffer()
        {
            empty = true;
        }
        public void Start()
        {
        }
    }
}
