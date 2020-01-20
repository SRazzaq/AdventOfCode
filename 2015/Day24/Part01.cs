using System;
using System.Linq;

namespace Day24
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
            var groups = 3;
            var weights = input.Split(Environment.NewLine).Select(long.Parse).ToList();

            var groupWeight = weights.Sum() / groups;
            for (int k = 0; k < weights.Count; k++)
            {
                foreach (var combination in weights.Combinations(k + 1))
                {
                    if (combination.Sum() == groupWeight)
                    {
                        var entanglement = combination.Aggregate<long, long>(1, (x, y) => x * y);
                        Console.WriteLine($"Entanglement of first group: {entanglement}");
                        return;
                    }
                }
            }
        }
    }
}