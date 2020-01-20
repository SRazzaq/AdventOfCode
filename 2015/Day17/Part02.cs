using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Day17
{
    internal class Part02
    {
        private int EGGNOG = 150;
        private Dictionary<int, int> containersUsed = new Dictionary<int, int>();

        private string input;

        internal Part02(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var containers = input.Split(Environment.NewLine).Select(x => int.Parse(x)).ToList();

            CalculateMinCombinations(containers, 0, 0, EGGNOG);
            var minContainerCount = containersUsed[containersUsed.Keys.Min()];
            Console.WriteLine($"Total combinations: {minContainerCount}");
        }

        private void CalculateMinCombinations(IList<int> containers, int containerCount, int start, int eggnog)
        {
            if (eggnog < 0) return;
            if (eggnog == 0)
            {
                if (!containersUsed.ContainsKey(containerCount)) containersUsed.Add(containerCount, 0);
                containersUsed[containerCount]++;
            }

            for (int i = start; i < containers.Count; i++)
            {
                var container = containers[i];
                CalculateMinCombinations(containers, containerCount + 1, i + 1, eggnog - container);
            }
        }
    }
}