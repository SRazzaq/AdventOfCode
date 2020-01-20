using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day13
{
    internal class Ranking : Dictionary<(string, string), int>
    {
        public Ranking(string input)
        {
            var lines = input.Split(Environment.NewLine);

            foreach (var line in lines)
            {
                var m = Regex.Match(line, @"(.*) would (.*) (\d*) happiness units by sitting next to (.*).");

                if (m.Groups[2].Value == "gain")
                    this.Add((m.Groups[1].Value, m.Groups[4].Value), int.Parse(m.Groups[3].Value));
                else
                    this.Add((m.Groups[1].Value, m.Groups[4].Value), -int.Parse(m.Groups[3].Value));
            }

        }
    }
}