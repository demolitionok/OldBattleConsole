using System;

namespace ConsoleApp2
{
    public struct Buff
    {
        public int cAtk;
        public int cDef;
        public int dur;
    }

    internal class Race
    {
        public string name;
        public int spellCooldown;

        public virtual Buff RSpell()
        {
            return new();
        }
    }
}