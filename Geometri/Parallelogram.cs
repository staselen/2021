using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    class Parallelogram : Polygon
    {
        private int b { get; set; }
        private double sinAngle { get; set; }
              
        public Parallelogram(int a, int b, int angle) : base(a)
        {
            name = "parallelogram";
            this.b = b;
            this.sinAngle = angle;
        }

        public override double Perimeter()
        {
            return (a + b)*2;
        }

        public override double Area()
        {
            return a * b * sinAngle;
        }
    }
}
