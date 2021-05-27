using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Consumer
    {
        public void Consume(object obj)
        {
            Queue<Product> buffer = (Queue<Product>)obj;  
            //never stop running
            while (true)
            {
                //Locks the buffer
                Monitor.Enter(buffer);
                try
                {
                    //If the buffer has 0 products in it, release the lock and wait for pulse
                    if (buffer.Count == 0)
                    {
                        Console.WriteLine("Consumer is waiting...");
                        Monitor.Wait(buffer);
                    }

                    //Can't use .Count in the forloop because the Count is changed the loop.
                    int x = buffer.Count;
                    for (int i = 0; i < x; i++)
                    {
                        //Dequeue(Removes) the last added product and prints it in the console with the current thread running
                        Console.WriteLine("ThreadID:{0} consumed a " + buffer.Dequeue().Name, Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(300);
                    }
                    Console.WriteLine("No more product to consume");
                }
                finally
                {
                    Monitor.PulseAll(buffer); //Notify all other threads(Producer thread)
                    Monitor.Exit(buffer);     //Release the lock
                }
                Thread.Sleep(1000);
            }
        }

    }
}
