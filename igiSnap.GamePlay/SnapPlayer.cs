using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igiSnap.GamePlay
{
    public class SnapPlayer : IPlayer
    {
        private Random generator;

        public string Name { get; }
        public IHand Hand { get; }

        public SnapPlayer(string name, IHand hand)
        {
            Name = name;
            Hand = hand;
            generator = new Random();
        }

        public async Task<bool> CheckForMatchAsync(ICentralPile centralPile)
        {
            await Task.Delay(generator.Next(3000));
            var cards = centralPile.PeekCardsForTest();
            if (!cards.Any())
                return false;

            var condition = cards.First().Rank;

            return cards.All(o => o.Rank == condition);
        }

        public bool TakeTurn(ICentralPile centralPile, ICardTransport transport)
        {
            if (Hand.IsEmpty)
                return false;

            transport.Transfer(Hand, centralPile);
            return true;
        }
    }
}
