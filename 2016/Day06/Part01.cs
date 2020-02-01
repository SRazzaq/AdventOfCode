using System;
using System.Collections.Generic;
using System.Linq;

namespace Day06
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

            var counters = new Dictionary<char, int>[lines[0].Length];
            for (var i = 0; i < counters.Length; i++)
                counters[i] = new Dictionary<char, int>();

            foreach (var line in lines)
            {
                for (var i = 0; i < line.Length; i++)
                {
                    if (!counters[i].ContainsKey(line[i])) counters[i].Add(line[i], 0);
                    counters[i][line[i]]++;
                }
            }

            var message = string.Empty;
            for (var i = 0; i < counters.Length; i++)
                message += counters[i].OrderByDescending(x => x.Value).First().Key;

            Console.WriteLine($"Message is: {message}");
        }
    }
}