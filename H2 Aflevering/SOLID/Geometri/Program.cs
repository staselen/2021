using System;
using System.Collections.Generic;

namespace Geometri
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a list with all of the diferent Shapes and their required parameters.
            List<Shape> shapes = new List<Shape>()
            {
                new Square(5),
                new Rectangle(5, 5),
                new Parallelogram(5, 5, 5),
                new Trapezoid(16, 8, 8, 8),
                new RightAngledTriangle(5, 5, 5)
            };
            //Having all of the different shapes in a list of (Shape) allows me to loop through them
            //Printing out the ToString() method from shape which all of the subclasses has access to.
            for (int i = 0; i < shapes.Count; i++)
            {
                Console.WriteLine(shapes[i].ToString());
            }
            Console.ReadKey();
        }

        
    }
}
