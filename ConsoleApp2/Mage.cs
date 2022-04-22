using System;

namespace ConsoleApp2
{
    internal class Mage : Spec
    {
        public int mp;
        public int mpRegen;
        public string name = "mage";

        public Mage()
        {
            mp = 20;
            mpRegen = 5;
        }

        public Mage(int mp, int mpRegen)
        {
            this.mp = mp;
            this.mpRegen = mpRegen;
        }

        public override Type getType()
        {
            return typeof(Mage);
        }

        public Spell GetSpell()
        {
            return new() {spellDmg = 5, manacost = 5, cooldown = 5, debuff = new Buff {dur = 0}};
        }

        public override Spell UseSSpell()
        {
            return GetSpell();
        }
    }
}