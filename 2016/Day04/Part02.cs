using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day04
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

            foreach (var line in lines)
            {
                var m = Regex.Match(line, @"(.*)-(\d*)\[(.*)\]");

                var name = m.Groups[1].Value;
                var sectorId = int.Parse(m.Groups[2].Value);
                var checksum = m.Groups[3].Value;

                if (IsRealRoom(name, checksum))
                {
                    if (Decrypt(name, sectorId) == "northpole object storage")
                    {
                        Console.WriteLine($"Northpole Object Storage is in sector: {sectorId}");
                    }
                }
            }
        }

        private bool IsRealRoom(string name, string checksum)
        {
            var calc = name.Replace("-", "").GroupBy(x => x).OrderByDescending(x => x.Count()).ThenBy(x => x.Key).Take(5).Select(x => x.Key).ToArray();
            return new string(calc) == checksum;
        }

        private string Decrypt(string name, int sectorId)
        {
            var result = new char[name.Length];

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == '-')
                    result[i] = ' ';
                else
                {
                    result[i] = (char)(name[i] + sectorId % 26);
                    if (result[i] > 'z') result[i] = (char)(result[i] - 26);
                }
            }

            return new string(result);
        }
    }
}