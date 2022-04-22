using System;

namespace ConsoleApp2
{
    internal class Rogue : Spec
    {
        public int crit;
        public int critChance;
        public string name = "Rogue";

        public override Type getType()
        {
            return typeof(Rogue);
        }

        public Spell GetSpell()
        {
            return new() {spellDmg = 0, manacost = 0, cooldown = 5, debuff = new Buff {dur = 3, cAtk = 2}};
        }

        public override Spell UseSSpell()
        {
            return GetSpell();
        }
    }
}