
namespace Events
{
   
        public delegate void LowTempHandler(object obj, EventArgs e);

        public class Thermostat
        {

            public event LowTempHandler LowTemp;
            public double CurrentTemp;
            public void MonitorTemp()
            {
            Console.WriteLine($"CUrrent Temp : {this.CurrentTemp}");
                if (this.CurrentTemp < 15)
                {
                if (this.LowTemp != null)
                {
                    LowTemp?.Invoke(this, EventArgs.Empty);
                }
                }
            }
        }

        public class HeatingSystem
    {
        public void TurnOnHeating(object sender, EventArgs e) {
            Console.WriteLine("Low Temperature, Heating is On.");
        }
    }
    public class Program
    {
        public static void Main(String[] args)
        {
            Thermostat t = new Thermostat() { CurrentTemp=17};
            HeatingSystem hs = new HeatingSystem();
            t.LowTemp += hs.TurnOnHeating;
            while (t.CurrentTemp>9) {
                t.MonitorTemp();
                t.CurrentTemp--;
                Thread.Sleep(2000); // Sleep 2 s
            }
        }
    }
}