using System.Text.RegularExpressions;

namespace Day16
{
    internal class Aunt
    {
        public Aunt(string line)
        {
            var m1 = Regex.Match(line, @"(Sue \d*): (.*)");
            Name = m1.Groups[1].Value;

            var m2 = Regex.Match(m1.Groups[2].Value, @"(\w*): (\d*)");
            while (m2.Success)
            {
                switch (m2.Groups[1].Value)
                {
                    case "children": Children = int.Parse(m2.Groups[2].Value); break;
                    case "cats": Cats = int.Parse(m2.Groups[2].Value); break;
                    case "samoyeds": Samoyeds = int.Parse(m2.Groups[2].Value); break;
                    case "pomeranians": Pomeranians = int.Parse(m2.Groups[2].Value); break;
                    case "akitas": Akitas = int.Parse(m2.Groups[2].Value); break;
                    case "vizslas": Vizslas = int.Parse(m2.Groups[2].Value); break;
                    case "goldfish": Goldfish = int.Parse(m2.Groups[2].Value); break;
                    case "trees": Trees = int.Parse(m2.Groups[2].Value); break;
                    case "cars": Cars = int.Parse(m2.Groups[2].Value); break;
                    case "perfumes": Perfumes = int.Parse(m2.Groups[2].Value); break;
                }

                m2 = m2.NextMatch();
            }
        }

        public string Name { get; set; }
        public int? Children { get; set; }
        public int? Cats { get; set; }
        public int? Samoyeds { get; set; }
        public int? Pomeranians { get; set; }
        public int? Akitas { get; set; }
        public int? Vizslas { get; set; }
        public int? Goldfish { get; set; }
        public int? Trees { get; set; }
        public int? Cars { get; set; }
        public int? Perfumes { get; set; }
    }
}