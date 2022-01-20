using System;
using System.Collections.Generic;
using System.Linq;

namespace Kolmogorov_Smirnov_Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<decimal> numbers = RNG.Generator.Generate(1337, 101427, 321, (int) Math.Pow(2, 16));
            List<decimal> first100 = numbers.Take(100).OrderBy(x => x).ToList();
            /*first100 = new List<decimal>();
            for (int i = 1; i <= 100; i++)
            {
                first100.Add(i * 0.01m);
            }*/
            //first100 = new List<decimal>(trulyRandom(100)).OrderBy(x => x).ToList();
            //first100 = new List<decimal>() { 0.05m, 0.14m, 0.44m, 0.81m, 0.93m};
            Test(first100);
        }

        public static void Test(List<decimal> input)
        {
            input = input.OrderBy(x => x).ToList();
            decimal max = decimal.MinValue;
            decimal min = decimal.MaxValue;
            for (int i = 1; i <= input.Count; i++)
            {
                var Ri = input[i - 1];
                var iN = (decimal) i / input.Count;
                decimal maxValue = (decimal) i / input.Count - Ri;
                if (maxValue > max && maxValue > 0)
                    max = maxValue;
                decimal minValue = Ri - (i - 1) / (decimal) input.Count;
                if (minValue < min && minValue > 0)
                    min = minValue;
            }

            decimal D = min > max ? min : max;


            var alpha001 = 1.63m / (decimal) Math.Sqrt(input.Count);
            var alpha005 = 1.36m / (decimal) Math.Sqrt(input.Count);
            var alpha010 = 1.22m / (decimal) Math.Sqrt(input.Count);
            Console.WriteLine($"For significance 0.01 = {alpha001}, D = {D}, Reject hypothesis = {!(alpha001 > D)}");
            Console.WriteLine($"For significance 0.05 = {alpha005}, D = {D}, Reject hypothesis = {!(alpha005 > D)}");
            Console.WriteLine($"For significance 0.10 = {alpha010}, D = {D}, Reject hypothesis = {!(alpha010 > D)}");
        }

        private static decimal[] trulyRandom(int range)
        {
            Random rng = new Random();
            decimal[] numbers = new decimal[range];
            for (int i = 0; i < range; i++)
            {
                byte scale = (byte) rng.Next(29);
                bool sign = rng.Next(2) == 1;
                numbers[i] = new decimal(rng.Next(), 
                    rng.Next(),
                    rng.Next(),
                    sign,
                    scale);
            }

            return numbers;
        }
    }
}