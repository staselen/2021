using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Controls;

namespace FlaskeAutomat
{
    //Producer class. Changed this one a lot because I wanted UI to produce, so all it really does is return a product
    public class Producer
    {
        private int IdentityNumber = 1000;
        public Product Produce(Queue<Product> splitBuffer, Drinks.Drink type, Image image)
        {

            Monitor.Enter(splitBuffer); 
            try
            {
                IdentityNumber++; 
                return new Product(type.ToString(), IdentityNumber, image); 
            }
            finally
            {
                Monitor.PulseAll(splitBuffer); 
                Monitor.Exit(splitBuffer);
            }
        }
    }
}
