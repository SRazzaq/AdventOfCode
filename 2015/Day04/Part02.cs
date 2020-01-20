using System;

namespace Day04
{
    internal class Part02
    {
        private string input;

        internal Part02(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var suffix = AdventCoin.Mine(input, 6);
            Console.WriteLine($"Six zero suffix: {suffix}");
        }
    }
}