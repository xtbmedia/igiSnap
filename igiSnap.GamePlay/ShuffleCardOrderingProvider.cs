using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.GamePlay
{
    public class ShuffleCardOrderingProvider : ICardOrderingProvider
    {
        Random generator;

        public ShuffleCardOrderingProvider()
        {
            generator = new Random((int)(DateTime.Now.Ticks & int.MaxValue));
        }

        public int GetSortKey(ICard card)
        {
            return generator.Next();
        }
    }
}
