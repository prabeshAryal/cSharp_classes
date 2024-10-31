
namespace delegate_10_17 {
    public delegate void DisplayDelegate(string msg);
    public class Person
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        = string.Empty;
        public string LastName { get; set; }
        = string.Empty;
        public int age;

        public Person(int Age, string name)
        {
            age = Age;
            Name = name;
        }
        public void Show(string a) {
            Console.WriteLine(a);
        }
        public void Hide() {
            Console.WriteLine("No Parater");

        }
        public void SaveFile(string n)
        {
            File.WriteAllLines("C:\\Users\\prabe\\Code\\Languages\\C#\\class 10-17\\Delegate\\hehe.txt", [n]);
            Console.WriteLine("Saved " + n);
        }
        public int DoSTh(DisplayDelegate d)
        {
            return 0;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(19,"Nihad");
            Person a = new Person(21, "Aslan");
            DisplayDelegate dd;
            dd = p.Show;
            dd("Running delegate "+p.Name);
            DisplayDelegate hh;
            //hh = p.Hide; // Gives error 
            hh = p.SaveFile;
            hh(p.Name);

            //MethodAccess delegate 
            DisplayDelegate asa;
            asa = p.DoSTh;
            asa(hh);






        }
    }

}