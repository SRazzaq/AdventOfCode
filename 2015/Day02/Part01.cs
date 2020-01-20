using System;
using System.Linq;

namespace Day02
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

            var totalPaper = 0;
            foreach (var line in lines)
            {
                var nums = line.Split('x').Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
                int l = nums[0], w = nums[1], h = nums[2];

                var surfaceArea = (2*l*w) + (2*w*h) + (2*h*l);
                var littleExtra = l*w;

                totalPaper += surfaceArea + littleExtra;
            }

            Console.WriteLine($"Square feet of wrapping paper: {totalPaper}");
        }
    }
}