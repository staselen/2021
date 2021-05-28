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

            int identityNumber = 1000; //Number to identify the products

            while (true)
            {
                //I've made an enum of the drinks that the producer can make
                //Runs through the loop one time for every drink in the drink enum
                //A more elegant solution to alternating between the two drinks, instead of making two almost identical sequences of code.
                foreach (var drink in Enum.GetValues(typeof(Drinks.Drink))) 
                {
                    Monitor.Enter(splitBuffer); //Locks the splitBuffer
                    try
                    {
                        identityNumber++; //Increment identity number to keep it unique.
                        splitBuffer.Enqueue(new Product(drink.ToString(), identityNumber)); //Adds a product to the buffer with a name(That it gets from looping through the enum) and an identity ID that is incrementing with every iteration.
                        Console.WriteLine("{0}: Created {1}-ID{2}", Thread.CurrentThread.Name, splitBuffer.Peek().Name, splitBuffer.Peek().IdentificationNumber); //Prints the object that has just been added to the queue
                    }
                    finally
                    {
                        Monitor.PulseAll(splitBuffer); //Notify splitter that lock is released
                        Monitor.Exit(splitBuffer); //Release lock
                        Thread.Sleep(2500); //Sleep for 2.5 seconds.
                    }
                }
                
            }
        }
    }
}
