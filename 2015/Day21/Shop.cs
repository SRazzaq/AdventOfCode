using System.Collections.Generic;

namespace Day21
{
    internal static class Shop
    {
        internal static List<Item> Weapons = new List<Item>
        {
            new Item { Name="Dagger",     Cost =  8, Damage = 4 },
            new Item { Name="Shortsword", Cost = 10, Damage = 5 },
            new Item { Name="Warhammer",  Cost = 25, Damage = 6 },
            new Item { Name="Longsword",  Cost = 40, Damage = 7 },
            new Item { Name="Greataxe",   Cost = 74, Damage = 8 }
        };

        internal static List<Item> Armors = new List<Item>
        {
            new Item { Name="No Armor",   Cost =   0, Armor = 0 },

            new Item { Name="Leather",    Cost =  13, Armor = 1 },
            new Item { Name="Chainmail",  Cost =  31, Armor = 2 },
            new Item { Name="Splintmail", Cost =  53, Armor = 3 },
            new Item { Name="Bandedmail", Cost =  75, Armor = 4 },
            new Item { Name="Platemail",  Cost = 102, Armor = 5 }
        };

        internal static List<Item> Rings = new List<Item>
        {
            new Item { Name="No Ring",  Cost =   0, Damage = 0 },

            new Item { Name="Damage +1",  Cost =  25, Damage = 1 },
            new Item { Name="Damage +2",  Cost =  50, Damage = 2 },
            new Item { Name="Damage +3",  Cost = 100, Damage = 3 },

            new Item { Name="Defense +1", Cost =  20, Armor =  1 },
            new Item { Name="Defense +2", Cost =  40, Armor =  2 },
            new Item { Name="Defense +3", Cost =  80, Armor =  3 }
        };
    }
}