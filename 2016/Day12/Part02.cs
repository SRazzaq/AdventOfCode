using System;

namespace Day12
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
            var assembunny = new Assembunny(input);
            assembunny.Registers[2] = 1;
            assembunny.Run();
            Console.WriteLine($"Register a contains {assembunny.Registers[0]}");
        }
    }
}