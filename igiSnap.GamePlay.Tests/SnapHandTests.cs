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
    public class SnapHandTests
    {
        [TestMethod]
        public void SnapHandAddOneCountOk()
        {
            IHand hand = new SnapHand();

            hand.Add(new SnapCard(Suit.Spades, Rank.Ace));

            Assert.AreEqual(1, hand.Count);
        }

        [TestMethod]
        public void SnapHandAddManyCountOk()
        {
            const int ExpectedCount = 5;

            IHand hand = new SnapHand();

            for(var i = 0; i < ExpectedCount; i++)
                hand.Add(new SnapCard(Suit.Spades, (Rank)(i + 1)));

            Assert.AreEqual(5, hand.Count);
        }

        [TestMethod]
        public void SnapHandAddOneCorrectCard()
        {
            IHand hand = new SnapHand();
            var card = new SnapCard(Suit.Spades, Rank.Ace);

            hand.Add(card);

            Assert.AreEqual(card, hand.Peek());
        }

        [TestMethod]
        public void SnapHandAddManyCorrectCards()
        {
            IHand hand = new SnapHand();
            var cards = new List<SnapCard> {
                new SnapCard(Suit.Spades, Rank.Ace),
                new SnapCard(Suit.Spades, Rank.Two),
                new SnapCard(Suit.Diamonds, Rank.Three),
                new SnapCard(Suit.Spades, Rank.Four),
                new SnapCard(Suit.Spades, Rank.Five)
            };

            foreach (var card in cards)
                hand.Add(card);

            Assert.IsTrue(hand.GetAll().SequenceEqual(cards));
        }

        [TestMethod]
        public void SnapHandPeekCorrectCard()
        {
            // Arrange
            IHand hand = new SnapHand();
            var cards = new List<SnapCard> {
                new SnapCard(Suit.Spades, Rank.Ace),
                new SnapCard(Suit.Spades, Rank.Two),
                new SnapCard(Suit.Diamonds, Rank.Three),
                new SnapCard(Suit.Spades, Rank.Four),
                new SnapCard(Suit.Spades, Rank.Five)
            };

            foreach (var card in cards)
                hand.Add(card);

            // Act
            var check = cards.First();
            var test = hand.Peek();

            Assert.AreEqual(check.Rank, test.Rank);
            Assert.AreEqual(check.Suit, test.Suit);
        }
    }
}
