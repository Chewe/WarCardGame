using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace War
{
    /// <summary>
    /// Deck
    /// </summary>
    public class Deck
    {
        #region Constructors
        public Deck()
        {
            this.Initialize();
        }
        #endregion

        #region Properties
        private List<Card> _cards = new List<Card>();
        /// <summary>
        /// Cards
        /// </summary>
        public List<Card> Cards
        {
            get { return _cards; }
            set { _cards = value; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Shuffle deck
        /// </summary>
        public void Shuffle()
        {
            var rand = new Random();
            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                Card temp = _cards[i];
                _cards[i] = _cards[n];
                _cards[n] = temp;
            }
        }

        /// <summary>
        /// Build deck - standard 52 card poker type deck
        /// </summary>
        public void Initialize()
        {
            List<Card> cards = new List<Card>();

            int count = 0;
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
                {
                    cards.Add(new Card()
                    {
                        CardId = count+1,
                        Suit = suit,
                        Rank = rank,
                    });
                    count++;
                }
            }
            this.Cards = cards;
        }

        #endregion
    }
}
