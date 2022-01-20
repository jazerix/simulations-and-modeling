using System;
using System.Collections.Generic;
using System.Linq;
using RNG;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> init = Generator.Generate(3758, 101427, 321, (int)Math.Pow(2, 16));
            List<decimal> RANDU = Generator.Generate(3758, 65539, 0, (long)Math.Pow(2,31));
            List<decimal> builtIn =   BuiltIn(10_000);
            
            Console.WriteLine("--- initial ---");
            Kolmogorov_Smirnov_Test.Program.Test(init.Take(100).ToList());
            Console.WriteLine("--- Randu ---");
            Kolmogorov_Smirnov_Test.Program.Test(RANDU.Take(100).ToList());
            Console.WriteLine("--- Built-in ---");
            Kolmogorov_Smirnov_Test.Program.Test(builtIn.Take(100).ToList());
            
            Console.WriteLine("\n\n--- Runs Test ---");
            Console.WriteLine("--- initial ---");
            Runs_Test.Program.RunRunsTest(init);
            Console.WriteLine("--- Randu ---");
            Runs_Test.Program.RunRunsTest(RANDU);
            Console.WriteLine("--- Built-in ---");
            Runs_Test.Program.RunRunsTest(builtIn);
        }
        
        private static List<decimal> BuiltIn(int range)
        {
            Random rng = new Random();
            List<decimal> decimals = new List<decimal>();
            for (int i = 0; i < range; i++)
                decimals.Add((decimal)rng.NextDouble());


            return decimals;
        }
    }
}