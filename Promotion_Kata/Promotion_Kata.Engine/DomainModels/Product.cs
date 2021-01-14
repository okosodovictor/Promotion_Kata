using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion_Kata.Engine.DomainModels
{
    public abstract class Product
    {
        //product unit price for each product on Cart
        public virtual decimal Price { get; }
    }
}
