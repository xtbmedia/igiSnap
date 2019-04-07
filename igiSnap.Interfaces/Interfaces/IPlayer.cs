using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace igiSnap.Support.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        IHand Hand { get; }

        Task<bool> CheckForMatchAsync(ICentralPile deck);
        bool TakeTurn(ICentralPile deck, ICardTransport transport);
    }
}
