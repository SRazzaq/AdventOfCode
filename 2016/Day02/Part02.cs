using System;

namespace Day02
{
    internal class Part02
    {
        private string input;
        char[,] keypad = new char[5, 5]
        {
            {'.','.','1','.','.' },
            {'.','2','3','4','.' },
            {'5','6','7','8','9' },
            {'.','A','B','C','.' },
            {'.','.','D','.','.' },
        };

        public Part02(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var instructions = input.Split(Environment.NewLine);

            var location = (1, 3);
            var code = string.Empty;
            foreach (var instruction in instructions)
            {
                foreach (var direction in instruction)
                {
                    switch (direction)
                    {
                        case 'U':
                            if (location.Item2 > 0 && keypad[location.Item2 - 1, location.Item1] != '.')
                                location.Item2--;
                            break;
                        case 'D':
                            if (location.Item2 < keypad.GetLength(1) - 1 && keypad[location.Item2 + 1, location.Item1] != '.')
                                location.Item2++;
                            break;
                        case 'L':
                            if (location.Item1 > 0 && keypad[location.Item2, location.Item1 - 1] != '.')
                                location.Item1--;
                            break;
                        case 'R':
                            if (location.Item1 < keypad.GetLength(0) - 1 && keypad[location.Item2, location.Item1 + 1] != '.')
                                location.Item1++;
                            break;
                    }
                }

                code += keypad[location.Item2, location.Item1];
            }

            Console.WriteLine($"Bathroom code: {code}");
        }
    }
}