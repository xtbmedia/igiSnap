using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.Support.Interfaces
{
    public interface ICardDealer
    {
        void Deal(ICardDeck cardDeck, IEnumerable<IPlayer> players);
    }
}
