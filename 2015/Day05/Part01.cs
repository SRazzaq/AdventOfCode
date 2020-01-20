using System;
using System.Linq;

namespace Day05
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

            var niceCount = 0;
            foreach (var line in lines)
            {
                if (IsNice(line)) niceCount++;
            }

            Console.WriteLine($"Strings that are nice: {niceCount}");
        }

        private static bool IsNice(string s)
        {
            var badStrings = new string[] { "ab", "cd", "pq", "xy" };

            var atLeastThreeVowels = s.Count(x => "aeiou".Contains(x)) >= 3;
            var twoLettersInRow = s.Where((c, i) => i > 0 && s[i - 1] == s[i]).Any();
            var noBadString = !badStrings.Any(x => s.Contains(x));

            return atLeastThreeVowels && twoLettersInRow && noBadString;
        }
    }
}