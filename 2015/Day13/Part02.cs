﻿using System;
using System.Linq;

namespace Day13
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
            var maxHappiness = 0;

            var ranking = new Ranking(input);
            var guests = ranking.Keys.Select(x => x.Item1).Distinct().ToList();

            foreach (var guest in guests)
            {
                ranking.Add((guest, "You"), 0);
                ranking.Add(("You", guest), 0);
            }
            guests.Add("You");

            foreach (var seatingOrder in guests.Permutate())
            {
                var happiness = 0;
                for (int i = 0; i < seatingOrder.Count - 1; i++)
                {
                    happiness += ranking[(seatingOrder[i], seatingOrder[i + 1])];
                    happiness += ranking[(seatingOrder[i + 1], seatingOrder[i])];
                }

                happiness += ranking[(seatingOrder[seatingOrder.Count - 1], seatingOrder[0])];
                happiness += ranking[(seatingOrder[0], seatingOrder[seatingOrder.Count - 1])];

                if (happiness > maxHappiness) maxHappiness = happiness;
            }

            Console.WriteLine($"Maximum Happiness: {maxHappiness}");
        }
    }
}