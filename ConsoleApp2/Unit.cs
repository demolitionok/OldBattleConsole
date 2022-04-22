using System;

namespace ConsoleApp2
{
    internal class Unit
    {
        public int atk;
        public Buff buff;
        public int crit;
        public int critChance;
        public Buff debuff;
        public int def;
        public int hp;
        public int mp;
        public int mpRegen;
        
        private readonly Race race;
        private readonly Spec spec;

        public Unit(int atk, int hp, int def, Spec spec, Race race)
        {
            this.atk = atk;
            this.hp = hp;
            this.def = def;
            this.spec = spec;
            this.race = race;
            GetSpecValue();
        }

        public void GetSpecValue()//VOID :) (.)(.)
        {
            if (spec.getType() == typeof(Mage))
            {
                var mag = (Mage) spec;
                mp = mag.mp;
                mpRegen = mag.mpRegen;
            }
            else if (spec.getType() == typeof(Rogue))
            {
                var mag = (Rogue) spec;
                crit = mag.crit;
                critChance = mag.critChance;
            }
        }

        public void UseRSpell()
        {
            var buff = race.RSpell();
            this.buff = buff;
            atk += buff.cAtk;
            def += buff.cDef;
        }

        public bool UseSSpell(Unit enemy)
        {
            if (spec.spellCooldown == 0)
            {
                var sp = spec.UseSSpell();
                if (mp >= sp.manacost)
                {
                    mp -= sp.manacost;
                    enemy.hp -= sp.spellDmg;
                    if (sp.debuff.dur > 0) enemy.debuff = sp.debuff;

                    spec.spellCooldown = sp.cooldown;
                    return true;
                }

                Console.WriteLine("No mana.");
                return false;
            }

            Console.WriteLine("Cooldown.");
            return false;
        }

        public void Tick()
        {
            debuff.dur -= 1;
            buff.dur -= 1;
            spec.spellCooldown -= 1;
            mp += mpRegen;
            if (debuff.dur > 0) hp -= debuff.cAtk;

            if (buff.dur <= 0)
            {
                atk -= buff.cAtk;
                def -= buff.cDef;
            }
        }

        public bool isDead()
        {
            return hp <= 0;
        }

        public virtual void TakeDmg(DamageData dt)
        {
            var incomingDamage = dt.damage - def;
            if (incomingDamage < 1)
                incomingDamage = 1;

            hp -= incomingDamage;
        }

        public virtual void attack(Unit enemy)
        {
            DamageData dt;

            dt.damage = atk;

            enemy.TakeDmg(dt);
        }

        public string ToString()
        {
            return "HP:" + hp + " | DEF:" + def + " | ATK:" + atk +
                   (spec.GetType() == typeof(Mage) ? " Spec: Mage" : " Spec: Rogue") +
                   (race.GetType() == typeof(Orc) ? " Race: Orc" : " Race: Human");
        }

        public struct DamageData
        {
            public int damage;
        }
    }
}