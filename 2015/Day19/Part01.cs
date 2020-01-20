using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day19
{
    internal class Part01
    {
        private List<(string, string)> replacements = new List<(string, string)>();
        private string molecule;

        public Part01(string input)
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
            var transforms = new HashSet<string>();

            foreach (var replacement in replacements)
            {
                var length = replacement.Item1.Length;
                for (int i = 0; i < molecule.Length - length; i++)
                {
                    if (molecule.Substring(i, length) == replacement.Item1)
                    {
                        var transform = molecule.Substring(0, i) + replacement.Item2 + molecule.Substring(i + length);
                        transforms.Add(transform);
                    }
                }
            }

            Console.WriteLine($"Distinct molecules: {transforms.Count}");
        }
    }
}