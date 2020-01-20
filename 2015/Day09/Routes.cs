using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day09
{
    internal class Routes : Dictionary<(string, string), int>
    {
        public Routes(string input)
        {
            var lines = input.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                var m = Regex.Match(line, "(.*) to (.*) = (.*)");

                var from = m.Groups[1].Value;
                var to = m.Groups[2].Value;
                var distance = int.Parse(m.Groups[3].Value);

                this.Add((from, to), distance);
                this.Add((to, from), distance);
            }
        }
    }
}