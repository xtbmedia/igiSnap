using igiSnap.Support.Enumerations;
using igiSnap.Support.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace igiSnap.GamePlay.Tests
{
    [TestClass]
    public class SnapCardDeckTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeckConstrctionFailsWithoutOrderingProvider()
        {
            // Arrange
            // No setup

            // Act
            ICardDeck cardDeck = new SnapCardDeck(null);

            // Assert
            // Handled by test framework
        }

        [TestMethod]
        public void DeckCanAddCard()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);
            ICard card = new SnapCard(Suit.Spades, Rank.Ace);

            // Act
            cardDeck.Add(card);

            // Assert
            Assert.IsFalse(cardDeck.IsEmpty);
        }

        [TestMethod]
        public void DeckCanAddCorrectCard()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);
            ICard card = new SnapCard(Suit.Spades, Rank.Ace);

            // Act
            cardDeck.Add(card);

            // Assert
            var result = cardDeck.Peek();
            Assert.IsTrue(result.Suit == Suit.Spades && result.Rank == Rank.Ace);
        }

        [TestMethod]
        public void DeckCanTakeCard()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);
            ICard card = new SnapCard(Suit.Spades, Rank.Ace);

            // Act
            cardDeck.Add(card);
            var test = cardDeck.Take();

            // Assert
            Assert.IsTrue(cardDeck.IsEmpty);
        }

        [TestMethod]
        public void DeckReturnsNullOnTakeWhenEmpty()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);

            // Act
            var test = cardDeck.Take();

            // Assert
            Assert.IsNull(test);
        }

        [TestMethod]
        public void DeckReturnsNullOnPeekWhenEmpty()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);

            // Act
            var test = cardDeck.Peek();

            // Assert
            Assert.IsNull(test);
        }

        [TestMethod]
        public void DeckCanTakeCorrectCard()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);
            ICard card = new SnapCard(Suit.Spades, Rank.Ace);

            // Act
            cardDeck.Add(new SnapCard(Suit.Spades, Rank.Two));
            cardDeck.Add(card);
            cardDeck.Add(new SnapCard(Suit.Hearts, Rank.Queen));
            var test = cardDeck.Take();

            // Assert
            // As we're using the SortedCardOrderingProvider, the ace of spades should always be the 
            // top card in the deck. Given that Take() removes cards from the top of the deck, no matter
            // what we do, if the Ace of Spades is in the deck, Take() should return it.
            Assert.IsTrue(test.Suit == card.Suit && test.Rank == card.Rank);
        }

        [TestMethod]
        public void DeckMaintainsCorrectCount()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);

            // Act
            // Weirdly the deck is modelled on a pile of cards (rather than an actual deck) and therefore 
            // has no requirement that any given card be unique (which has odd implications 
            // for the SortedCardOrderingProvider!). We will abuse this fact by filling the deck up
            // with multiple instances of the same card

            for (int i = 0; i < 5; i++)   // Add 5
                cardDeck.Add(new SnapCard(Suit.Diamonds, Rank.Five));
            for (int i = 0; i < 3; i++)   // Remove 3
                cardDeck.Take();
            for (int i = 0; i < 200; i++)   // Add 200
                cardDeck.Add(new SnapCard(Suit.Diamonds, Rank.Five));

            // Assert
            Assert.IsTrue(cardDeck.Count == (5 - 3 + 200));
        }

        [TestMethod]
        public void DeckMaintainsCorrectCountThroughNegativeTake()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);

            // Act
            // Weirdly the deck is modelled on a pile of cards (rather than an actual deck) and therefore 
            // has no requirement that any given card be unique (which has odd implications 
            // for the SortedCardOrderingProvider!). We will abuse this fact by filling the deck up
            // with multiple instances of the same card

            for (int i = 0; i < 5; i++)   // Add 5
                cardDeck.Add(new SnapCard(Suit.Diamonds, Rank.Five));
            for (int i = 0; i < 150; i++)   // Try to remove 150, actually remove 5.
                cardDeck.Take();
            for (int i = 0; i < 200; i++)   // Add 200
                cardDeck.Add(new SnapCard(Suit.Diamonds, Rank.Five));

            // Assert
            Assert.IsTrue(cardDeck.Count == (5 - 5 + 200));
        }

        [TestMethod]
        public void DeckIsEmptyAfterDiscard()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);

            // Act
            for (int i = 0; i < 5; i++)   // Add 5
                cardDeck.Add(new SnapCard(Suit.Diamonds, Rank.Five));

            cardDeck.Discard();

            // Assert
            Assert.IsTrue(cardDeck.IsEmpty);
        }

        [TestMethod]
        public void DeckCanPeekCard()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);
            ICard card = new SnapCard(Suit.Spades, Rank.Ace);

            // Act
            cardDeck.Add(card);
            var test = cardDeck.Peek();

            // Assert
            Assert.IsFalse(cardDeck.IsEmpty);
        }

        [TestMethod]
        public void DeckCanPeekCorrectCard()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);
            ICard card = new SnapCard(Suit.Spades, Rank.Ace);

            // Act
            cardDeck.Add(new SnapCard(Suit.Spades, Rank.Two));
            cardDeck.Add(card);
            cardDeck.Add(new SnapCard(Suit.Hearts, Rank.Queen));

            var test = cardDeck.Peek();

            // Assert
            // As we're using the SortedCardOrderingProvider, the ace of spades should always be the 
            // top card in the deck. Given that Peek sees cards from the top of the deck, no matter
            // what we do, if the Ace of Spades is in the deck, Peek() should return it.
            Assert.IsTrue(test.Suit == card.Suit && test.Rank == card.Rank);
        }

        [TestMethod]
        public void DeckGetAllIsNonDestructive()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);

            // Act
            for (int i = 0; i < 200; i++)   // Add 200
                cardDeck.Add(new SnapCard(Suit.Diamonds, Rank.Five));
            var test = cardDeck.GetAll();

            // Assert
            Assert.IsFalse(cardDeck.IsEmpty);
        }

        [TestMethod]
        public void DeckCanReturnAllCards()
        {
            // Arrange
            ICardOrderingProvider cardOrderingProvider = new SortedCardOrderingProvider();
            ICardDeck cardDeck = new SnapCardDeck(cardOrderingProvider);

            // Act
            for (int i = 0; i < 200; i++)   // Add 200
                cardDeck.Add(new SnapCard(Suit.Diamonds, Rank.Five));
            var test = cardDeck.GetAll();

            // Assert
            Assert.IsTrue(test.Count() == 200);
        }

    }
}
