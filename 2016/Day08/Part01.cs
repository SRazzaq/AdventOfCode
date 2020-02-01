using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day08
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

            var screen = new bool[50, 6];
            foreach (var line in lines)
            {
                if (line.StartsWith("rect"))
                {
                    var m = Regex.Match(line, @"rect (\d+)x(\d+)");

                    var w = int.Parse(m.Groups[1].Value);
                    var h = int.Parse(m.Groups[2].Value);

                    for (var x = 0; x < w; x++)
                        for (var y = 0; y < h; y++)
                            screen[x, y] = true;
                }
                else
                {
                    var m = Regex.Match(line, @"rotate (.*) .=(.*) by (.*)");

                    var direction = m.Groups[1].Value;
                    var a = int.Parse(m.Groups[2].Value);
                    var b = int.Parse(m.Groups[3].Value);

                    if (direction == "column")
                    {
                        var column = Enumerable.Range(0, screen.GetLength(1)).Select(y => screen[a, y]).ToArray();
                        for (int i = 0; i < screen.GetLength(1); i++)
                            screen[a, (i + b) % screen.GetLength(1)] = column[i];
                    }
                    else
                    {
                        var row = Enumerable.Range(0, screen.GetLength(0)).Select(x => screen[x, a]).ToArray();
                        for (int i = 0; i < screen.GetLength(0); i++)
                            screen[(i + b) % screen.GetLength(0), a] = row[i];
                    }
                }
            }

            var count = 0;
            for (var y = 0; y < screen.GetLength(1); y++)
            {
                for (var x = 0; x < screen.GetLength(0); x++)
                {
                    if (screen[x, y]) count++;
                }
            }

            Console.WriteLine($"Lights lit: {count}");
        }
    }
}