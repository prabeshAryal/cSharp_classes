// See https://aka.ms/new-console-template for more information
namespace hello{

    class Program {

        public static bool functionTest(){
            return true;
        }
        public static void Main(string[] args){
            string test = functionTest().ToString();
            Console.WriteLine($"Hello Test: {test}");

            // This doesn't need to be casted
            int a = 10;
            double d = (double)a;
            Console.WriteLine(d+0.000007);

            d = d + 3.147;
            a = (int)d;
            Console.WriteLine(a);
        }
    }
}