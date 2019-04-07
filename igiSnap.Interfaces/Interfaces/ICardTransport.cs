using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.Support.Interfaces
{
    public interface ICardTransport
    {
        void Transfer(ICentralPile centralPile, IHand hand);
        void Transfer(ICardDeck cardDeck, IHand hand);
        void Transfer(IHand hand, ICentralPile centralPile);
    }
}
