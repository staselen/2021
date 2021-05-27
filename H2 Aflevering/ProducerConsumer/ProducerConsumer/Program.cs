using System;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        //shared variable
        static Queue<Product> buffer = new Queue<Product>();

        static void Main(string[] args)
        {
            //Creates and start the producer and consumer threads.
            Thread producer = new Thread(Produce);
            Thread consumer = new Thread(Consume);
            producer.Start();
            consumer.Start();
        }

        static void Produce()
        {
            //never stop running
            while (true)
            {
                //Locks the buffer
                Monitor.Enter(buffer);
                try
                {
                    //If the buffer has 3 products in it, release the lock and wait for pulse
                    if(buffer.Count >= 3)
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

        static void Consume()
        {
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
