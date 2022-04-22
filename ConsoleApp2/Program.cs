using System;

namespace ConsoleApp2
{

    internal class Program
    {
        
        private static void Main(string[] args)
        {
            var game = new Game();
            game.SetTeams();
            while (true) game.Battle();
        }
    }
}