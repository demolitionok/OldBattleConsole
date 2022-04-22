using System;

namespace ConsoleApp2
{
    public enum SpellType
    {
        FIRE = 1,
        POISON = 2
    }

    public struct Spell
    {
        public int spellDmg;
        public int manacost;
        public int cooldown;
        public Buff debuff;
        public SpellType type;
    }

    internal class Spec
    {
        public string name;
        public int spellCooldown;

        public virtual Type getType()
        {
            return typeof(Spec);
        }

        public virtual Spell UseSSpell()
        {
            return new();
        }
    }
}