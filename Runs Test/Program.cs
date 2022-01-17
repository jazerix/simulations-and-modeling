using System;
using System.Collections.Generic;
using System.Linq;

namespace Runs_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] data = {
                0, 0, 0, 1, 0, 1, 0, 1, 1, 1,
                0, 1, 1, 0, 0, 1, 1, 0, 1, 1,
                1, 1, 0, 0, 0, 0, 1, 1, 0, 1,
                1, 0, 1, 1, 0, 1, 0, 0, 0, 0,
                1, 1, 1, 1, 1, 0, 0, 0, 0, 0
            };

            var runs = 0;
            var direction = Direction.Unknown;

            var overallRuns = new List<List<decimal>>();
            var currentRun = new List<decimal> {data[0]};

            for (var i = 1; i < data.Length; i++)
            {
                var previous = data[i - 1];
                var current = data[i];

                var currentDirection = current == previous ? direction : current > previous ? Direction.Ascending : Direction.Descending;
                if (currentDirection == direction)
                {
                    currentRun.Add(current);
                    continue;
                }

                direction = currentDirection;
                overallRuns.Add(currentRun);
                currentRun = new List<decimal> { current };
            }
            overallRuns.Add(currentRun);


            var N = data.Length;

            var observedRuns = overallRuns.GroupBy(x => x.Count)
                .ToDictionary(g => g.Key, g => g.Count());
            double chiZeroSquared = 0;
            foreach (var observedRun in observedRuns.OrderBy(x => x.Key))
            {
                var i = observedRun.Key;
                var expected = 2.0 / Factorial(i + 3)
                               * (N * (Math.Pow(i, 2) + 3.0 * i + 1.0)
                                  - (Math.Pow(i, 3) + 3.0 * Math.Pow(i, 2) - i - 4.0));
                var chi = Math.Pow(observedRun.Value - expected, 2) / expected;
                Console.WriteLine($"E({i}) = {Math.Round(expected, 2)}," +
                                  $" O({i}) = {observedRun.Value}," +
                                  $" Chi Statistic({i}) = {chi}");
                chiZeroSquared += chi;
            }
            
           
            Console.WriteLine($"Chi Zero Squared: " + chiZeroSquared);
            Console.WriteLine($"Observed number of runs: {overallRuns.Count}");
            Console.ReadKey();
        }

        public static int Factorial(int n)
        {
            if (n == 0)
                return 1;
            
            return n * Factorial(n-1);
        }
    }

    public enum Direction
    {
        Ascending,
        Descending,
        Unknown
    }
}