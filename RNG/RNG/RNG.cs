using System;
using System.Collections.Generic;

namespace RNG
{
    public class Generator
    {
        public static List<decimal> Generate(int seed, long a, long c, long m, int max = 10_000)
        {
            List<decimal> results = new List<decimal>();
            long currentValue = 0;
            
            for (int i = 0; i < max; i++)
            {
                long previous = results.Count == 0 ? seed : currentValue;
                currentValue = (a * previous + c) % m; //;(a * previous + c) % m;
                results.Add((decimal)currentValue / m);
            }

            return results;
        }
    }
    
}