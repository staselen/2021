using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlaskeAutomat
{
    public class Splitter
    {
        static public bool turnedOn = true; 
        public void Split(object obj)
        {
            //Cast object to a Queue<Product> array, then "unpack" the array
            Queue<Product>[] buffers = (Queue<Product>[])obj;
            Queue<Product> splitBuffer = buffers[0];
            Queue<Product> sodaBuffer = buffers[1];
            Queue<Product> beerBuffer = buffers[2];
            //Splitter.split now has access to all the buffers

            while (true)
            {
                if (turnedOn) //Checks if start button is checked
                {
                    lock (splitBuffer)
                    {
                        while (splitBuffer.Count == 0) //While there are no objects in queued sleep
                        {
                            Monitor.Wait(splitBuffer);
                        }

                        //As soon as a product is created it will be in the queue, but only when it reaches the right
                        //Destination will the state change to Arrived and splitter can work with it
                        while (splitBuffer.Peek().State != "Arrived") 
                        {
                            Monitor.Wait(splitBuffer);
                        }

                        //Moves it to the correct product queue, changes state to traveling as it once again will travel
                        if (splitBuffer.Peek().Name == "Soda" && splitBuffer.Peek().State == "Arrived")
                        {
                            lock (sodaBuffer)
                            {
                                splitBuffer.Peek().State = "Traveling";
                                sodaBuffer.Enqueue(splitBuffer.Dequeue());
                                Monitor.PulseAll(sodaBuffer);
                            }
                        } 
                        else if (splitBuffer.Peek().Name == "Beer" && splitBuffer.Peek().State == "Arrived")
                        {
                            lock (beerBuffer)
                            {
                                splitBuffer.Peek().State = "Traveling";
                                beerBuffer.Enqueue(splitBuffer.Dequeue());
                                Monitor.PulseAll(beerBuffer);
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
