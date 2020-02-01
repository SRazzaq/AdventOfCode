using System;
using System.Text.RegularExpressions;

namespace Day03
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

            var valid = 0;
            foreach (var line in lines)
            {
                var match = Regex.Match(line, @"\s*(\d*)\s*(\d*)\s*(\d*)");

                var s1 = int.Parse(match.Groups[1].Value);
                var s2 = int.Parse(match.Groups[2].Value);
                var s3 = int.Parse(match.Groups[3].Value);

                if (IsValidTriangle(s1, s2, s3)) valid++;
            }

            Console.WriteLine($"Valid triangles: {valid}");
        }

        internal bool IsValidTriangle(int s1, int s2, int s3)
        {
            return (s1+s2>s3) & (s2+s3>s1) & (s3+s1>s2);
        }
    }
}