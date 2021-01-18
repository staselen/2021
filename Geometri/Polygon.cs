using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public abstract class Polygon
    {
        //Protected variables so that subclasses can use them
        protected string name { get; set; }
        protected double a { get; set; }
        
        public Polygon(double a)
        {
            this.a = a;
        }

        public abstract double Perimeter();

        public abstract double Area();

        //To string method to get information on the desired polygon.
        public override string ToString()
        {

            return name + "\nArea: " + Area() + "\nCircumference: " + Perimeter() + "\n";
        }

    }
}
