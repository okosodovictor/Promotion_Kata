using Promotion_Kata.Engine.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion_Kata.Engine.Models
{
    public class CartItem
    {
		public Product Product { get; }
		public int Count { get; }
		public CartItem(Product product, int count)
		{
			Product = product;
			Count = count;
		}
	}
}
