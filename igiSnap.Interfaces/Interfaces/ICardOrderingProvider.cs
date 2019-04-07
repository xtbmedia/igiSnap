using System.Collections.Generic;

namespace igiSnap.Support.Interfaces
{
    public interface ICardOrderingProvider
    {
        int GetSortKey(ICard card);
    }
}
