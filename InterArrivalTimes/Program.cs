using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace InterArrivalTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("FortLauderdaleHighway.csv");
            List<TimeSpan> arrivals = new List<TimeSpan>();
            foreach (var line in lines)
            {
                var regex = new Regex("00∶(?<minute>[0-9]){2}∶(?<second>[0-9]{2}),(?<milliesecond>[0-9]{2})");
                var match = regex.Match(line);
            }
        }
    }
}