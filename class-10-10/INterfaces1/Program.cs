
interface IAnimal //we don't even use class or anything, I is a industry standard for intefaces, optional
{
    void MakeSound(); //Method declaration withut implemenatation

}

interface IPet {
    void Play();
}

class Dog:IAnimal,IPet //implement multiple interfaces, (this isn't possible in classes)
{

    public void Play(){
System.Console.WriteLine("Dog is playing;");
    }

    public void MakeSound(){
System.Console.WriteLine("Dog is BArking");
    }
}

class Program(){

    public static void Main(string[] args){
        Dog dog = new Dog();
        dog.Play();
        dog.MakeSound();

        IAnimal wow = new Dog(); //polymorphism, implicit implementattion
        wow.MakeSound();

        // IAnimal xd = new Dog.MakeSound();

    }
}