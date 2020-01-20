using System;

namespace Day01
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
            var instructions = input.Split(", ");

            var heading = 'N';
            var location = (0, 0);

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
                switch (heading)
                {
                    case 'N': location.Item2 -= blocks; break;
                    case 'S': location.Item2 += blocks; break;
                    case 'W': location.Item1 -= blocks; break;
                    case 'E': location.Item1 += blocks; break;
                }
            }

            var distance = Math.Abs(location.Item1) + Math.Abs(location.Item2);
            Console.WriteLine($"Distance from origin: {distance}");
        }
    }
}