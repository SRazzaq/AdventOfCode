using System;
using System.Text.RegularExpressions;

namespace Day25
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
            var m = Regex.Match(input, @"row (\d*), column (\d*)");
            var row = int.Parse(m.Groups[1].Value);
            var col = int.Parse(m.Groups[2].Value);

            Console.WriteLine($"Row: {row}, Column: {col}, Code: {Code(col, row)}");
        }

        internal long Code(int x, int y)
        {
            long v = 20151125;
            for (int i=1; i<ItemNumber(x,y); i++)
            {
                v = v * 252533 % 33554393;
            }
            return v;
        }

        internal int ItemNumber(int x, int y)
        {
            return (x*(x+2*y-1) + (y-2)*(y-1))/2;
        }
    }
}