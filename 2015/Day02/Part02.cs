using System;
using System.Linq;

namespace Day02
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
            var lines = input.Split(Environment.NewLine);

            var totalRibbon = 0;
            foreach (var line in lines)
            {
                var nums = line.Split('x').Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
                int l = nums[0], w = nums[1], h = nums[2];

                var ribbon = l+l + w+w;
                var bow = l*w*h;

                totalRibbon += ribbon + bow;
            }

            Console.WriteLine($"Feet of ribbon: {totalRibbon}");
        }
    }
}