using System;
using System.Collections.Generic;
using System.Threading;

namespace FlaskeAutomaten
{
    class Program
    {
        static void Main(string[] args)
        {
            //Producer is Responsible for producing all of the products 
            Producer producer = new Producer();
            //Buffer from Producer to splitter
            Queue<Product> splitBuffer = new Queue<Product>();
            //Spitter is Responsible for sorting the products to the correct buffers
            Splitter splitter = new Splitter();
            //Buffer from splitter to soda consumer
            Queue<Product> sodaBuffer = new Queue<Product>();
            //Buffer from splitter to beer consumer
            Queue<Product> beerBuffer = new Queue<Product>();
            //Consumer is the end point of the assembly manufacturing process
            Consumer sodaConsumer = new Consumer();
            Consumer beerConsumer = new Consumer();

            //Create and start producer thread
            Thread producerThread = new Thread(producer.Produce)
            {
                Name = "Producer"
            };
            producerThread.Start(splitBuffer);

            //Unique to the splitter, it needs acess to 3 buffers, unlike the rest who only has access to one
            //Since threads only take one parameter I've put the 3 buffers in an array
            Queue<Product>[] buffers = new Queue<Product>[3];
            buffers[0] = splitBuffer;
            buffers[1] = sodaBuffer;
            buffers[2] = beerBuffer;

            //Create and start splitter thread
            Thread splitterThread = new Thread(splitter.Split)
            {
                Name = "Splitter"
            };
            splitterThread.Start(buffers);

            //Create and start sodaConsumerThread
            Thread sodaConsumerThread = new Thread(sodaConsumer.Consume)
            {
                Name = "SodaCons"
            };
            sodaConsumerThread.Start(sodaBuffer);

            //Create and start beerConsumerThread
            Thread beerConsumerThread = new Thread(beerConsumer.Consume)
            {
                Name = "BeerCons"
            };
            beerConsumerThread.Start(beerBuffer);
        }
    }
}
