using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    class RightAngledTriangle : Shape
    {
        private double Length_B { get; set; }
        private double Length_C { get; set; }

        public RightAngledTriangle(double sideA, double sideB, double sideC) : base(sideA)
        {
            Name = "Right angled triangle";
            Length_B = sideB;
            Length_C = sideC;
        }

        public override double Perimeter()
        {
            return Length_A + Length_B + Length_C;

        }

        public override double Area()
        {
            return 0.5 * Length_A * Length_B;
        }
    }
}
