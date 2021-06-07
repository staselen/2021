using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    //Shape is abstract because no shape is just a shape.
    //However, all shapes have a length in one way or another, therefore it should be a part of the constructor
    public abstract class Shape
    {
        //Protected variables so that only subclasses can use them

        //Name variable added to make printing the information about the shape efforttless
        //Even if thousands of different Polygons were to be added
        protected string Name { get; set; }

        
        protected double Length_A { get; set; }
        //No Shape has has just one length,
        //but because they can be repeating the minimum amount of variables in a shape should only be one.
        //If you know it's a Square and you know one side is 5, then you know the value of all sides,
        //without the need for more than one variable. Same goes for a equilateral triangle.(60°-60°-60°)
        public Shape(double length_A)
        {
            Length_A = length_A;
        }
        //Abstract methods of Perimeter and Area
        //As it is calculated different depending on the type of shape
        //The subclasses has to implement the functions themselves
        //and the content of the function can be tailored to every (shape)subclass
        public abstract double Perimeter();

        public abstract double Area();

        //To string method to get information of the shape.
        public override string ToString()
        {
            return Name + "\nArea: " + Area() + "\nPerimeter: " + Perimeter() + "\n";
        }

    }
}
