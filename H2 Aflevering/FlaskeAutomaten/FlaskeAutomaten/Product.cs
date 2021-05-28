using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    class Product
    {
        //Class of the product object.
        //Only variable is the name to keep track of what kind of product it is.
        //Product needs a name to identify what product it is, so the constructor asks for a name.
        public string Name { get; set; }
        public int IdentificationNumber { get; set; }
        public Product(string name, int identificationNumber)
        {
            Name = name;
            IdentificationNumber = identificationNumber;
        }
    }
}
