// See https://aka.ms/new-console-template for more information

namespace MyNamespace
{
    public class Circle{
        public double radius;
        public static double pi = 3.14;

        public double Area(){
            return pi * radius * radius;
        }
    }

    public class Rectangle
    {
        public double l;
        public double b;

        public double Area()
        {
            return l*b;
        }
    }
    public class Square
    {
        public double l;
        public double Area()
        {
            return l * l;
        }

    }
    public class Program{
        public static void Main(string[] args){
            //    Static
            Circle newCir = new Circle();
            newCir.radius = 7;
            System.Console.WriteLine(newCir.Area());
        }
    }
}