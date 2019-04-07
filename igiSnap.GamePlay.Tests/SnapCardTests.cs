using igiSnap.Support.Enumerations;
using igiSnap.Support.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace igiSnap.GamePlay.Tests
{
    [TestClass]
    public class SnapCardTests
    {
        [TestMethod]
        public void SnapCardConstructRank()
        {
            // Arrange
            ICard card = new SnapCard(Suit.Spades, Rank.Ace);

            // Act
            // Nothing to do

            // Assert
            Assert.AreEqual(Rank.Ace, card.Rank);
        }

        [TestMethod]
        public void SnapCardConstructSuit()
        {
            // Arrange
            ICard card = new SnapCard(Suit.Spades, Rank.Ace);

            // Act
            // Nothing to do

            // Assert
            Assert.AreEqual(Suit.Spades, card.Suit);
        }
    }
}
