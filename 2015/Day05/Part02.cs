using System;
using System.Linq;

namespace Day05
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

            var niceCount = 0;
            foreach (var line in lines)
            {
                if (IsNice(line)) niceCount++;
            }

            Console.WriteLine($"Strings that are nice: {niceCount}");
        }

        private static bool IsNice(string s)
        {
            var twoDoubles = Enumerable.Range(0, s.Length - 1).Any(i => s.IndexOf(s.Substring(i, 2), i + 2) >= 0);
            var repeatWithOne = s.Where((c, i) => i > 1 && s[i - 2] == s[i]).Any();

            return twoDoubles && repeatWithOne;
        }
    }
}