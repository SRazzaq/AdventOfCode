using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day04
{
    internal class Part01
    {
        private string input;

        public Part01(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var lines = input.Split(Environment.NewLine);

            var sum = 0;
            foreach (var line in lines)
            {
                var m = Regex.Match(line, @"(.*)-(\d*)\[(.*)\]");

                var name = m.Groups[1].Value;
                var sectorId = int.Parse(m.Groups[2].Value);
                var checksum = m.Groups[3].Value;

                if (IsRealRoom(name, checksum))
                    sum += sectorId;
            }

            Console.WriteLine($"Sum of the sector IDs: {sum}");
        }

        private bool IsRealRoom(string name, string checksum)
        {
            var calc = name.Replace("-", "").GroupBy(x => x).OrderByDescending(x => x.Count()).ThenBy(x => x.Key).Take(5).Select(x => x.Key).ToArray();
            return new string(calc) == checksum;
        }
    }
}