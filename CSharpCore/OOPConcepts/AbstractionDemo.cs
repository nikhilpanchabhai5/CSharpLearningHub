using CSharpLearningHubCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearningHub.OOPConcepts
{

    //Abstraction is the process of hiding the implementation details
    //and showing only the functionality to the user.
    //It allows us to focus on what an object does instead of how it does it.
    //In C#, we can achieve abstraction using abstract classes and interfaces.
    public class AbstractionDemo : IProblem
    {
        IShape shape = new Shape();

        public string ProblemName => "Abstraction Demo";

        public string Description => "Abstraction is the process of hiding the implementation details" +
            "\r\nand showing only the functionality to the user." +
            "\r\nIt allows us to focus on what an object does instead of how it does it." +
            "\r\nIn C#, we can achieve abstraction using abstract classes and interfaces." +
            "\r\nIn below example, we demonstrate abstraction using an interface." +
            "\r\nWe don't need to know the details of how the area is calculated.";

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(ProblemName);
            Console.WriteLine(Description);

            Console.WriteLine("Calculating area of a rectangle:");
            double rectangleArea = shape.Area(5, 10);
            Console.WriteLine($"Area of rectangle: {rectangleArea}");
            Console.WriteLine("\nCalculating area of a circle:");
            double circleArea = shape.Area(7);
            Console.WriteLine($"Area of circle: {circleArea}");
        }
    }

    //Interface
    public interface IShape
    {
        double Area(double length, double width);
        double Area(double radius);
    }

    public class Shape : IShape
    { 
        public double Area(double length, double width)
        {
            return length * width;
        }

        public double Area(double radius)
        {
            return Math.PI * radius * radius;
        }
    }
    
}
