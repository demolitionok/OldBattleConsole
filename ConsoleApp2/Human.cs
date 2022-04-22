namespace ConsoleApp2
{
    internal class Human : Race
    {
        public string name = "human";

        public override Buff RSpell()
        {
            return new() {cAtk = 99, cDef = 0, dur = 3};
        }
    }
}