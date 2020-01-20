using System.Drawing;
using System.Text.RegularExpressions;

namespace Day06
{
    internal class Instruction
    {
        internal Instruction(string inst)
        {
            var m = Regex.Match(inst, @"(.*) (\d*),(\d*) through (\d*),(\d*)");

            Type = m.Groups[1].Value;
            From = new Point(int.Parse(m.Groups[2].Value), int.Parse(m.Groups[3].Value));
            To = new Point(int.Parse(m.Groups[4].Value), int.Parse(m.Groups[5].Value));
        }

        internal string Type { get; private set; }
        internal Point From { get; set; }
        internal Point To { get; set; }
    }
}