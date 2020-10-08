using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var now = DateTime.Now;
            Console.WriteLine($"Hello World! {now.DayOfWeek}");
            Console.WriteLine($"Hello World! {now}");
            
        }
    }
}