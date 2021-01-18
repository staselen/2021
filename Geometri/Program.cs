using System;
using System.Collections.Generic;

namespace Geometri
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating all of the subclasses from Polygon with their required parameters
            Square square = new Square(5);
            Rectangle rectangle = new Rectangle(5, 5);
            Parallelogram parallelogram = new Parallelogram(5, 5, 5);
            Trapezoid trapezoid = new Trapezoid(16, 8, 8, 8);
            RightAngledTriangle triangle = new RightAngledTriangle(5, 5, 5);

            //Puts all of the polygons in a list
            List<Polygon> polygons = new List<Polygon>();
            polygons.Add(square);
            polygons.Add(rectangle);
            polygons.Add(parallelogram);
            polygons.Add(trapezoid);
            polygons.Add(triangle);

            //Printing out the to string method from polygon which all of the subclasses has acess to.
            for (int i = 0; i < polygons.Count; i++)
            {
                Console.WriteLine(polygons[i].ToString());
            }

            Console.ReadKey();

        }

        
    }
}
