using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    class Parallelogram : Shape
    {
        private int Length_B { get; set; }
        private double SinAngle { get; set; }
              
        public Parallelogram(int length_A, int length_B, int sinAngle) : base(length_A)
        {
            Name = "Parallelogram";
            Length_B = length_B;
            SinAngle = sinAngle;
        }

        public override double Perimeter()
        {
            return (Length_A + Length_A)*2;
        }

        public override double Area()
        {
            return Length_A * Length_B * SinAngle;
        }
    }
}
