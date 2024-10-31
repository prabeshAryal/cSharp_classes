using System;

namespace Something
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "John Doe";
            person.Age = 12;
            Console.WriteLine($"Hello, {person.Name}!");
            Console.WriteLine(person.Age);
        }
    }
}
