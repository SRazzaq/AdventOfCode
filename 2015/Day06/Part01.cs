using System;

namespace Day06
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
            var lines = input.Split(Environment.NewLine);

            var lights = new Lights();
            foreach (var line in lines)
            {
                lights.Toggle(line);
            }

            Console.WriteLine($"Lights Brightness: {lights.Output}");
        }
    }
}