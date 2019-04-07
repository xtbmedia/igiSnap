using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace igiSnap.GamePlay
{
    public class SnapCardDeck : ICardDeck
    {
        private class DeckItem
        {
            public int Key { get; set; }
            public ICard Card { get; set; }
        }

        private IList<DeckItem> cards;
        private ICardOrderingProvider orderingProvider;

        public SnapCardDeck(ICardOrderingProvider orderingProvider)
        {
            this.orderingProvider = orderingProvider ?? throw new ArgumentNullException(nameof(orderingProvider));
            cards = new List<DeckItem>();
        }

        public bool IsEmpty => !cards.Any();

        public int Count => cards.Count();

        public void Add(ICard card)
        {
            var sortKey = orderingProvider.GetSortKey(card);
            cards.Add(new DeckItem { Key = sortKey, Card = card });
        }

        public void Discard()
        {
            cards.Clear();
        }

        public IEnumerable<ICard> GetAll()
        {
            return from item in cards.OrderBy(o => o.Key) select item.Card;
        }

        public ICardDeck Shuffle()
        {
            foreach (var item in cards)
                item.Key = orderingProvider.GetSortKey(item.Card);

            return this;
        }

        public ICard Take()
        {
            var result = cards.OrderBy(o => o.Key).FirstOrDefault();
            if (result == null)
                return null;

            cards.Remove(result);
            return result.Card;
        }

        public ICard Peek()
        {
            return cards.OrderBy(o => o.Key).FirstOrDefault()?.Card;
        }
    }
}
