using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day07
{
    internal class Circuit
    {
        private Dictionary<string, string> signals = new Dictionary<string, string>();
        private Dictionary<string, int> cache = new Dictionary<string, int>();

        internal Circuit(string[] lines)
        {
            foreach (var line in lines)
            {
                var m = Regex.Match(line, "(.*) -> (.*)");
                signals.Add(m.Groups[2].Value, m.Groups[1].Value);
            }
        }

        internal int GetSignal(string wire)
        {
            if (cache.ContainsKey(wire)) return cache[wire];

            if (ushort.TryParse(wire, out ushort x))
            {
                cache.Add(wire, x);
                return x;
            }
            else
            {
                string[] vars;
                int result;

                var src = signals[wire];
                if (src.Contains("AND"))
                {
                    vars = src.Split(" AND ");
                    result = GetSignal(vars[0]) & GetSignal(vars[1]);
                }
                else if (src.Contains("OR"))
                {
                    vars = src.Split(" OR ");
                    result = GetSignal(vars[0]) | GetSignal(vars[1]);
                }
                else if (src.Contains("LSHIFT"))
                {
                    vars = src.Split(" LSHIFT ");
                    result = GetSignal(vars[0]) << int.Parse(vars[1]);
                }
                else if (src.Contains("RSHIFT"))
                {
                    vars = src.Split(" RSHIFT ");
                    result = GetSignal(vars[0]) >> int.Parse(vars[1]);
                }
                else if (src.Contains("NOT"))
                {
                    vars = src.Split("NOT ");
                    result = ~GetSignal(vars[1]);
                }
                else
                {
                    result = GetSignal(src);
                }

                cache.Add(wire, result);
                return result;
            }
        }

        internal void Override(string wire, int value)
        {
            cache.Add(wire, value);
        }
    }
}