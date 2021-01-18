using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    class RightAngledTriangle : Polygon
    {
        private double b { get; set; }
        private double c { get; set; }

        public RightAngledTriangle(double a, double b, double c) : base(a)
        {
            name = "right angled triangle";
            this.b = b;
            this.c = c;
        }

        public override double Perimeter()
        {
            return a + b + c;

        }

        public override double Area()
        {
            return 0.5 * a * b;
        }
    }
}
