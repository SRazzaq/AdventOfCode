using System;
using System.Linq;

namespace Day16
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
            var aunts = new Aunts(input);

            var aunt = aunts.First(x =>
                    (!x.Cats.HasValue        || x.Cats.Value > 7) &&
                    (!x.Trees.HasValue       || x.Trees.Value > 3) &&

                    (!x.Pomeranians.HasValue || x.Pomeranians.Value < 3) &&
                    (!x.Goldfish.HasValue    || x.Goldfish.Value < 5) &&

                    (!x.Children.HasValue    || x.Children.Value == 3) &&
                    (!x.Samoyeds.HasValue    || x.Samoyeds.Value == 2) &&
                    (!x.Akitas.HasValue      || x.Akitas.Value == 0) &&
                    (!x.Vizslas.HasValue     || x.Vizslas.Value == 0) &&
                    (!x.Cars.HasValue        || x.Cars.Value == 2) &&
                    (!x.Perfumes.HasValue    || x.Perfumes.Value == 1)
                );

            Console.WriteLine($"Number of Sue that got you the gift: {aunt.Name}");
        }
    }
}