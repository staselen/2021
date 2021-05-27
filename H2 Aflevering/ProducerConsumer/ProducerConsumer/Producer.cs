using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Producer
    {
        public void Produce(object obj)
        {
            Queue<Product> buffer = (Queue<Product>)obj;
            //never stop running
            while (true)
            {
                //Locks the buffer
                Monitor.Enter(buffer);
                try
                {
                    //If the buffer has 3 products in it, release the lock and wait for pulse
                    if (buffer.Count >= 3)
                    {
                        Console.WriteLine("Producer is waiting...");
                        Monitor.Wait(buffer);
                    }

                    //Can't use .Count in the for loop because the Count is changed the loop.
                    int x = buffer.Count;
                    for (int i = 0; i < 3 - x; i++)
                    {
                        //Enqueue a cake to the product queue
                        buffer.Enqueue(new Product("Cake"));
                        //Peeks for the last added item on the stack and displays the current thread
                        Console.WriteLine("ThreadID:{0} produced a " + buffer.Peek().Name, Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(300);
                    }
                    Console.WriteLine("No more space to produce");
                }
                finally
                {
                    Monitor.PulseAll(buffer); //Notify all other threads(Consumer thread)
                    Monitor.Exit(buffer);     //Release the lock
                }
                Thread.Sleep(1000);
            }
        }
    }
}
