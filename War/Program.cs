using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace War
{
    /// <summary>
    /// Main Console Program
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            WarEngine engine = new WarEngine();

            //Create computer players
            engine.Player1 = new Player() { PlayerId = 1, Name = "Player One" };
            engine.Player2 = new Player() { PlayerId = 2, Name = "Player Two" };

            //play game
            engine.PlayGame();

            Console.WriteLine(engine.GameLog.ToString());

        }
    }
}
