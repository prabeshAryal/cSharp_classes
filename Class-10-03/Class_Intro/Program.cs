// See https://aka.ms/new-console-template for more information
namespace class_intro {
    public class Person {
        private int id; //Field

// private and  public are access modifiers
        public int ID {
            get { if (this.IAM_ROLE == "admin") return id;
                else return 0;
            }
            set { id = value; } } //Property
        public string IAM_ROLE;
        public string FirstName;
        public string LastName;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1= new Person();
            p1.IAM_ROLE = "admin";
            p1.ID = 1724;

            System.Console.WriteLine(p1.ID);
            // pi.FirstName = "";

        }
    }
    }