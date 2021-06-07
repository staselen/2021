using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public class Square : Shape
    {
        public Square(double length_A) : base(length_A)
        {
            Name = "Square";
        }

        public override double Perimeter()
        {

            return Length_A * 4;
        }

        public override double Area()
        {
            return Length_A * Length_A;
        }
    }

    
    

}
