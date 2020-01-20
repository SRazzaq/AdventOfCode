using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day19
{
    internal class Part02
    {
        private List<(string, string)> replacements = new List<(string, string)>();
        private string molecule;

        public Part02(string input)
        {
            var lines = input.Split(Environment.NewLine);
            for (int i = 0; i < lines.Length - 2; i++)
            {
                var m = Regex.Match(lines[i], @"(.*) => (.*)");
                replacements.Add((m.Groups[1].Value, m.Groups[2].Value));
            }

            molecule = lines[lines.Length - 1];
        }

        internal void Solve()
        {
            var steps = 0;

            while (molecule != "e")
            {
                foreach (var replacement in replacements)
                {
                    var i = molecule.IndexOf(replacement.Item2);
                    if (i >= 0)
                    {
                        molecule = molecule.Substring(0, i) + replacement.Item1 + molecule.Substring(i + replacement.Item2.Length);
                        steps++;
                    }
                }
            }

            Console.WriteLine($"Steps to make medicine {steps}");
        }
    }
}