using System;

namespace Day21
{
    internal class Player
    {
        internal int HitPoint { get; set; }

        internal int Damage { get; set; }

        internal int Armor { get; set; }

        internal int Cost { get; set; }

        internal void Equip(Item item)
        {
            this.Damage += item.Damage;
            this.Armor += item.Armor;
            this.Cost += item.Cost;
        }

        internal bool Win(Player other)
        {
            while (true)
            {
                other.HitPoint -= (this.Damage - other.Armor);
                if (other.HitPoint <= 0) return true;

                this.HitPoint -= (other.Damage - this.Armor);
                if (this.HitPoint <= 0) return false;
            }
        }

        internal Player Clone()
        {
            return (Player) MemberwiseClone();
        }
    }
}