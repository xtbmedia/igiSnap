using Autofac;
using igiSnap.GamePlay;
using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igiSnap
{
    public static class SnapGameController
    {
        public static async Task<int> Main()
        {
            var container = GetConfiguredContainer();
            using (var scope = container.BeginLifetimeScope())
            {
                var game = new SnapGame(scope);
                IEnumerable<IPlayer> players = CreatePlayers(scope);
                ICardDealer dealer = CreateDealer(scope);
                var deck = CreateDeck(scope);
                ICardTransport transport = CreateTransport(scope);
                ICentralPile centralPile = CreateCentralPile(scope);

                await game.Play(players, dealer, deck, transport, centralPile);
                return game.HasWinner ? 1 : 0;
            }
        }

        private static ICentralPile CreateCentralPile(ILifetimeScope scope)
        {
            return scope.Resolve<ICentralPile>();
        }

        private static ICardTransport CreateTransport(ILifetimeScope scope)
        {
            return scope.Resolve<ICardTransport>();
        }

        private static ICardDealer CreateDealer(ILifetimeScope scope)
        {
            return scope.Resolve<ICardDealer>();
        }

        private static IEnumerable<IPlayer> CreatePlayers(ILifetimeScope scope)
        {
            return (from s in Enumerable.Range(1, 4)
                    select scope.Resolve<IPlayer>(new NamedParameter("name", $"Player {s:00}")))
                   .ToList();
        }

        private static ICardDeck CreateDeck(ILifetimeScope scope)
        {
            var cards = from suit in (IEnumerable<igiSnap.Support.Enumerations.Suit>)Enum.GetValues(typeof(igiSnap.Support.Enumerations.Suit))
                        from rank in (IEnumerable<igiSnap.Support.Enumerations.Rank>)Enum.GetValues(typeof(igiSnap.Support.Enumerations.Rank))
                        select scope.Resolve<ICard>(new NamedParameter("rank", rank),
                        new NamedParameter("suit", suit));

            var deck = scope.Resolve<ICardDeck>();

            foreach (var card in cards)
                deck.Add(card);

            return deck;
        }

        private static IContainer GetConfiguredContainer()
        {
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(SnapCard).Assembly)
                .Where(t => t != typeof(SortedCardOrderingProvider))
                .AsImplementedInterfaces();

            return builder.Build();

        }
    }
}
