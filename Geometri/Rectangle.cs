using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    class Rectangle : Polygon
    {
        private double b { get; set; }

        public Rectangle(double a, double b) : base(a)
        {
            name = "rectangle";
            this.b = b;
        }

        public override double Perimeter()
        {
            return (a+b)*2;
        }

        public override double Area()
        {
            return a * b;
        }
    }
}
