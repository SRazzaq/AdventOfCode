using System;

namespace Day07
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
            var lines = input.Split(Environment.NewLine);

            var circuit = new Circuit(lines);
            circuit.Override("b", new Circuit(lines).GetSignal("a"));
            Console.WriteLine($"Signal on wire a: { circuit.GetSignal("a") }");
        }
    }
}