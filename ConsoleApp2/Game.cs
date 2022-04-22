using System;

namespace ConsoleApp2
{
    internal class Game
    {
        private Unit attacker;
        private Unit defender;
        private readonly Orc krasava = new();

        private readonly Mage mage = new();
        private readonly Rogue pidoras = new();

        public Unit[] Team1 = new Unit[3];
        public Unit[] Team2 = new Unit[3];
        private readonly Human urod = new();

        public void SetTeams()
        {
            Team1[0] = new Unit(1, 3, 1, mage, krasava);
            Team1[1] = new Unit(2, 2, 1, pidoras, urod);
            Team1[2] = new Unit(3, 1, 1, mage, urod);

            Team2[0] = new Unit(3, 1, 1, pidoras, krasava);
            Team2[1] = new Unit(2, 2, 1, mage, urod);
            Team2[2] = new Unit(1, 3, 1, pidoras, urod);
        }

        private void ShowReport(Unit attacker, Unit victim, bool prepare = true)
        {
            if (prepare)
            {
                Console.WriteLine(attacker.ToString());
                Console.WriteLine("Attacks");
                Console.WriteLine(victim.ToString());
            }
            else
            {
                Console.WriteLine("Report :");
                Console.WriteLine("Victim stats : " + victim.ToString());
            }
        }

        private void ShowTeam(Unit[] team, string teamStr)
        {
            var pos = 0;
            Console.WriteLine(teamStr + " team:");
            foreach (var unit in team)
            {
                pos += 1;

                Console.WriteLine(pos + "|" + unit.ToString());
            }
        }

        public Unit ChoseUnit(Unit[] team2)
        {
            Console.WriteLine("Write Number of enemy to attack:");
            ShowTeam(team2, "Enemy");
            string line;
            var pos = 0;
            Unit enemy = null;
            while (pos == 0)
            {
                try
                {
                    line = Console.ReadLine();
                    pos = int.Parse(line);
                    if (pos < 1 || pos > team2.Length)
                    {
                        pos = 0;
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Your input is not between 1 and count of enemies.");
                    continue;
                }

                enemy = team2[pos - 1];
                if (enemy.isDead())
                {
                    pos = 0;
                    Console.WriteLine("This enemy is dead.");
                }
            }

            return enemy;
        }

        public void TeamAttack(Unit[] team1, Unit[] team2, string teamStr)
        {
            Console.WriteLine(teamStr + "'s turn.");
            ShowTeam(team1, "Your");
            var index = 0;
            string line;
            var pos = 0;
            Unit enemy = null;
            foreach (var unit in team1)
            {
                index++;
                if (unit.isDead())
                    continue;
                Console.WriteLine("You are " + index + " in your team");
                var ok = false;
                while (!ok)
                {
                    Console.WriteLine("Chose what to do: 1 to attack, 2 to use Race's spell, 3 to use Spec's spell.");
                    line = Console.ReadLine();
                    switch (line)
                    {
                        case "1":
                            enemy = ChoseUnit(team2);
                            unit.attack(enemy);
                            ok = true;
                            break;
                        case "2":
                            unit.UseRSpell();
                            ok = true;
                            break;
                        case "3":
                            enemy = ChoseUnit(team2);
                            ok = unit.UseSSpell(enemy);
                            break;
                    }
                }
            }
        }

        public void Battle()
        {
            TeamAttack(Team1, Team2, "Team1");
            Console.Clear();
            TeamAttack(Team2, Team1, "Team2");
            Tick();
            Console.Clear();
        }

        private void Tick()
        {
            foreach (var unit in Team1) unit.Tick();
            foreach (var unit in Team2) unit.Tick();
        }

        private bool attackerDead()
        {
            if (!attacker.isDead())
                return false;
            return true;
        }

        private bool defenderDead()
        {
            if (!defender.isDead())
                return false;
            return true;
        }

        private int GetWinner()
        {
            if (attackerDead())
            {
                Console.WriteLine("Enemy has killed you");
                return 0;
            }

            if (defenderDead())
            {
                Console.WriteLine("You have won");
                return 1;
            }

            return -1;
        }
    }
}