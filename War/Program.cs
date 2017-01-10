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
        private const int MAX_SPOILS = 3;

        static void Main(string[] args)
        {
            //create and shuffle card deck
            Deck deck = new Deck();
            Console.WriteLine("Shuffling...\n");
            deck.Shuffle();
            
            //Create computer players
            Player p1 = new Player() { PlayerId = 1, Name = "Player One" };
            Player p2 = new Player() { PlayerId = 2, Name = "Player Two" };

            //accumulators
            int p1KingCount = 0;
            int p2KingCount = 0;
            int count = 1;

            //build each player deck - count kings to log
            foreach (Card card in deck.Cards)
            {
                if (count % 2 == 0)
                {
                    if (card.Rank == Ranks.King)
                        p2KingCount++;
                    p2.Deck.Enqueue(card);
                }
                else
                {
                    if (card.Rank == Ranks.King)
                        p1KingCount++;
                    p1.Deck.Enqueue(card);
                }
                count++;
            }

            //main loop
            do
            {
                try
                {
                    CompareCards(p1, p2, null);
                }
                catch (LossException le)
                {
                    //if one player is unable to draw a card
                    //they throw a loss exception and the game is over
                    Console.WriteLine(p1.GetPlayerInfo());
                    Console.WriteLine(p2.GetPlayerInfo());
                    Console.WriteLine(le.Message);
                    break;
                }
                //log round
                Console.WriteLine(p1.GetPlayerInfo());
                Console.WriteLine(p2.GetPlayerInfo());
            } while (p1.Deck.Count > 0 && p2.Deck.Count > 0);
            //log king count and final outcome
            Console.WriteLine(string.Format("{0} : kingCount - {1}", p1.GetPlayerInfo(), p1KingCount));
            Console.WriteLine(string.Format("{0} : kingCount - {1}", p2.GetPlayerInfo(), p2KingCount));

        }

        /// <summary>
        /// Compare top card in player deck
        /// On tie declare WAR and add spoils
        /// Recurse into CompareCards
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="spoils"></param>
        private static void CompareCards(Player p1, Player p2, List<Card> spoils)
        {
            //initialize spoils
            if (null == spoils)
                spoils = new List<Card>();

            //draw card to compare from player deck
            Card p1Card = p1.Draw();
            Card p2Card = p2.Draw();

            //add cards to spoils
            spoils.Add(p1Card);
            spoils.Add(p2Card);

            //log fight
            Console.WriteLine("FIGHT -> {0} : {1} - {2} : {3} ", p1.Name, p1Card.GetInfo(), p2.Name, p2Card.GetInfo());
            //compare cards
            if ((int)p1Card.Rank > (int)p2Card.Rank)
            {
                foreach (Card card in spoils)
                    p1.Deck.Enqueue(card);
            }
            else if ((int)p2Card.Rank > (int)p1Card.Rank)
            {
                foreach (Card card in spoils)
                    p2.Deck.Enqueue(card);
            }
            else
            {
                //declare war
                Console.WriteLine("WAR---WAR---WAR---WAR---WAR---WAR");
                //log and add MAX_SPOILS cards to spoils
                for (int i = 0; i < MAX_SPOILS; i++)
                {
                    Card p1Spoils = p1.Draw();
                    Card p2Spoils = p2.Draw();
                    
                    Console.WriteLine("WAR -> {0} : {1} - {2} : {3} ", p1.Name, p1Spoils.GetInfo(), p2.Name, p2Spoils.GetInfo());
 
                    spoils.Add(p1Spoils);
                    spoils.Add(p2Spoils);
                }
                Console.WriteLine("WAR---WAR---WAR---WAR---WAR---WAR");
                //do it again
                CompareCards(p1, p2, spoils);
            }
        }
    }
}
