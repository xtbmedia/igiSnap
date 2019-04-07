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
    public class ShuffleCardOrderingProviderTests
    {
        [TestMethod]
        public void ShuffleCardOrderingProviderNullCorrect()
        {
            // Arrange
            ICardOrderingProvider provider = new ShuffleCardOrderingProvider();

            // Act
            var testKey = provider.GetSortKey(null);

            // Assert
            Assert.AreEqual(0, testKey);
        }

        [TestMethod]
        public void ShuffleCardOrderingProviderKeyChangesForSameCard()
        {
            // Arrange
            ICardOrderingProvider provider = new ShuffleCardOrderingProvider();
            var results = new List<bool>();

            // Act
            // Right, so if we pass the same card to ShuffleCardOrderingProvider, we should get two random
            // keys, which we would *expect* to be different, however, as they're random, they *could* be
            // the same. So, checking that they are different would result in the occasional non-repeatable
            // test failure.
            // 
            // So, we run the test 5 times. If we get the same 'random' key 10 times in a row, something has 
            // gone very wrong...

            for (int i = 0; i < 5; i++)
            {
                ICard testCard = new SnapCard(Suit.Spades, Rank.Ace);
                var testKey1 = provider.GetSortKey(testCard);
                var testKey2 = provider.GetSortKey(testCard);
                results.Add(testKey1 != testKey2);
            }

            // Assert
            Assert.IsTrue(results.All(t => t));
        }
    }
}
