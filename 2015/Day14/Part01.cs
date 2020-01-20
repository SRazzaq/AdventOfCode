using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    internal class Part01
    {
        private const int RACE_DURATION = 2503;
        private string input;

        internal Part01(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var reindeers = new Reindeers(input);

            var distances = new Dictionary<Reindeer, int>();
            foreach (var reindeer in reindeers)
                distances.Add(reindeer, reindeer.DistanceTravelled(RACE_DURATION));

            var winner = distances.Where(x => x.Value == distances.Max(x => x.Value)).First();
            Console.WriteLine($"{winner.Key.Name} won by flying {winner.Value} km.");
        }
    }
}