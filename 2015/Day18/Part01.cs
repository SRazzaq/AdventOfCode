using System;

namespace Day18
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
            var lights = new Lights(input);

            for (int i = 0; i < 100; i++)
            {
                lights.Cycle();
            }

            Console.WriteLine($"Number of lights on: {lights.Count()}");
        }
    }
}