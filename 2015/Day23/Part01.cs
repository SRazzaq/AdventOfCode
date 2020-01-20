using System;

namespace Day23
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
            var computer = new Computer(lines);

            while (!computer.Halt)
                computer.Cycle();

            Console.WriteLine($"The value of register b is: {computer.b}");
        }
    }
}