using System;
using System.Collections.Generic;

namespace Day22
{
    internal class Part01
    {
        private GameState start;

        public Part01(string input)
        {
            var lines = input.Split(Environment.NewLine);

            var bossHitPoint = int.Parse(lines[0].Split(": ")[1]);
            var bossDamage = int.Parse(lines[1].Split(": ")[1]);

            start = new GameState(bossHitPoint, bossDamage, 50, 500);
        }

        internal void Solve()
        {
            var game = BreadthFirstSearch();
            Console.WriteLine(game.TotalCost);
        }

        private GameState BreadthFirstSearch()
        {
            var queue = new Queue<GameState>();
            foreach (var spell in start.AvailableSpells)
            {
                var clone = start.Clone();
                clone.ChosenSpell = spell;
                queue.Enqueue(clone);
            }

            while (queue.Count > 0)
            {
                var game = queue.Dequeue();

                if (game.BossHitPoint <= 0) return game;
                if (game.WizardHitPoint <= 0) continue;

                game.Fight();

                foreach (var spell in game.AvailableSpells)
                {
                    var clone = game.Clone();
                    clone.ChosenSpell = spell;
                    queue.Enqueue(clone);
                }
            }

            return null;
        }
    }
}