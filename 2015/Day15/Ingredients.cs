using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    internal class Ingredients
    {
        private Ingredient sprinkles;
        private Ingredient butterscotch;
        private Ingredient chocolate;
        private Ingredient candy;

        public Ingredients(string input)
        {
            var lines = input.Split(Environment.NewLine);
            foreach (var line in lines)
            {
                var ingredient = new Ingredient(line);
                switch (ingredient.Name)
                {
                    case "Sprinkles" : sprinkles = ingredient; break;
                    case "Butterscotch": butterscotch = ingredient; break;
                    case "Chocolate": chocolate = ingredient; break;
                    case "Candy": candy = ingredient; break;
                }
            }
        }

        internal int Score(int sprinkleAmt, int butterscotchAmt, int chocolateAmt, int candyAmt)
        {
            var capacity = Capacity(sprinkleAmt, butterscotchAmt, chocolateAmt, candyAmt);
            var durability = Durability(sprinkleAmt, butterscotchAmt, chocolateAmt, candyAmt);
            var flavor = Flavor(sprinkleAmt, butterscotchAmt, chocolateAmt, candyAmt);
            var texture = Texture(sprinkleAmt, butterscotchAmt, chocolateAmt, candyAmt);

            return capacity * durability * flavor * texture;
        }

        internal int Capacity(int sprinkleAmt, int butterscotchAmt, int chocolateAmt, int candyAmt)
        {
            var capacity = sprinkleAmt * sprinkles.Capacity +
                           butterscotchAmt * butterscotch.Capacity +
                           chocolateAmt * chocolate.Capacity +
                           candyAmt * candy.Capacity;

            return Math.Max(0, capacity);
        }

        internal int Durability(int sprinkleAmt, int butterscotchAmt, int chocolateAmt, int candyAmt)
        {
            var durability = sprinkleAmt * sprinkles.Durability +
                             butterscotchAmt * butterscotch.Durability +
                             chocolateAmt * chocolate.Durability +
                             candyAmt * candy.Durability;

            return Math.Max(0, durability);
        }

        internal int Flavor(int sprinkleAmt, int butterscotchAmt, int chocolateAmt, int candyAmt)
        {
            var flavor = sprinkleAmt * sprinkles.Flavor +
                         butterscotchAmt * butterscotch.Flavor +
                         chocolateAmt * chocolate.Flavor +
                         candyAmt * candy.Flavor;

            return Math.Max(0, flavor);
        }

        internal int Texture(int sprinkleAmt, int butterscotchAmt, int chocolateAmt, int candyAmt)
        {
            var texture = sprinkleAmt * sprinkles.Texture +
                          butterscotchAmt * butterscotch.Texture +
                          chocolateAmt * chocolate.Texture +
                          candyAmt * candy.Texture;

            return Math.Max(0, texture);
        }

        internal int Calories(int sprinkleAmt, int butterscotchAmt, int chocolateAmt, int candyAmt)
        {
            var calories = sprinkleAmt * sprinkles.Calories +
                          butterscotchAmt * butterscotch.Calories +
                          chocolateAmt * chocolate.Calories +
                          candyAmt * candy.Calories;

            return Math.Max(0, calories);
        }
    }
}