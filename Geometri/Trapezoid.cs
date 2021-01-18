using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    class Trapezoid : Polygon
    {
        private double b { get; set; }
        private double c { get; set; }
        private double d { get; set; }
        public Trapezoid(double a, double b, double c, double d) : base(a)
        {
            name = "trepezoid";
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public override double Perimeter()
        {

            return a + b + c + d;

        }
        public override double Area()
        {
            double s = (a + b - c + d) / 2;
            double y = 2 / (a - c);
            double x = s * (s - a + c) * (s - b) * (s - d);
            double h = Convert.ToDouble(Math.Pow(x, y));

            double area = 0.5 * (a + c) * h;


            return area;
        }
    }
}
