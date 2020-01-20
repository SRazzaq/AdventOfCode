using System;

namespace Day21
{
    internal class Part01
    {
        private Player boss;

        public Part01(string input)
        {
            var lines = input.Split(Environment.NewLine);
            boss = new Player
            {
                HitPoint = int.Parse(lines[0].Split(": ")[1]),
                Damage = int.Parse(lines[1].Split(": ")[1]),
                Armor = int.Parse(lines[2].Split(": ")[1])
            };

        }

        internal void Solve()
        {
            var minCost = int.MaxValue;

            foreach (var weapon in Shop.Weapons)
            {
                foreach (var armor in Shop.Armors)
                {
                    foreach (var ring1 in Shop.Rings)
                    {
                        foreach (var ring2 in Shop.Rings)
                        {
                            var you = new Player { HitPoint = 100 };
                            you.Equip(weapon);
                            you.Equip(armor);
                            you.Equip(ring1);
                            you.Equip(ring2);

                            if (you.Cost >= minCost) continue;
                            if (ring1.Name == "No Ring") {
                                if (ring2.Name != "No Ring") continue;
                            } else {
                                if (ring1 == ring2) continue;
                            }

                            if (you.Win(boss.Clone()) && you.Cost < minCost) minCost = you.Cost;
                        }
                    }
                }
            }

            Console.WriteLine($"Minimum cost: {minCost}");
        }
    }
}