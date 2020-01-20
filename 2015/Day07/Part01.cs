using System;

namespace Day07
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
            var lines = input.Split(Environment.NewLine);

            var circuit = new Circuit(lines);
            Console.WriteLine($"Signal on wire a: { circuit.GetSignal("a") }");
        }
    }
}