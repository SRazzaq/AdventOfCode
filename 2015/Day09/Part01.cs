using System;
using System.Linq;

namespace Day09
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
            var shortestDistance = int.MaxValue;

            var routes = new Routes(input);
            var cities = routes.Select(x => x.Key.Item1).Distinct().ToList();
            foreach (var route in cities.Permutate())
            {
                var routeDistance = 0;
                for (int i = 0; i < route.Count - 1; i++)
                    routeDistance += routes[(route[i], route[i + 1])];

                if (routeDistance < shortestDistance) shortestDistance = routeDistance;
            }

            Console.WriteLine($"Shortest Distance: {shortestDistance}");
        }
    }
}