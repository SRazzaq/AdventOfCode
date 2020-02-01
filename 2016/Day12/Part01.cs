using System;

namespace Day12
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
            var assembunny = new Assembunny(input);
            assembunny.Run();
            Console.WriteLine($"Register a contains {assembunny.Registers[0]}");
        }
    }
}