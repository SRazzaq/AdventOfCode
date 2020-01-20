using System;
using System.Text.RegularExpressions;

namespace Day08
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

            var sum = 0;
            foreach (var line in lines)
            {
                sum += Regex.Escape(line).Replace("\"", "\\\"").Length + 2 - line.Length;
            }

            Console.WriteLine($"Space difference: {sum}");
        }
    }
}