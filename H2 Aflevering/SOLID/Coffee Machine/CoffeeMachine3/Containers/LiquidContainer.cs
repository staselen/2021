using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    class LiquidContainer
    {
        public List<Liquid> Contains { get; set; }

        public LiquidContainer()
        {
            Contains = new List<Liquid>();
        }
        public void FillUp(Liquid content)
        {
            Contains.Add(content);
        }

        public void Empty()
        {
            Contains = new List<Liquid>();
        }
    }
}
