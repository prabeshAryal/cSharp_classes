// See https://aka.ms/new-console-template for more information
using DynamicLinkLibrary;

Console.WriteLine("Hello, World!");

Thread[] our_thread = new Thread[3];
our_thread[0] = new Thread(() => DoTask(1));
our_thread[1] = new Thread(() => DoTask(2));
our_thread[2] = new Thread(() => DoTask(3));

foreach (Thread thhread in our_thread)
{
    thhread.Start();
}

static void DoTask(int TaskNumber)
{
    Console.WriteLine($"Implemening task Number {TaskNumber}");
    for (int i=0; i<=TaskNumber; i++)
    {
        Console.WriteLine($"Task Number {i}");
        Thread.Sleep(1000);
    }

}