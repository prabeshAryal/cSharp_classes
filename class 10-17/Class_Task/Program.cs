namespace Class_Task
{
    public delegate void LowFuelIndicator(object obj, EventArgs e);

    public class GasStation
    {
        public double current_volume;
        public event LowFuelIndicator LowFuel;
        public void MonitorFuelTank()
        {
            Console.WriteLine($"Current Fuel : {this.current_volume}");
            if (LowFuel != null && current_volume < 10)
            {
                LowFuel.Invoke(this, EventArgs.Empty);
            }

        }
    }
    public class RefillSystem
    {
        public void FillTank(object o, EventArgs e)
        {
            Console.WriteLine("Refueling");
            ((GasStation)o).current_volume += 1;
        }
    }



    public class Program
    {
        public static void Main(string[] args) {
            Console.WriteLine("  ");
            GasStation g = new GasStation() {current_volume = 20};
            RefillSystem refill = new RefillSystem();
            g.LowFuel += refill.FillTank;
            while (g.current_volume>2)
            {
                g.MonitorFuelTank();
                g.current_volume-=2;
                Thread.Sleep(1000);

            }


        }
    }
}