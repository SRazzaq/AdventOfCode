﻿using System;

namespace Day15
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
            var ingredients = new Ingredients(input);

            var maxScore = 0;
            for (var sprinkles = 0; sprinkles <= 100; sprinkles++)
            {
                for (var butterscotch = 0; butterscotch <= 100 - sprinkles; butterscotch++)
                {
                    for (var chocolate = 0; chocolate <= 100 - butterscotch - sprinkles; chocolate++)
                    {
                        var candy = 100 - chocolate - butterscotch - sprinkles;

                        if (ingredients.Calories(sprinkles, butterscotch, chocolate, candy) <= 500)
                        {
                            int score = ingredients.Score(sprinkles, butterscotch, chocolate, candy);
                            if (maxScore < score) maxScore = score;
                        }
                    }
                }
            }

            Console.WriteLine($"Score for the highest scoring cookie: {maxScore}");
        }
    }
}