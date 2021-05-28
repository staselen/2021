using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FlaskeAutomaten
{
    public class Producer
    {
        public void Produce(object obj)
        {
            //Casts parameter object back to a buffer(Queue<Product>)
            Queue<Product> splitBuffer = (Queue<Product>)obj;

            while (true)
            {
                lock (splitBuffer) //Locks the buffer(Splitter can't acess)
                {
                    splitBuffer.Enqueue(new Product("Soda")); //Add Product with the name Soda to the splitbuffer Queue
                    Console.WriteLine("{0}: Created a Soda", Thread.CurrentThread.Name);
                    Monitor.PulseAll(splitBuffer); //Notify splitter
                }
                Thread.Sleep(2500);
                //Alternate between creating a Soda and a Beer, pulseAll all when done(Notify Splitter)
                lock (splitBuffer)
                {

                    splitBuffer.Enqueue(new Product("Beer"));
                    Console.WriteLine("{0}: Created a Beer", Thread.CurrentThread.Name);
                    Monitor.PulseAll(splitBuffer);
                }
                Thread.Sleep(2500);
            }
        }
    }
}
