﻿using Autofac;
using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igiSnap.GamePlay
{
    public class SnapGame
    {
        public bool HasWinner => Winner != null;
        public IPlayer Winner { get; private set; }

        private ILifetimeScope scope;

        public SnapGame(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public async Task Play(IEnumerable<IPlayer> players, ICardDealer dealer, ICardDeck deck, ICardTransport transport, ICentralPile centralPile)
        {
            deck.Shuffle();
            DumpState("Deck", players, centralPile.GetAll());

            dealer.Deal(deck, players);

            while (!HasWinner)
            {
                foreach (var player in players)
                {
                    player.TakeTurn(centralPile, transport);
                }

                DumpState("Play", players, centralPile.GetAll());
                await ProcessPlayerSnaps(players, centralPile, transport);

                if (players.Where(o => o.Hand.IsEmpty).Count() == (players.Count() - 1))
                {
                    var winner = (from p in players
                                  orderby p.Hand.Count descending
                                  select p)
                                 .Single();

                    Winner = winner;
                }
            }
        }

        private async Task ProcessPlayerSnaps(IEnumerable<IPlayer> players, ICentralPile centralPile, ICardTransport transport)
        {
            var results = (from p in players
                           select p)
                          .ToDictionary(k => k, v => v.CheckForMatchAsync(centralPile));

            var checkTask = await Task.WhenAny(Timeout(), Task.WhenAny(results.Values));

            var snappers = results.Where(o => o.Value.IsCompletedSuccessfully && o.Value.Result);

            if (snappers.Any())
            {
                var player = snappers.First().Key;
                transport.Transfer(centralPile, player.Hand);
                DumpState("Snap", players, centralPile.GetAll());
            }

            async Task<bool> Timeout()
            {
                await Task.Delay(3000);
                return false;
            }
        }

        private async Task<bool> Timeout()
        {
            await Task.Delay(3000);
            return false;
        }

        public void DumpState(string state, IEnumerable<IPlayer> players, IEnumerable<ICard> cards)
        {
            var maxLabelWith = Math.Max("Deck".Length, players.Max(o => o.Name.Length)) + 1;

            Console.WriteLine(state);
            Console.WriteLine(new string('-', 80));
            DumpStateLine("Deck".PadRight(maxLabelWith), cards);
            Console.WriteLine();
            foreach (var player in players)
            {
                DumpStateLine(player.Name.PadRight(maxLabelWith), player.Hand.GetAll());
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void DumpStateLine(string label, IEnumerable<ICard> cards)
        {
            Console.Write(label);
            Console.Write(string.Join(",", cards.Select(s => $"{s.Suit.ToString().First()}{(int)s.Rank:00}")));
        }
    }
}
