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
    public class SnapCardComparerTests
    {
        [TestMethod]
        public void SnapCardComparerComparesNullsAsEqual()
        {
            // Arrange
            IComparer<ICard> comparer = new SnapCardComparer();

            // Act
            var test = comparer.Compare(null, null);

            // Assert
            Assert.AreEqual(0, test);
        }

        [TestMethod]
        public void SnapCardComparerComparesEverythingGreaterThanNull()
        {
            // Arrange
            IComparer<ICard> comparer = new SnapCardComparer();

            // Act
            var test = comparer.Compare(null, new SnapCard(Suit.Spades, Rank.Ace));

            // Assert
            Assert.AreEqual(1, test);
        }

        [TestMethod]
        public void SnapCardComparerComparesNullLessThanEverything()
        {
            // Arrange
            IComparer<ICard> comparer = new SnapCardComparer();

            // Act
            var test = comparer.Compare(new SnapCard(Suit.Spades, Rank.Ace), null);

            // Assert
            Assert.AreEqual(-1, test);
        }

        [TestMethod]
        public void SnapCardComparerSortsNullToFirstInList()
        {
            // Arrange
            IComparer<ICard> comparer = new SnapCardComparer();
            List<ICard> cards = new List<ICard>();

            // Act
            cards.Add(null);
            cards.Add(new SnapCard(Suit.Spades, Rank.Ace));
            var test = cards.OrderBy(o => o, comparer);

            // Assert
            Assert.AreEqual(null, cards.First());
        }

        [TestMethod]
        public void SnapCardComparerComparesAcesAs1()
        {
            // Arrange
            IComparer<ICard> comparer = new SnapCardComparer();

            // Act
            var test = comparer.Compare(new SnapCard(Suit.Spades, Rank.Ace), new SnapCard(Suit.Spades, Rank.Two));

            // Assert
            Assert.AreEqual(-1, test);
        }
    }
}
