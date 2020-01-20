using System;

namespace Day04
{
    internal class Part01
    {
        private string input;

        internal Part01(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var suffix = AdventCoin.Mine(input, 5);
            Console.WriteLine($"Five zero suffix: {suffix}");
        }
    }
}