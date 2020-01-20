using System;

namespace Day20
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
            var num = int.Parse(input);

            var presents = new int[1000000];
            for (int i = 1; i < num / 10; i++)
            {
                for (int j = i; j < presents.Length; j += i)
                {
                    presents[j] += i * 10;
                }
            }

            var house = 1;
            while (presents[house] <= num) house++;
            Console.WriteLine($"Lowest house number: {house}");
        }
    }
}