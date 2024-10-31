// create class SHape and make different classes rectangle and all

// Basically polymorphism means if any classses take properties from any other classes;

using System.ComponentModel.DataAnnotations;

class Shapes{

    public int no_of_sides { get; set; }
    public double Area(double[] args){
        if (args== null || args.Length==0){
            throw new ArgumentException("Please pass non empty values");
        } 
        else{
            double area = 1;
            foreach (var arg in args){
                // System.Console.WriteLine(arg);
                area *= arg;
            }
            return area;
        }
    }
}
class Rectangle:Shapes{
    public double Length { get; set; }
    public double Breadth { get; set; }

    public double calculateArea() {
        return (Area([this.Length, this.Breadth]));
    }
    public Rectangle(double l, double b){
        this.Length = l;
        this.Breadth = b;
    }
}


class Square:Rectangle {
    public Square(double side):base(side,side)
    {
    }
}

class Circle:Shapes {
    public double Radius { get; set;}
    public double pie = Math.PI;

    public double calculateArea()
    {
        return (Area([pie,Math.Pow(Radius,2)]));
    }
    public Circle(double r){
        this.Radius = r;
    }
}

class Triangle :Shapes {
    public double baseT {get;set;}
    public double heighT{ get; set; }

    public double half = 0.5;

    public double calculateArea()
    {
        return (Area([this.half, this.baseT,this.heighT]));
    }
    public Triangle(double basee,double height){
        this.baseT = basee;
        this.heighT = height;
    }
}


class Program{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("What you want ? \n\t 1. Square \n\t 2. Reactangle \n\t 3. Circle \n\t 4. Triangle");
        int choice;
        bool status = int.TryParse(Console.ReadLine(),out choice);
        if (status)
        {
            switch (choice)
            {
                case 1:
                    Console.Write("Enter the side of square: ");
                    double side;
                    bool success = double.TryParse(Console.ReadLine(), out side);
                    if (success)
                    {
                        Square S = new Square(side);
                        Console.WriteLine($"Area of given square with side  {side} : {S.calculateArea()} sq. units.");
                    }
                    break;
                case 2:
                    Console.Write("Enter the Length of Rectangle: ");
                    double length, breadth;
                    bool l_status = double.TryParse(Console.ReadLine(), out length);
                    Console.Write("Enter the Breadth of Rectangle: ");
                    bool b_status = double.TryParse(Console.ReadLine(), out breadth);
                    if (l_status & b_status)
                    {
                        Rectangle R = new Rectangle(length, breadth);
                        Console.WriteLine($"Area of given Rectangle {length} * {breadth} is {R.calculateArea()} square units. ");
                    }
                    break;
                case 3:
                    Console.Write("Enter the Radius of Circle: ");
                    double radius;
                    bool r_status = double.TryParse(Console.ReadLine(), out radius);
                    if (r_status)
                    {
                        Circle C = new Circle(radius);
                        Console.WriteLine($"Area of given Circle with radius = {radius} is {C.calculateArea()} square units. ");
                    }
                    break;
                case 4:
                    Console.Write("Enter the Base of Traingle: ");
                    double base_t, height;
                    bool base_status = double.TryParse(Console.ReadLine(), out base_t);
                    Console.Write("Enter the Height of Traingle: ");
                    bool h_status = double.TryParse(Console.ReadLine(), out height);
                    if (h_status & base_status)
                    {
                        Triangle T = new Triangle(base_t, height);
                        Console.WriteLine($"Area of given Traingle with base {base_t} and height {height} is {T.calculateArea()} square units. ");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        else {
            System.Console.WriteLine("Try to Enter a Valid Value ;)");
        }
    }
}