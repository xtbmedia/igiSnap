using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.GamePlay
{
    public class RankMajorSortedCardOrderingProvider : ICardOrderingProvider
    {
        public int GetSortKey(ICard card)
        {
            if (card == null)
                return 0;

            var rankValue = ((int)card.Rank) - 1;
            var suitValue = ((int)card.Suit) - 1;

            return 1 + (suitValue + 4 * rankValue);
        }
    }
}
