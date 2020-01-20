using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    internal class Part02
    {
        private const int RACE_DURATION = 2503;
        private string input;

        internal Part02(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var reindeers = new Reindeers(input);

            var points = new Dictionary<Reindeer, int>();
            foreach (var reindeer in reindeers) points.Add(reindeer, 0);

            for (int time = 1; time < RACE_DURATION; time++)
            {
                var distances = reindeers.ToDictionary(x => x, x => x.DistanceTravelled(time));

                var distanceWinners = distances.Where(x => x.Value == distances.Max(x => x.Value));
                foreach (var distanceWinner in distanceWinners)
                    points[distanceWinner.Key]++;
            }

            var winner = points.Where(x => x.Value == points.Max(x => x.Value)).First();
            Console.WriteLine($"{winner.Key.Name} won by scoring {winner.Value} points.");
        }
    }
}