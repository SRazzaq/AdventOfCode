using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day15
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

            var discs = new (int, int)[lines.Length];
            foreach (var line in lines)
            {
                var m = Regex.Match(line, @"Disc #(\d+) has (\d+) positions; at time=0, it is at position (\d+).");
                discs[int.Parse(m.Groups[1].Value) - 1] = (int.Parse(m.Groups[2].Value), int.Parse(m.Groups[3].Value));
            }

            var i = 0;
            bool done = false;
            while (!done)
            {
                done = Enumerable.Range(0, discs.Length).All(x => (discs[x].Item2 + i + (x+1)) % discs[x].Item1 == 0);
                i++;
            }

            Console.WriteLine($"Press the button at t: {i - 1}");
        }
    }
}