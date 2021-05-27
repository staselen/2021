using System;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        //shared variable

        static void Main(string[] args)
        {
            //Create object reference to Producer and Consumer objects
            Consumer consumer = new Consumer();
            Producer producer = new Producer();
            //Create shared buffer, producer fills it up and consumer empties it.
            Queue<Product> buffer = new Queue<Product>();

            //Creates and start the producer and consumer threads.
            Thread producerThread = new Thread(producer.Produce);
            Thread consumerThread = new Thread(consumer.Consume);
            producerThread.Start(buffer);
            consumerThread.Start(buffer);
        }
    }
}
