using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    class WaterContainer
    {
        public List<string> Contains { get; set; }
        public WaterContainer()
        {
            Contains = new List<string>();
        }
    }
}
