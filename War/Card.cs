using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace War
{
    /// <summary>
    /// Card
    /// </summary>
    public class Card
    {
        #region Properties
        /// <summary>
        /// PlayerId
        /// </summary>
        public int PlayerId { get; set; }
        /// <summary>
        /// CardId
        /// </summary>
        public int CardId { get; set; }
        /// <summary>
        /// Suit
        /// </summary>
        public Suits Suit { get; set; }
        /// <summary>
        /// Rank
        /// </summary>
        public Ranks Rank { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get Card Info
        /// </summary>
        /// <returns></returns>
        public string GetCardInfo()
        {
            return string.Format("{0} of {1} : CardID: {2} : owned by {3}", this.Rank, this.Suit, this.CardId, this.PlayerId);
        }

        /// <summary>
        /// Get Info - short form
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return string.Format("{0} of {1}", this.Rank, this.Suit);
        }
        #endregion
    }

    /// <summary>
    /// Suits Enum
    /// </summary>
    public enum Suits
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades,
    }

    /// <summary>
    /// Ranks Enum
    /// </summary>
    public enum Ranks
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }
}
