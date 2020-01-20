using System;
using System.Text.RegularExpressions;

namespace Day08
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
                sum += line.Length - (Regex.Unescape(line).Length - 2);
            }

            Console.WriteLine($"Space difference: {sum}");
        }
    }
}