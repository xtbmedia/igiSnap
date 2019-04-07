using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.Support.Interfaces
{
    public interface ICentralPile : ICardCollection
    {
        ICard Take();
        IEnumerable<ICard> PeekCardsForTest();
    }
}
