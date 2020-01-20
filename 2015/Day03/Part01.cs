using System;
using System.Collections.Generic;
using System.Drawing;

namespace Day03
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
            var map = new HashSet<Point>();
            
            var location = new Point(0, 0);
            map.Add(location);

            foreach (var direction in input)
            {
                location = location.Move(direction);
                map.Add(location);
            }

            Console.WriteLine($"Housed with present: {map.Count}");
        }
    }
}