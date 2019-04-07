using igiSnap.Support.Enumerations;
using igiSnap.Support.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.GamePlay.Tests
{
    [TestClass]
    public class SnapDealerTests
    {
        [TestMethod]
        public void DealerDealsCards()
        {
            // Arrange
            ICardTransport transport = new SnapCardTransport();
            ICardDealer dealer = new SnapCardDealer(transport);

            var players = new List<SnapPlayer> {
                new SnapPlayer("Player 1", new SnapHand()),
                new SnapPlayer("Player 2", new SnapHand()),
            };

            ICardOrderingProvider cardOrderingProvider = new SuitMajorSortedCardOrderingProvider();
            var deck = new SnapCardDeck(cardOrderingProvider);

            deck.Add(new SnapCard(Suit.Clubs, Rank.Ace));
            deck.Add(new SnapCard(Suit.Clubs, Rank.Nine));

            // Act
            dealer.Deal(deck, players);

            // Assert
            Assert.IsTrue(deck.IsEmpty);
            Assert.IsTrue(players.TrueForAll(p => !p.Hand.IsEmpty));
        }

        [TestMethod]
        public void DealerDealsCorrectCards()
        {
            // Arrange
            ICardTransport transport = new SnapCardTransport();
            ICardDealer dealer = new SnapCardDealer(transport);

            var player1 = new SnapPlayer("Player 1", new SnapHand());
            var player2 = new SnapPlayer("Player 2", new SnapHand());
            var players = new List<SnapPlayer> { player1, player2, };

            ICardOrderingProvider cardOrderingProvider = new SuitMajorSortedCardOrderingProvider();
            var deck = new SnapCardDeck(cardOrderingProvider);

            deck.Add(new SnapCard(Suit.Clubs, Rank.Ace));
            deck.Add(new SnapCard(Suit.Clubs, Rank.Nine));

            // Act
            dealer.Deal(deck, players);

            // Assert
            Assert.IsTrue(player1.Hand.Peek().Suit == Suit.Clubs && player1.Hand.Peek().Rank == Rank.Ace);
            Assert.IsTrue(player2.Hand.Peek().Suit == Suit.Clubs && player2.Hand.Peek().Rank == Rank.Nine);
        }

        [TestMethod]
        public void DeckIsEmptyAfterEvenlyDistributedDeal()
        {
            // Arrange
            ICardTransport transport = new SnapCardTransport();
            ICardDealer dealer = new SnapCardDealer(transport);

            var player1 = new SnapPlayer("Player 1", new SnapHand());
            var player2 = new SnapPlayer("Player 2", new SnapHand());
            var players = new List<SnapPlayer> { player1, player2, };

            ICardOrderingProvider cardOrderingProvider = new SuitMajorSortedCardOrderingProvider();
            var deck = new SnapCardDeck(cardOrderingProvider);

            deck.Add(new SnapCard(Suit.Clubs, Rank.Ace));
            deck.Add(new SnapCard(Suit.Clubs, Rank.Nine));

            // Act
            dealer.Deal(deck, players);

            // Assert
            Assert.IsTrue(deck.IsEmpty);
        }

        [TestMethod]
        public void DeckIsNotEmptyAfterUnevenlyDistributedDeal()
        {
            // Arrange
            ICardTransport transport = new SnapCardTransport();
            ICardDealer dealer = new SnapCardDealer(transport);

            var player1 = new SnapPlayer("Player 1", new SnapHand());
            var player2 = new SnapPlayer("Player 2", new SnapHand());
            var players = new List<SnapPlayer> { player1, player2, };

            ICardOrderingProvider cardOrderingProvider = new SuitMajorSortedCardOrderingProvider();
            var deck = new SnapCardDeck(cardOrderingProvider);

            deck.Add(new SnapCard(Suit.Clubs, Rank.Ace));
            deck.Add(new SnapCard(Suit.Clubs, Rank.Nine));
            deck.Add(new SnapCard(Suit.Spades, Rank.Seven));

            // Act
            dealer.Deal(deck, players);

            // Assert
            Assert.IsFalse(deck.IsEmpty);
        }
    }
}
