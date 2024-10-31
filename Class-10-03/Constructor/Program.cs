using System.Security.Cryptography.X509Certificates;

public class Person
{
    public string IAMRole { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public int Age { get; set; }

    public Person(string iamRole, string firstName, string lastName, int id,int age)
    {
        IAMRole = iamRole;
        FirstName = firstName;
        LastName = lastName;
        ID = id;
        Age = age;
    }
}

public class Student : Person
{
    public Student(string iamRole, string firstName, string lastName, int id, int age)
        : base(iamRole, firstName, lastName, id, age)
    {
        if (age < 10 || age > 30)
        {
            throw new ArgumentOutOfRangeException(nameof(Age), "Age must be in range 10-30");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Person p1 = new Person("admin", "Prabesh", "Aryal", 1724, 100);
            System.Console.WriteLine(p1.Age);

            Student s1 = new Student("user", "Student", "Student2", 120, 50);
            System.Console.WriteLine(s1.Age);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}
