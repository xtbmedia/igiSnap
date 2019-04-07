using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.Support.Interfaces
{
    public interface ICentralPile : ICardCollection
    {
        bool HasSnapCondition { get; }

        ICard Take();
    }
}
