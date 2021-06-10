using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    class Filter
    {
        public bool Used { get; private set; }

        public Filter() 
        {
            Used = false; //By default a new filter is not used.
        }

        public void UseFilter()
        {
            Used = true;
        }

    }
}
