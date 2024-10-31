abstract class Animal{
    public abstract void sound();
}

class Dog:Animal{
    public override void sound() {
        Console.WriteLine("howhow");
            }
}

class Program{

    public static void Main(string[] args){
        var game = new Dog();
        game.sound();
        try
        {
            // var animal = new Animal;
            Console.WriteLine("Can't Use Abstract class, compile fails");
        }
        catch (Exception e){
            Console.WriteLine("Error"+e);
        }
    }
}