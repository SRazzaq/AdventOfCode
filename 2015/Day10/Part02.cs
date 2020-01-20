using System;

namespace Day10
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
            var text = input;
            for (int i = 0; i < 50; i++)
            {
                text = Part01.LookAndSay(text);
            }

            Console.WriteLine($"Length of result: {text.Length}");
        }
    }
}