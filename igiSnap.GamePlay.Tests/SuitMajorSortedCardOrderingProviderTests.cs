using igiSnap.Support.Enumerations;
using igiSnap.Support.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.GamePlay.Tests
{
    [TestClass]
    public class SuitMajorSortedCardOrderingProviderTests
    {
        [TestMethod]
        public void SuitMajorSortedCardOrderingProviderNullCorrect()
        {
            // Arrange
            ICardOrderingProvider provider = new SuitMajorSortedCardOrderingProvider();

            // Act
            var testKey = provider.GetSortKey(null);

            // Assert
            Assert.AreEqual(0, testKey);
        }

        [TestMethod]
        public void SuitMajorSortedCardOrderingProviderAceSpadesCorrect()
        {
            // Arrange
            ICardOrderingProvider provider = new SuitMajorSortedCardOrderingProvider();

            // Act
            ICard testCard = new SnapCard(Suit.Spades, Rank.Ace);
            var testKey = provider.GetSortKey(testCard);

            // Assert
            Assert.AreEqual(1, testKey);
        }

        [TestMethod]
        public void SuitMajorSortedCardOrderingProviderFourSpadesCorrect()
        {
            // Arrange
            ICardOrderingProvider provider = new SuitMajorSortedCardOrderingProvider();

            // Act
            ICard testCard = new SnapCard(Suit.Spades, Rank.Four);
            var testKey = provider.GetSortKey(testCard);

            // Assert
            Assert.AreEqual(4, testKey);
        }

        [TestMethod]
        public void SuitMajorSortedCardOrderingProviderKingClubsCorrect()
        {
            // Arrange
            ICardOrderingProvider provider = new SuitMajorSortedCardOrderingProvider();

            // Act
            ICard testCard = new SnapCard(Suit.Clubs, Rank.King);
            var testKey = provider.GetSortKey(testCard);

            // Assert
            Assert.AreEqual(52, testKey);
        }
    }
}
