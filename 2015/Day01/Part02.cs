using System;

namespace Day01
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
            var floor = 0;

            var i = 0;
            while (floor >= 0)
            {
                if (input[i] == '(') floor++;
                if (input[i] == ')') floor--;

                i++;
            }

            Console.WriteLine($"Character Position: {i}");
        }
    }
}