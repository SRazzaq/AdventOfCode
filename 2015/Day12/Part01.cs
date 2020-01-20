using System;
using System.Linq;
using System.Text.Json;

namespace Day12
{
    internal class Part01
    {
        private string input;

        public Part01(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var json = JsonDocument.Parse(input);
            var total = SumIntegers(json.RootElement);

            Console.WriteLine($"Sum of all numbers: {total}");
        }

        private static int SumIntegers(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Number: return element.GetInt32();
                case JsonValueKind.Array: return element.EnumerateArray().Select(x => SumIntegers(x)).Sum();
                case JsonValueKind.Object: return element.EnumerateObject().Select(x => SumIntegers(x.Value)).Sum();
                default: return 0;
            }
        }
    }
}