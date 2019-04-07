using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.GamePlay
{
    public class SnapCardTransport : ICardTransport
    {
        public void Transfer(ICentralPile centralPile, IHand hand)
        {
            while (!centralPile.IsEmpty)
            {
                var buffer = centralPile.Take();
                hand.Add(buffer);
            }
        }

        public void Transfer(ICardDeck cardDeck, IHand hand)
        {
            var buffer = cardDeck.Take();
            hand.Add(buffer);
        }

        public void Transfer(IHand hand, ICentralPile centralPile)
        {
            var buffer = hand.Take();
            centralPile.Add(buffer);
        }
    }
}
