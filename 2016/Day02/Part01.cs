using System;

namespace Day02
{
    internal class Part01
    {
        private string input;

        private char[,] keypad = new char[3, 3]
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        public Part01(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var instructions = input.Split(Environment.NewLine);

            var location = (1, 1);
            var code = string.Empty;
            foreach (var instruction in instructions)
            {
                foreach (var direction in instruction)
                {
                    switch (direction)
                    {
                        case 'U': if (location.Item2 > 0) location.Item2--; break;
                        case 'D': if (location.Item2 < keypad.GetLength(1)-1) location.Item2++; break;
                        case 'L': if (location.Item1 > 0) location.Item1--; break;
                        case 'R': if (location.Item1 < keypad.GetLength(0)-1) location.Item1++; break;
                    }
                }

                code += keypad[location.Item2, location.Item1];
            }

            Console.WriteLine($"Bathroom code: {code}");
        }
    }
}