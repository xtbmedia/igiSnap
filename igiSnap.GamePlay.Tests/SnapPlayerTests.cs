using igiSnap.Support.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace igiSnap.GamePlay.Tests
{
    [TestClass]
    public class SnapPlayerTests
    {
        [TestMethod]
        public async Task PlayerCheckForMatchAsyncSucceedsWhenPresent()
        {
            // Arrange
            var hand = new SnapHand();
            var player = new SnapPlayer("Player 1", hand);
            var centralPile = new SnapCentralPile();

            centralPile.Add(new SnapCard(Suit.Hearts, Rank.Queen));
            centralPile.Add(new SnapCard(Suit.Clubs, Rank.Queen));

            // Act
            var test = await player.CheckForMatchAsync(centralPile);

            // Assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public async Task PlayerCheckForMatchAsyncFailsWhenNotPresent()
        {
            // Arrange
            var hand = new SnapHand();
            var player = new SnapPlayer("Player 1", hand);
            var centralPile = new SnapCentralPile();

            centralPile.Add(new SnapCard(Suit.Hearts, Rank.Queen));
            centralPile.Add(new SnapCard(Suit.Clubs, Rank.King));

            // Act
            var test = await player.CheckForMatchAsync(centralPile);

            // Assert
            Assert.IsFalse(test);
        }

        [TestMethod]
        public async Task PlayerCheckForMatchAsyncFailsWhenCentralPileIsEmpty()
        {
            // Arrange
            var hand = new SnapHand();
            var player = new SnapPlayer("Player 1", hand);
            var centralPile = new SnapCentralPile();

            // Act
            var test = await player.CheckForMatchAsync(centralPile);

            // Assert
            Assert.IsFalse(test);
        }
    }
}
