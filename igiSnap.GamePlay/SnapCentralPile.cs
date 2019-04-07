using igiSnap.Support;
using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace igiSnap.GamePlay
{
    public class SnapCentralPile : ICentralPile
    {
        private Stack<ICard> cards;

        public bool IsEmpty => !cards.Any();

        public bool HasSnapCondition
        {
            get
            {
                var check = GetAll();
                var top = check.First();
                var next = check.Skip(1).Take(1).First();
                return top.Rank == next.Rank;
            }
        }

        public SnapCentralPile()
        {
            cards = new Stack<ICard>();
        }

        public void Add(ICard card)
        {
            cards.Push(card);
        }

        public IEnumerable<ICard> GetAll()
        {
            return cards.ToArray();
        }

        public ICard Take()
        {
            return cards.Pop();
        }

        public int Count => cards?.Count() ?? 0;
    }
}
