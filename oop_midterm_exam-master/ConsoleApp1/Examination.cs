// See https://aka.ms/new-console-template for more information
using ConsoleApp1.Exam;
using System.Drawing;
using System.Xml.Linq;
using Rectangle = ConsoleApp1.Exam.Rectangle;

public static class Examination
{
    public static int Start()
    {
        return RunTests();
    }

    static int RunTests()
    {
        int score = 0;

        // 1. Encapsulation Examination - Bank Account
        var account = new BankAccount();
        account.Deposit(100);
        account.Withdraw(30);
        score += AssertEqual(account.Balance, 70, "Balance should be 70");

        // 2. Inheritance Examination - Manager
        Employee manager = new Manager("Alice", 5, 50000 );
        score += AssertEqual(manager.ToString(), "Alice is managing a team of 5 members", "Should be equal");

        // 3. Interface Examination - Circle
        var circle = new Circle { Radius = 5 };
        score += AssertEqual(circle.GetArea(), Math.PI * 25, "Circle Area should be ~78.54");
        score += AssertEqual(circle.GetPerimeter(), Math.PI * 10, "Circle Perimeter should be ~31.42");
        score += AssertTrue(circle is IShape, $"Assert true: Object should be {typeof(IShape)}");

        // 4. Interface Examination - Rectangle
        var rectangle = new Rectangle { Length = 4, Width = 6 };
        score += AssertEqual(rectangle.GetArea(), 24, "Rectangle Area should be 24");
        score += AssertEqual(rectangle.GetPerimeter(), 20, "Rectangle Perimeter should be 20");
        score += AssertTrue(rectangle is IShape, $"Assert true: Object should be {typeof(IShape)}");

        // 5. Association Examination - Student and Courses
        var student = new Student("John");
        student.Enroll(new Course("Mathematics"));
        student.Enroll(new Course("Physics"));
        Course objectOrientedProgramming = new Course("OOP");
        student.Enroll(objectOrientedProgramming);
        score += AssertEqual(student.Courses.Count, 2, "Student should be enrolled in 2 courses");
        score += AssertTrue(student.Courses.Select(c => c.CourseName).Contains("Mathematics"), "Student courses should include 'Mathematics'");
        score += AssertTrue(student.Courses.Select(c => c.CourseName).Contains("Physics"), "Student courses should include 'Mathematics'");
        score += AssertTrue(!student.Courses.Contains(objectOrientedProgramming), "Student courses should not include 'OOP'");

        // 6. Examination - Invalid withdrawal (overdraft prevention)
        var overdraftAccount = new BankAccount();
        overdraftAccount.Deposit(50);
        var message = overdraftAccount.Withdraw(100); // Should not allow this
        score += AssertEqual(message, "Insufficient funds.", "Balance should remain 50 after an invalid withdrawal attempt");
        score += AssertEqual(overdraftAccount.Balance, 50, "Balance should remain 50 after an invalid withdrawal attempt");

        // 7. Examination - Transfer method in BankAccount
        var account1 = new BankAccount();
        var account2 = new BankAccount();
        account1.Deposit(100);
        account1.Transfer(account2, 50);
        score += AssertEqual(account1.Balance, 50, "Account1 should have 50 after transferring 50 to Account2");
        score += AssertEqual(account2.Balance, 50, "Account2 should have 50 after receiving transfer from Account1");

        // 8. Examination - Developer inheritance
        var developer = new Developer("Bob", 50000, null);
        developer.Work(); // Expect: "Developer Bob is coding."
        score += AssertEqual(developer.ToString(), $"Developer Bob is coding. Knows css,c#,mvc,sql,javascript.", "");

        // 9. Examination - Triangle class implementing IShape
        var triangle = new Triangle(3, 4, 5);
        score += AssertEqual(triangle.GetArea(), 6, "Triangle Area should be 6");
        score += AssertEqual(triangle.GetPerimeter(), 12, "Triangle Perimeter should be 12");
        score += AssertTrue(triangle is IShape, $"Assert true: Object should be {typeof(IShape)}");

        // 10. Examination - Car and Engine composition
        var car = new Car(new Engine());
        car.StartCar();
        score += AssertTrue(car.IsEngineStarted, "Should be true");

        return score;
    }


    // Utility method to simulate assertions
    static int AssertEqual<T>(T actual, T expected, string testDescription)
    {
        if (EqualityComparer<T>.Default.Equals(actual, expected))
        {
            Console.WriteLine($"{testDescription}: Passed\r\n");
            return 1;
        }
        Console.WriteLine($"{testDescription}: Failed (Expected: {expected}, Actual: {actual})\r\n");
        return 0;
    }

    static int AssertTrue(bool condition, string testDescription)
    {
        if (condition)
        {
            Console.WriteLine($"{testDescription}: Passed\r\n");
            return 1;
        }
       
        Console.WriteLine($"{testDescription}: Failed\r\n");
        return 0;
    }

  
}