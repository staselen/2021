using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    class Rectangle : Shape
    {
        private double Length_B { get; set; }

        public Rectangle(double length_A, double length_B) : base(length_A)
        {
            Name = "Rectangle";
            Length_B = length_B;
        }

        public override double Perimeter()
        {
            return (Length_A+Length_B)*2;
        }

        public override double Area()
        {
            return Length_A * Length_B;
        }
    }
}
