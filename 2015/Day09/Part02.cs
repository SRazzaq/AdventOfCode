using System;
using System.Linq;

namespace Day09
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
            var longestDistance = 0;

            var routes = new Routes(input);
            var cities = routes.Select(x => x.Key.Item1).Distinct().ToList();
            foreach (var route in cities.Permutate())
            {
                var routeDistance = 0;
                for (int i = 0; i < route.Count - 1; i++)
                    routeDistance += routes[(route[i], route[i + 1])];

                if (longestDistance < routeDistance) longestDistance = routeDistance;
            }

            Console.WriteLine($"Longest Distance: {longestDistance}");
        }
    }
}