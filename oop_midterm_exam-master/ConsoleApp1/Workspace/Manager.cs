namespace ConsoleApp1.Exam
{
    // Inheritance Example
    public class Employee
    {
        public string? Name { get; }
        public decimal Salary { get; }

        public Employee(string? name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public virtual void Work()
        {
            Console.WriteLine($"{Name} is working...");
        }

        public override string ToString()
        {
            return $"{Name} is working...";
        }
    }

    // Developer class extending Employee (Inheritance example)
    public class Developer : Employee
    {
        string[] _skills = [];
        public Developer(string? name, decimal salary, string[]? skills = null) : base(name, salary)
        {
            _skills = skills ?? ["css,c#,mvc,sql,javascript."];
        }

        public override void Work()
        {
            Console.WriteLine($"Developer {Name} is coding.");
        }

        public override string ToString()
        {
            return $"Developer {Name} is coding. Knows {string.Join(",", _skills)}";
        }
    }

    public class Manager : Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int TeamSize { get; set; }
        public Manager(string name, int teamSize, decimal salary) : base(name, salary)
        {
            Name = name;
            TeamSize = teamSize;
            Salary = salary;
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

}