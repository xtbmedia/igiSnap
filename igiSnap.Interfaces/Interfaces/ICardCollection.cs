using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.Support.Interfaces
{
    public interface ICardCollection
    {
        bool IsEmpty { get; }
        int Count { get; }

        void Add(ICard card);
        IEnumerable<ICard> GetAll();
    }
}
