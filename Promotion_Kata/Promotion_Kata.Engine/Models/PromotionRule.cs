using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion_Kata.Engine.Models
{
    public class PromotionRule
	{
		public Dictionary<Product, int> Ruleset { get; }
		public decimal Price { get; }

		public PromotionRule(Dictionary<Product, int> ruleset, decimal price)
		{
			Ruleset = ruleset;
			Price = price;
		}

		public bool Match(Dictionary<Product, int> cart)
		{
			//Make sure that the cart can support all the rules
			foreach (var rule in Ruleset)
			{
				if (!cart.ContainsKey(rule.Key) || cart[rule.Key] < rule.Value)
				{
					//If not return false meaning no match because one of the rules in the ruleset
					// was not met
					return false;
				}
			}

			//If all the rules in the ruleset are met
			//Reduce the cart by the value of the rules
			foreach (var rule in Ruleset)
			{
				cart[rule.Key] -= rule.Value;
			}

			//A Match was found and the cart has been reduced
			return true;
		}
	}
}
