using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion_Kata.Engine.DomainModels
{
    public abstract class Product
    {
        public virtual decimal Price { get; }
    }
}
