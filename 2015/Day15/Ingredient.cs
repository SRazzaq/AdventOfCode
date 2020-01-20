using System.Text.RegularExpressions;

namespace Day15
{
    internal class Ingredient
    {
        internal Ingredient(string line)
        {
            var m = Regex.Match(line, "(.*): capacity (.*), durability (.*), flavor (.*), texture (.*), calories (.*)");

            Name = m.Groups[1].Value;
            Capacity = int.Parse(m.Groups[2].Value);
            Durability = int.Parse(m.Groups[3].Value);
            Flavor = int.Parse(m.Groups[4].Value);
            Texture = int.Parse(m.Groups[5].Value);
            Calories = int.Parse(m.Groups[6].Value);
        }

        internal string Name { get; set; }
        internal int Capacity { get; set; }
        internal int Durability { get; set; }
        internal int Flavor { get; set; }
        internal int Texture { get; set; }
        internal int Calories { get; set; }
    }
}