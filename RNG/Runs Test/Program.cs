using System;
using System.Collections.Generic;
using System.Linq;

namespace Runs_Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            decimal[] data =
            {
                0, 0, 0, 1, 0, 1, 0, 1, 1, 1,
                0, 1, 1, 0, 0, 1, 1, 0, 1, 1,
                1, 1, 0, 0, 0, 0, 1, 1, 0, 1,
                1, 0, 1, 1, 0, 1, 0, 0, 0, 0,
                1, 1, 1, 1, 1, 0, 0, 0, 0, 0
            };

            data = trulyRandom(100);
            
            RunRunsTest(new List<decimal>(data));
        }

        public static void RunRunsTest(List<decimal> data)
        {
            var runs = 0;
            var direction = Direction.Unknown;

            var overallRuns = new List<List<decimal>>();
            var currentRun = new List<decimal> {data[0]};

            for (var i = 1; i < data.Count; i++)
            {
                var previous = data[i - 1];
                var current = data[i];

                var currentDirection = current == previous ? direction :
                    current > previous ? Direction.Ascending : Direction.Descending;
                if (currentDirection == direction)
                {
                    currentRun.Add(current);
                    continue;
                }

                direction = currentDirection;
                overallRuns.Add(currentRun);
                currentRun = new List<decimal> {current};
            }

            overallRuns.Add(currentRun);


            var N = data.Count;

            var observedRuns = overallRuns.GroupBy(x => x.Count)
                .ToDictionary(g => g.Key, g => g.Count());
            double chiZeroSquared = 0;

            for (int i = 1; i <= observedRuns.Max(x => x.Key); i++)
            {
                var expected = 2.0 / Factorial(i + 3)
                               * (N * (Math.Pow(i, 2) + 3.0 * i + 1.0)
                                  - (Math.Pow(i, 3) + 3.0 * Math.Pow(i, 2) - i - 4.0));
                var observed = observedRuns.ContainsKey(i) ? observedRuns[i] : 0;
                var chi = Math.Pow(observed - expected, 2) / expected;
                Console.WriteLine($"E({i}) = {Math.Round(expected, 2)}," +
                                  $" O({i}) = {observed}," +
                                  $" Chi Statistic({i}) = {chi}");
                chiZeroSquared += chi;
            }

            Console.WriteLine($"Chi Zero Squared: " + chiZeroSquared);
            Console.WriteLine($"Observed number of runs: {overallRuns.Count}");
        }

        public static decimal[] trulyRandom(int range)
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

        public static int Factorial(int n)
        {
            if (n == 0)
                return 1;

            return n * Factorial(n - 1);
        }
    }

    public enum Direction
    {
        Ascending,
        Descending,
        Unknown
    }
}