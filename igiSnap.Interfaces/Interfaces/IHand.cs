using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.Support.Interfaces
{
    public interface IHand : ICardCollection
    {
        ICard Take();
        ICard Peek();
    }
}
