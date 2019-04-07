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

        public IEnumerable<ICard> PeekCardsForTest()
        {
            var result = cards.Take(2).ToList();
            if (result.Count() < 2)
                return result.Take(0).ToList();

            return result;
        }

        public int Count => cards?.Count() ?? 0;
    }
}
