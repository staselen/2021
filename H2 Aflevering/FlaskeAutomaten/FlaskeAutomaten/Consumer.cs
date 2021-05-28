using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    public class Consumer
    {
        public void Consume(object obj)
        {
            //Casts parameter object back to a buffer(Queue<Product>)
            Queue<Product> productBuffer = (Queue<Product>)obj;

            while (true)
            {
                lock (productBuffer) //Locks the buffer
                {
                    while (productBuffer.Count == 0) //If there are no items to consume
                    {                                //Then
                        Monitor.Wait(productBuffer); //Release the lock and print in console that it's waiting
                        Console.WriteLine("{0}: Waiting", Thread.CurrentThread.Name);
                        Thread.Sleep(1000); //Prevent spam of requests
                    }

                    //Print in console that customer got it's product
                    Console.WriteLine("{0}: Got {1}-ID{2}", Thread.CurrentThread.Name, productBuffer.Peek().Name, productBuffer.Peek().IdentificationNumber);
                    productBuffer.Dequeue(); //Deuque product from the buffer of the product that the customer desired

                }
                Thread.Sleep(1000);
            }
        }
    }
}
