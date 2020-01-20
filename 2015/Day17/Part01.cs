using System;
using System.Collections.Generic;
using System.Linq;

namespace Day17
{
    internal class Part01
    {
        private int EGGNOG = 150;
        private string input;

        internal Part01(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var containers = input.Split(Environment.NewLine).Select(x => int.Parse(x)).ToList();

            var combinations = CalculateCombinations(containers, 0, EGGNOG);
            Console.WriteLine($"Total combinations: {combinations}");
        }

        private int CalculateCombinations(IList<int> containers, int start, int eggnog)
        {
            if (eggnog < 0) return 0;
            if (eggnog == 0) return 1;

            int combinations = 0;
            for (int i=start; i<containers.Count; i++)
            {
                var container = containers[i];
                combinations += CalculateCombinations(containers, i + 1, eggnog - container);
            }
            return combinations;
        }
    }
}