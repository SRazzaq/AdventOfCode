using System.Collections.Generic;

namespace Day22
{
    internal class GameState
    {
        public GameState(int bossHitPoint, int bossDamage, int wizardHitPoint, int wizardMana)
        {
            this.BossHitPoint = bossHitPoint;
            this.BossDamage = bossDamage;

            this.WizardHitPoint = wizardHitPoint;
            this.WizardMana = wizardMana;
        }

        private List<Spell> allSpells = new List<Spell>
        {
            new Spell { Name = "Magic Missile", Cost = 53 },
            new Spell { Name = "Drain", Cost = 73 },
            new Spell { Name = "Shield", Cost = 113 },
            new Spell { Name = "Poison", Cost = 173 },
            new Spell { Name = "Recharge", Cost = 229 },
        };

        private int shieldCounter;
        private int poisonCounter;
        private int rechargeCounter;

        internal bool HardMode { get; set; }

        internal int BossHitPoint { get; private set; }

        internal int BossDamage { get; private set; }

        internal int WizardHitPoint { get; private set; }

        internal int WizardMana { get; private set; }

        internal int TotalCost { get; private set; }

        internal Spell ChosenSpell { get; set; }

        internal List<Spell> AvailableSpells
        {
            get
            {
                var spells = new List<Spell>();
                foreach (var spell in allSpells)
                {
                    if (spell.Cost <= WizardMana)
                    {
                        switch (spell.Name)
                        {
                            case "Magic Missile": spells.Add(spell); break;
                            case "Drain": spells.Add(spell); break;
                            case "Shield": if (shieldCounter == 0) spells.Add(spell); break;
                            case "Poison": if (poisonCounter == 0) spells.Add(spell); break;
                            case "Recharge": if (rechargeCounter == 0) spells.Add(spell); break;
                        }
                    }
                }

                return spells;
            }
        }

        internal void Fight()
        {
            if (HardMode) WizardHitPoint--;

            CastSpell();
            ApplyEffects();
            BossAttack();
            ApplyEffects();
        }

        private void CastSpell()
        {
            TotalCost += ChosenSpell.Cost;
            WizardMana -= ChosenSpell.Cost;

            switch (ChosenSpell.Name)
            {
                case "Magic Missile": BossHitPoint -= 4; break;
                case "Drain": BossHitPoint -= 2; WizardHitPoint += 2; break;
                case "Poison": poisonCounter = 6; break;
                case "Shield": shieldCounter = 6; break;
                case "Recharge": rechargeCounter = 5; break;
            }
        }

        private void BossAttack()
        {
            WizardHitPoint -= BossDamage;
            if (shieldCounter > 0) WizardHitPoint += 7;
        }

        private void ApplyEffects()
        {
            if (shieldCounter > 0)
            {
                shieldCounter--;
            }

            if (poisonCounter > 0)
            {
                poisonCounter--;
                BossHitPoint -= 3;
            }

            if (rechargeCounter > 0)
            {
                rechargeCounter--;
                WizardMana += 101;
            }
        }

        internal GameState Clone()
        {
            return (GameState)this.MemberwiseClone();
        }
    }
}