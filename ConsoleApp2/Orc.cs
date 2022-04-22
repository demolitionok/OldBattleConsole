namespace ConsoleApp2
{
    internal class Orc : Race
    {
        public string name = "Orc";

        public override Buff RSpell()
        {
            return new() {cAtk = 0, cDef = 99, dur = 3};
        }
    }
}