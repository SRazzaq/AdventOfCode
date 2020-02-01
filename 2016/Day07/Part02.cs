using System;
using System.Collections.Generic;
using System.Linq;

namespace Day07
{
    internal class Part02
    {
        private string input;

        public Part02(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var lines = input.Split(Environment.NewLine);

            var sslCount = 0;
            foreach (var line in lines)
            {
                var parts = line.Split('[', ']');

                var aba = new List<(char, char)>();
                var bab = new List<(char, char)>();
                for (int i = 0; i < parts.Length; i++)
                {
                    if (i % 2 == 0)
                        aba.AddRange(GetBlocks(parts[i]));
                    else
                        bab.AddRange(GetBlocks(parts[i]));
                }

                if (aba.Any(x => bab.Contains((x.Item2, x.Item1)))) sslCount++;
            }

            Console.WriteLine($"IPs supporting SSL: {sslCount}");
        }

        private List<(char, char)> GetBlocks(string s)
        {
            var result = new List<(char, char)>();
            for (var i = 0; i <= s.Length - 3; i++)
            {
                if (s[i] == s[i + 2] && s[i] != s[i + 1]) result.Add((s[i], s[i + 1]));
            }

            return result;
        }
    }
}