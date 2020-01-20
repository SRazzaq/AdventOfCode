using System;

namespace Day06
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
            var lines = input.Split(Environment.NewLine);

            var lights = new Lights();
            foreach (var line in lines)
            {
                lights.Adjust(line);
            }

            Console.WriteLine($"Lights Brightness: {lights.Output}");
        }
    }
}