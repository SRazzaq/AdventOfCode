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
            var floor = 0;

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '(') floor++;
                if (input[i] == ')') floor--;
            }

            Console.WriteLine($"Final Floor: {floor}");
        }
    }
}