using System;
using System.Text.RegularExpressions;

namespace Day13
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
            var maze = new Maze(int.Parse(input));
            var reachable = maze.Reachable(50);

            Console.WriteLine($"You can reach {reachable} locations.");
        }
    }
}