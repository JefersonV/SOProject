using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOProject
{
    public class Semaphore
    {
        public int count = 0;
        public Boolean isRunning = false;
        public void Wait()
        {
            lock (this)
            {
                while (count == 0)
                    Monitor.Wait(this);

                count = 0;
            }
        }

        public void Signal()
        {
            lock (this)
            {
                count = 1;
                Monitor.Pulse(this);
            }
        }

        public void Start()
        {
        }
        public bool isTaken()
        {
            if (this.count == 0)
                return true;
            return false;
        }
    }
}
