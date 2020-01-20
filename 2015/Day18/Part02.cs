using System;

namespace Day18
{
    internal class Part02
    {
        private string input;

        internal Part02(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var lights = new Lights(input);
            lights.CornersOn = true;

            for (int i = 0; i < 100; i++)
            {
                //lights.TurnOnCorners();
                lights.Cycle();
            }
            //lights.TurnOnCorners();
            Console.WriteLine($"Broken corner lights on: {lights.Count()}");
        }
    }
}