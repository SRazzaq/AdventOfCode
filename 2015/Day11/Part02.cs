using System;

namespace Day11
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
            var password = Part01.FindNextPassword(input);
            var nextPassword = Part01.FindNextPassword(password);

            Console.WriteLine($"Next Password: {nextPassword}");
        }
    }
}