using ConsoleApp1.Exam;
using System.Xml.Linq;

namespace ConsoleApp1.Exam

{

    public interface IShape

    {

        double GetArea();

        double GetPerimeter();

    }

    public class Rectangle : IShape

    {

        private double _length;

        private double _width;

        public double Length

        {

            get => _length;

            set => _length = value;

        }

        public double Width

        {

            get => _width;

            set => _width = value;

        }

        public double GetArea()

        {

            return _length * _width;

        }

        public double GetPerimeter()

        {

            return 2 * (_length + _width);

        }

    }

    public class Triangle : IShape

    {

        public double SideA { get; }

        public double SideB { get; }

        public double SideC { get; }

        public Triangle(double sideA, double sideB, double sideC)

        {

            SideA = sideA;

            SideB = sideB;

            SideC = sideC;

        }

        public double GetArea()

        {

            double semiPerimeter = GetPerimeter() / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));

        }

        public double GetPerimeter()

        {

            return SideA + SideB + SideC;

        }

    }

}

public class Manager : Employee

{

    public int TeamSize { get; }

    public Manager(string? name, int teamSize, decimal salary)

        : base(name, salary)

    {

        TeamSize = teamSize; // Ensure this is set to the correct value

    }
    public override void Work()
    {

        Console.WriteLine($"{Name} is managing a team of {TeamSize} members");

    }

    public override string ToString()
    {

        return $"{Name} is managing a team of {TeamSize} members";

    }

}


 