using System;
using System.Text.RegularExpressions;

namespace Day09
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
            var length = 0;

            var i = 0;
            while (i < input.Length)
            {
                if (input[i] == '(')
                {
                    var marker = string.Empty;
                    while (input[i] != ')') marker += input[i++];
                    marker += input[i++];

                    var m = Regex.Match(marker, @"\((\d+)x(\d+)\)");
                    var len = int.Parse(m.Groups[1].Value);
                    var rep = int.Parse(m.Groups[2].Value);

                    length += len * rep;
                    i += len;
                }
                else
                {
                    length++;
                    i++;
                }
            }

            Console.WriteLine($"Decompressed length: {length}");
        }
    }
}