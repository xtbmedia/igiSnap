using igiSnap.Support.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.Support.Interfaces
{
    public interface ICard
    {
        Suit Suit { get; }
        Rank Rank { get; }
    }
}
