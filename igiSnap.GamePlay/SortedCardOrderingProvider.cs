using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.GamePlay
{
    public class SortedCardOrderingProvider : ICardOrderingProvider
    {
        public int GetSortKey(ICard card)
        {
            if (card == null)
                return 0;

            var rankValue = ((int)card.Rank) - 1;
            var suitValue = ((int)card.Suit);

            return rankValue * 13 + suitValue;
        }
    }
}
