using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace War
{
    public class WarEngine
    {
        private const int MAX_SPOILS = 3;
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WarEngine()
        {
            this.GameDeck.Shuffle();
        }

        private Deck _gameDeck = new Deck();
        /// <summary>
        /// Game Deck
        /// </summary>
        public Deck GameDeck
        {
            get { return _gameDeck; }
            set { _gameDeck = value; }
        }

        private Player _player1;
        /// <summary>
        /// Player 1
        /// </summary>
        public Player Player1
        {
            get { return _player1; }
            set { _player1 = value; }
        }

        private Player _player2;
        /// <summary>
        /// Player 2
        /// </summary>
        public Player Player2
        {
            get { return _player2; }
            set { _player2 = value; }
        }

        private StringBuilder _gameLog = new StringBuilder();
        /// <summary>
        /// Game log
        /// </summary>
        public StringBuilder GameLog
        {
            get { return _gameLog; }
            set { _gameLog = value; }
        }

        /// </summary>
        public void DealCards()
        {
            //accumulators
            int count = 1;

            //build each player deck - count kings to log
            foreach (Card card in GameDeck.Cards)
            {
                if (count % 2 == 0)
                {
                    Player2.Deck.Enqueue(card);
                }
                else
                {
                    Player1.Deck.Enqueue(card);
                }
                count++;
            }
        }

        /// <summary>
        /// Play Game
        /// </summary>
        public void PlayGame()
        {
            DealCards();
            
            //main loop
            do
            {
                CompareCards(null); 

                //log round
                GameLog.AppendLine(Player1.GetPlayerInfo());
                GameLog.AppendLine(Player2.GetPlayerInfo());
            } while (Player1.Deck.Count > 0 && Player2.Deck.Count > 0);
        }

        /// <summary>
        /// Compare cards played
        /// </summary>
        /// <param name="spoils"></param>
        private void CompareCards(List<Card> spoils)
        {
            //initialize spoils
            if (null == spoils)
                spoils = new List<Card>();

            //draw card to compare from player deck
            Card p1Card = Player1.Draw();
            Card p2Card = Player2.Draw();

            if(p1Card != null) spoils.Add(p1Card);
            if(p2Card != null) spoils.Add(p2Card);

            //log fight
            GameLog.AppendLine(string.Format("FIGHT -> {0} : {1} - {2} : {3} ", 
                Player1.Name, p1Card?.GetInfo() ?? "No Card Drawn", 
                Player2.Name, p2Card?.GetInfo() ?? "No Card Drawn"));
            
            //compare cards
            if (p2Card == null)
                Player1.AddToDeck(spoils);
            else if (p1Card == null)
                Player2.AddToDeck(spoils);
            else if ((int)p1Card.Rank > (int)p2Card.Rank)
                Player1.AddToDeck(spoils);
            else if ((int)p2Card.Rank > (int)p1Card.Rank)
                Player2.AddToDeck(spoils);
            else
            {
                //declare war
                GameLog.AppendLine("WAR---WAR---WAR---WAR---WAR---WAR");
                //log and add MAX_SPOILS cards to spoils
                for (int i = 0; i < MAX_SPOILS; i++)
                {
                    Card p1Spoils = Player1.Draw();
                    Card p2Spoils = Player2.Draw();

                    if (p1Spoils != null) spoils.Add(p1Spoils);
                    if (p2Spoils != null) spoils.Add(p2Spoils);

                    GameLog.AppendLine(string.Format("WAR -> {0} : {1} - {2} : {3} ",
                        Player1.Name, p1Spoils?.GetInfo() ?? "No Card Drawn",
                        Player2.Name, p2Spoils?.GetInfo() ?? "No Card Drawn"));
                }
                GameLog.AppendLine("WAR---WAR---WAR---WAR---WAR---WAR");
                //do it again
                CompareCards(spoils);
            }
        }
    }
}
