using System;
using System.Collections.Generic;

namespace Day01
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
            var instructions = input.Split(", ");

            var heading = 'N';
            var location = (0, 0);

            var visited = new HashSet<(int, int)>();
            foreach (var instruction in instructions)
            {
                var turn = instruction[0];
                switch (heading)
                {
                    case 'N': heading = turn == 'R' ? 'E' : 'W'; break;
                    case 'S': heading = turn == 'R' ? 'W' : 'E'; break;
                    case 'W': heading = turn == 'R' ? 'N' : 'S'; break;
                    case 'E': heading = turn == 'R' ? 'S' : 'N'; break;
                }

                var blocks = int.Parse(instruction.Substring(1));
                for (int i = 0; i < blocks; i++)
                {
                    switch (heading)
                    {
                        case 'N': location.Item2--; break;
                        case 'S': location.Item2++; break;
                        case 'W': location.Item1--; break;
                        case 'E': location.Item1++; break;
                    }

                    if (visited.Contains(location))
                    {
                        var distance = Math.Abs(location.Item1) + Math.Abs(location.Item2);
                        Console.WriteLine($"Distance from origin: {distance}");
                        return;
                    }
                    else
                    {
                        visited.Add(location);
                    }
                }
            }
        }
    }
}