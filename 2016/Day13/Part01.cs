using System;
using System.Drawing;

namespace Day13
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
            var maze = new Maze(int.Parse(input));
            var steps = maze.BFS(new Point(31, 39));

            Console.WriteLine($"It took {steps} to get to 31,39.");
        }
    }
}