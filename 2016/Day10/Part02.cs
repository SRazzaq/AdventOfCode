using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day10
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

            var containers = new Dictionary<string, Container>();
            foreach (var line in lines)
            {
                if (line.StartsWith("bot"))
                {
                    var m = Regex.Match(line, @"(.*) gives low to (.*) and high to (.*)");

                    var id = m.Groups[1].Value;
                    var lowId = m.Groups[2].Value;
                    var highId = m.Groups[3].Value;

                    if (!containers.ContainsKey(id)) containers.Add(id, new Container());
                    if (!containers.ContainsKey(lowId)) containers.Add(lowId, new Container());
                    if (!containers.ContainsKey(highId)) containers.Add(highId, new Container());

                    containers[id].Low = containers[lowId];
                    containers[id].High = containers[highId];
                }
                else
                {
                    var m = Regex.Match(line, @"value (\d+) goes to (.*)");

                    var id = m.Groups[2].Value;
                    var val = int.Parse(m.Groups[1].Value);

                    if (!containers.ContainsKey(id)) containers.Add(id, new Container());

                    containers[id].Chips.Add(val);
                }
            }

            while (containers.Any(x => x.Value.Chips.Count > 1))
            {
                foreach (var container in containers.Where(x => x.Value.Chips.Count > 1).Select(x => x.Value))
                {
                    var min = container.Chips.Min();
                    var max = container.Chips.Max();

                    container.Low.Chips.Add(min);
                    container.High.Chips.Add(max);

                    container.Chips.Clear();
                }
            }

            var result = containers["output 0"].Chips[0] * containers["output 1"].Chips[0] * containers["output 2"].Chips[0];
            Console.WriteLine($"Multiplying outputs 0, 1 and 2: {result}");
        }
    }
}