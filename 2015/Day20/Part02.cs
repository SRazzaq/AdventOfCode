using System;

namespace Day20
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
            var num = int.Parse(input);

            var presents = new int[1000000];
            for (int i = 1; i < num / 10; i++)
            {
                var j = i; var delivered = 0;
                while (delivered < 50 && j < presents.Length)
                {
                    presents[j] += i * 11;
                    delivered++;
                    j += i;
                }
            }

            var house = 1;
            while (presents[house] <= num) house++;
            Console.WriteLine($"Lowest house number: {house}");
        }
    }
}