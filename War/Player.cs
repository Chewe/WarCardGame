using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace War
{
    /// <summary>
    /// Player
    /// </summary>
    public class Player
    {
        #region Properties
        /// <summary>
        /// Player Id
        /// </summary>
        public int PlayerId { get; set; }
        /// <summary>
        /// Player Name
        /// </summary>
        public string Name { get; set; }

        private Queue<Card> _deck = new Queue<Card>();
        /// <summary>
        /// Player Deck
        /// </summary>
        public Queue<Card> Deck
        {
            get { return _deck; }
            set { _deck = value; }
        }

        /// <summary>
        /// KingCount
        /// </summary>
        public int KingCount 
        { 
            get { return Deck.ToList().Count(c => c?.Rank == Ranks.King); }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Get Player Info
        /// </summary>
        /// <returns></returns>
        public string GetPlayerInfo()
        {
            return $"{PlayerId}: {Name} - {Deck.Count} Cards - {KingCount} Kings";
        }

        /// <summary>
        /// Draw card from player deck
        /// </summary>
        /// <returns></returns>
        public Card Draw()
        {
            if (Deck.Count <= 0) return null;
            
            return Deck.Dequeue();
        }

        /// <summary>
        /// Add list of cards to player deck
        /// </summary>
        /// <param name="cards"></param>
        public void AddToDeck(List<Card> cards)
        {
            foreach (Card card in cards)
                Deck.Enqueue(card);
        }

        #endregion
    }
}
