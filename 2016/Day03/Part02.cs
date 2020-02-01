using System;
using System.Text.RegularExpressions;

namespace Day03
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

            var sides = new int[lines.Length, 3];
            for (var i = 0; i < lines.Length; i++)
            {
                var match = Regex.Match(lines[i], @"\s*(\d*)\s*(\d*)\s*(\d*)");

                sides[i, 0] = int.Parse(match.Groups[1].Value);
                sides[i, 1] = int.Parse(match.Groups[2].Value);
                sides[i, 2] = int.Parse(match.Groups[3].Value);
            }

            var valid = 0;
            for (var i = 0; i < sides.GetLength(0); i += 3)
            {
                for (var j = 0; j < sides.GetLength(1); j++)
                {
                    if (IsValidTriangle(sides[i, j], sides[i + 1, j], sides[i + 2, j])) valid++;
                }
            }

            Console.WriteLine($"Valid triangles: {valid}");
        }

        internal bool IsValidTriangle(int s1, int s2, int s3)
        {
            return (s1+s2>s3) & (s2+s3>s1) & (s3+s1>s2);
        }
    }
}