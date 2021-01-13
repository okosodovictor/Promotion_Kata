using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Promotion_Kata.Engine.Models
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals([AllowNull] Product x, [AllowNull] Product y)
        {
            return y.GetType() == x.GetType();
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return obj.GetType().ToString().GetHashCode();
        }
    }
}
