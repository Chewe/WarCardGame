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
        public int KingCount { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Get Player Info
        /// </summary>
        /// <returns></returns>
        public string GetPlayerInfo()
        {
            return string.Format("{0}: {1} - {2} Cards", this.PlayerId, this.Name, this.Deck.Count);
        }

        /// <summary>
        /// Draw card from player deck
        /// </summary>
        /// <returns></returns>
        public Card Draw()
        {
            if (this.Deck.Count > 0)
                return this.Deck.Dequeue();
            else //if no cards to draw throw game loss
                throw new LossException(string.Format("Player Unable to Continue: {0} loses", this.Name));
        }

        /// <summary>
        /// Add list of cards to player deck
        /// </summary>
        /// <param name="cards"></param>
        public void AddToDeck(List<Card> cards)
        {
            foreach (Card card in cards)
                this.Deck.Enqueue(card);
        }

        #endregion
    }
}
