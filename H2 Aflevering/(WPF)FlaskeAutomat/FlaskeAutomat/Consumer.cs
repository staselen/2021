using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlaskeAutomat
{
    public class Consumer
    {
        static public bool turnedOn = true;
        public void Consume(object obj)
        {
            Queue<Product> productBuffer = (Queue<Product>)obj;
            while (true)
            {
                if (turnedOn) //Checks if start button is checked
                {
                    lock (productBuffer)
                    {
                        while (productBuffer.Count == 0) //While there are no objects in queued sleep
                        {
                            Monitor.Wait(productBuffer);
                        }
                        //Checks if the next product is a child
                        //If not, it knowns it has arrived and the animation is complete (Because it is removed from canvas)
                        //Ideally I'd want to remove it from this class. Logic removes and ui updates accordingly
                        //In this case this solution seemed a bit more elegant to me.
                        //Customer removes object (visually) queue notices it's gone and removes the data :D
                        while (productBuffer.Peek().Image.Parent != null) 
                        {
                            Monitor.Wait(productBuffer);
                            Thread.Sleep(50);
                        }

                        productBuffer.Dequeue();

                        Monitor.PulseAll(productBuffer);
                    }
                }
                Thread.Sleep(500);
            }
        }
    }
}
