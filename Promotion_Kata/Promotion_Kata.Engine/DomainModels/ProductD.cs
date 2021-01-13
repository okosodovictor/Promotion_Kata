using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion_Kata.Engine.DomainModels
{
    public class ProductD:Product
    {
        public override decimal Price { get; } = 15;
    }
}
