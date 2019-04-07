using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace igiSnap.GamePlay
{
    public class SnapHand : IHand
    {
        private Stack<ICard> cards;

        public int Count => cards.Count();
        public bool IsEmpty => !cards.Any();

        public SnapHand()
        {
            cards = new Stack<ICard>();
        }

        public void Add(ICard card)
        {
            cards.Push(card);
        }

        public ICard Peek()
        {
            return cards.Peek();
        }

        public ICard Take()
        {
            return cards.Pop();
        }

        public IEnumerable<ICard> GetAll()
        {
            return cards;
        }
    }
}
