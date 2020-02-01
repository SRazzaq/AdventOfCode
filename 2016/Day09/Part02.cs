using System;
using System.Text.RegularExpressions;

namespace Day09
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
            var length = Expand(0, input.Length);
            Console.WriteLine($"Decompressed length: {length}");
        }

        internal long Expand(int start, int end)
        {
            long length = 0;

            var i = start;
            while (i < end)
            {
                if (input[i] == '(')
                {
                    var marker = string.Empty;
                    while (input[i] != ')') marker += input[i++];
                    marker += input[i++];

                    var m = Regex.Match(marker, @"\((\d+)x(\d+)\)");
                    var len = int.Parse(m.Groups[1].Value);
                    var rep = int.Parse(m.Groups[2].Value);

                    length += rep * Expand(i, i + len);
                    i += len;
                }
                else
                {
                    length++;
                    i++;
                }
            }

            return length;
        }
    }
}