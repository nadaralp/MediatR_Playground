using System;

namespace ConsoleAppPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = default(object);
            Console.WriteLine(d);
            Console.WriteLine(d == null);
        }
    }
}
