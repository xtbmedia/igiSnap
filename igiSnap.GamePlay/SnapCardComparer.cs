using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace igiSnap.GamePlay
{
    public class SnapCardComparer : Comparer<ICard>, IEqualityComparer<ICard>
    {
        public override int Compare(ICard x, ICard y)
        {
            if (x == null && y == null)
                return 0;

            if (x == null)
                return 1;

            if (y == null)
                return -1;

            return x.Rank.CompareTo(y.Rank);
        }

        public bool Equals(ICard x, ICard y)
        {
            return Compare(x, y) == 0;
        }

        public int GetHashCode(ICard obj)
        {
            if (obj == null)
                return 0;

            return (((int)obj.Suit - 1) * 13) + ((int)(obj.Rank - 1));
        }
    }
}
