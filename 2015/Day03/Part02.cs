using System;
using System.Collections.Generic;
using System.Drawing;

namespace Day03
{
    internal class Part02
    {
        private string input;

        public Part02(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var map = new HashSet<Point>();

            var santaLocation = new Point(0, 0);
            map.Add(santaLocation);

            var roboLocation = new Point(0, 0);
            map.Add(santaLocation);

            int i = 0;
            while (i < input.Length)
            {
                santaLocation = santaLocation.Move(input[i++]);
                map.Add(santaLocation);

                roboLocation = roboLocation.Move(input[i++]);
                map.Add(roboLocation);
            }

            Console.WriteLine($"Housed with present: {map.Count}");
        }
    }
}