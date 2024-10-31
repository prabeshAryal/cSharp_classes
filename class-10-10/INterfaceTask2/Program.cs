
interface IAppliance{
    void TurnOn();
    void TurnOff();
    bool isOn{ get;}
}

abstract class Appliance:IAppliance
{
    protected bool _isOn;
    public void TurnOn(){
        _isOn = true;
    }
    public void TurnOff(){
        _isOn = false;
    }

    public bool isOn{
        get{ return _isOn; }
    }

    public abstract void DisplayStatus();
}

class Fan:Appliance{
    public override void DisplayStatus() { 
        System.Console.WriteLine("Fan is " + (_isOn? "ON" : "OFF"));
    }
}
class AC : Appliance
{
    public override void DisplayStatus()
    {
        System.Console.WriteLine("AC is " + (_isOn ? "ON" : "OFF"));
    }
}
class TV : Appliance
{
    public override void DisplayStatus()
    {
        System.Console.WriteLine("TV is" + (_isOn ? "ON" : "OFF"));
    }
}

class Program{

    public static void Main(string[] args){
        Console.WriteLine("");
        System.Console.WriteLine("Select an Appliance : \n\t1. Fan \n\t 2. AC \n\t 3. TV \n\t 4. All");
        int choice;
        bool haha = int.TryParse(Console.ReadLine(), out choice);
        if (haha) {
            switch (choice) {
                case 1:
                    Fan fan = new Fan();
                    bool on_off = false;
                    Console.WriteLine("You Selected Fan \n\t Press \n\t\t 0 for OFF and \n\t\t 1 for ON");
                    bool.TryParse(Console.ReadLine(), out on_off);
                    if (on_off == true) { 
                        fan.TurnOn();
                        fan.DisplayStatus();
                    }
                    else {
                            fan.TurnOff();
                            fan.DisplayStatus();
                    }
                break;
            case 2:
                    TV tv = new TV();
                    bool on_offtv = false;
                    Console.WriteLine("You Selected Fan \n\t Press \n\t\t 0 for OFF and \n\t\t 1 for ON");
                    bool.TryParse(Console.ReadLine(), out on_offtv);
                    if (on_offtv == true)
                    {
                        tv.TurnOn();
                        tv.DisplayStatus();
                    }
                    else
                    {
                        tv.TurnOff();
                        tv.DisplayStatus();
                    }
                    break;
                case 3:
                    AC ac = new AC();
                    bool on_offAC = false;
                    Console.WriteLine("You Selected Fan \n\t Press \n\t\t 0 for OFF and \n\t\t 1 for ON");
                    bool.TryParse(Console.ReadLine(), out on_offAC);
                    if (on_offAC == true)
                    {
                        ac.TurnOn();
                        ac.DisplayStatus();
                    }
                    else
                    {
                        ac.TurnOff();
                        ac.DisplayStatus();
                    }
                    break;
                case 4:
                    AC acA = new AC();
                    TV tVA= new TV();
                    Fan fanA = new Fan();
                    bool on_offA = false;
                    Console.WriteLine("You Selected ALL \n\t Press \n\t\t 0 for OFF and \n\t\t 1 for ON");
                    bool.TryParse(Console.ReadLine(), out on_offA);
                    if (on_offA == true)
                    {
                        fanA.TurnOn();
                        fanA.DisplayStatus();
                        tVA.TurnOn();
                        tVA.DisplayStatus();
                        acA.TurnOn();
                        acA.DisplayStatus();
                    }
                    else
                    {
                        fanA.TurnOff();
                        fanA.DisplayStatus();
                        tVA.TurnOff();
                        tVA.DisplayStatus();
                        acA.TurnOff();
                        acA.DisplayStatus();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                        break;
                
            }

        }
        

    }
}