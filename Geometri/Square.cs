using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public class Square : Polygon
    {
        public Square(double a) : base(a)
        {
            name = "square";
        }

        public override double Perimeter()
        {

            return a * 4;
        }

        public override double Area()
        {
            return a * a;
        }
    }

    
    

}
