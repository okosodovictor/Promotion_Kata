using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion_Kata.Engine.DomainModels
{
    public class ProductA: Product
    {
        public override decimal Price { get; } = 50;
    }
}
