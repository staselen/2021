using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    public class Splitter
    {
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
                lock (splitBuffer)
                {
                    //If there are no items to split, then the lock is released
                    //and awaits a pulse to be notified of new products
                    while (splitBuffer.Count == 0) //While there are no items to split
                    {                              //Then
                        Monitor.Wait(splitBuffer); //Release the lock
                                                   //Print to console that the thread is waiting
                        Console.WriteLine("{0}: Waiting for more products to be created", Thread.CurrentThread.Name);
                        Thread.Sleep(1000);        //Sleep (To prevent spam of requests)
                    }
                    //Splitter now knows that there are more than 0 procuts in the buffer
                    if (splitBuffer.Peek().Name == "Soda") //It peeks the next in the queue
                    {   //If it's a soda, lock the sodaBuffer
                        lock (sodaBuffer)
                        {   
                            Console.WriteLine("{0}: Moved {1}-ID{2} to the {1} Buffer", Thread.CurrentThread.Name, splitBuffer.Peek().Name, splitBuffer.Peek().IdentificationNumber);
                            sodaBuffer.Enqueue(splitBuffer.Dequeue()); //Move from splitBuffer to sodaBuffer
                            Monitor.PulseAll(sodaBuffer); //Notify that the lock is being released
                        }                               //Then release lock
                    } 
                    //Same but with beer...
                    else if (splitBuffer.Peek().Name == "Beer")
                    {
                        lock (beerBuffer)
                        {
                            Console.WriteLine("{0}: Moved {1}-ID{2} to the {1}", Thread.CurrentThread.Name, splitBuffer.Peek().Name, splitBuffer.Peek().IdentificationNumber);
                            beerBuffer.Enqueue(splitBuffer.Dequeue());
                            Monitor.PulseAll(beerBuffer);
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
