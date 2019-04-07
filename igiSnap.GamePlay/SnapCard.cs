using igiSnap.Support.Enumerations;
using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.GamePlay
{
    public class SnapCard : ICard
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public SnapCard(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
