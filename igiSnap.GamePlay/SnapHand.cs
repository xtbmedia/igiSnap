using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace igiSnap.GamePlay
{
    public class SnapHand : IHand
    {
        private Queue<ICard> cards;

        public int Count => cards.Count();
        public bool IsEmpty => !cards.Any();

        public SnapHand()
        {
            cards = new Queue<ICard>();
        }

        public void Add(ICard card)
        {
            cards.Enqueue(card);
        }

        public ICard Peek()
        {
            return cards.Peek();
        }

        public ICard Take()
        {
            return cards.Dequeue();
        }

        public IEnumerable<ICard> GetAll()
        {
            return cards;
        }
    }
}
