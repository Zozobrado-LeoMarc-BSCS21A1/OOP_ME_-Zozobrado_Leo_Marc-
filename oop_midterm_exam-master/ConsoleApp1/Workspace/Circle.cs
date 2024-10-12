namespace ConsoleApp1.Exam
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
