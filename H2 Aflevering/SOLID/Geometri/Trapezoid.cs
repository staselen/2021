using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    class Trapezoid : Shape
    {
        private double Length_B { get; set; }
        private double Length_C { get; set; }
        private double Length_D { get; set; }
        public Trapezoid(double length_A, double length_B, double length_C, double length_D) : base(length_A)
        {
            Name = "Trepezoid";
            Length_B = length_B;
            Length_C = length_C;
            Length_D = length_D;
        }

        public override double Perimeter()
        {
            return Length_A + Length_B + Length_C + Length_D;
        }
        public override double Area()
        {
            double s = (Length_A + Length_B - Length_C + Length_D) / 2;
            double y = 2 / (Length_A - Length_A);
            double x = s * (s - Length_A + Length_C) * (s - Length_B) * (s - Length_D);
            double h = Convert.ToDouble(Math.Pow(x, y));

            double area = 0.5 * (Length_A + Length_C) * h;

            return area;
        }
    }
}
