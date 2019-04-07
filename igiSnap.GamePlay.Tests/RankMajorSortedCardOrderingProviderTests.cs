using igiSnap.Support.Enumerations;
using igiSnap.Support.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.GamePlay.Tests
{
    [TestClass]
    public class RankMajorSortedCardOrderingProviderTests
    {
        [TestMethod]
        public void RankMajorSortedCardOrderingProviderNullCorrect()
        {
            // Arrange
            ICardOrderingProvider provider = new RankMajorSortedCardOrderingProvider();

            // Act
            var testKey = provider.GetSortKey(null);

            // Assert
            Assert.AreEqual(0, testKey);
        }

        [TestMethod]
        public void RankMajorSortedCardOrderingProviderAceSpadesCorrect()
        {
            // Arrange
            ICardOrderingProvider provider = new RankMajorSortedCardOrderingProvider();

            // Act
            ICard testCard = new SnapCard(Suit.Spades, Rank.Ace);
            var testKey = provider.GetSortKey(testCard);

            // Assert
            Assert.AreEqual(1, testKey);
        }

        [TestMethod]
        public void RankMajorSortedCardOrderingProviderFourSpadesCorrect()
        {
            // Arrange
            ICardOrderingProvider provider = new RankMajorSortedCardOrderingProvider();

            // Act
            ICard testCard = new SnapCard(Suit.Spades, Rank.Four);
            var testKey = provider.GetSortKey(testCard);

            // Assert
            Assert.AreEqual(13, testKey);
        }

        [TestMethod]
        public void RankMajorSortedCardOrderingProviderKingClubsCorrect()
        {
            // Arrange
            ICardOrderingProvider provider = new RankMajorSortedCardOrderingProvider();

            // Act
            ICard testCard = new SnapCard(Suit.Clubs, Rank.King);
            var testKey = provider.GetSortKey(testCard);

            // Assert
            Assert.AreEqual(52, testKey);
        }
    }
}
