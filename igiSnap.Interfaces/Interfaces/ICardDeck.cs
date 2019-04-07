using System.Collections.Generic;

namespace igiSnap.Support.Interfaces
{
    public interface ICardDeck : ICardCollection
    {
        ICardDeck Shuffle();
        void Discard();
        ICard Take();
        ICard Peek();
    }
}
