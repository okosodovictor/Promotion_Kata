using Promotion_Kata.Engine.DomainModels;
using Promotion_Kata.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Promotion_Kata.Engine.Services
{
    public class PromotionService
    {
        public static decimal GetPrice(CartItem[] thecart, PromotionRule[] promotionRules)
        {
            //Generate a Dictionary mapping of ProductType -> count
            var cart = thecart.GroupBy(c => c.Product)
                              .Select(g => new { g.Key, Count = g.Sum(c => c.Count) })
                              .ToDictionary(g => g.Key, g => g.Count, new ProductComparer());
            var total = 0M;
            foreach (var rule in promotionRules)
            {
                bool isMatched = true;
                do
                {
                    isMatched = rule.Match(cart);
                    if (isMatched)
                    {
                        total += rule.Price;
                    }
                }
                while (isMatched == true);
            }
            //Resolve all the prices
            foreach (var entry in cart)
            {
                var product = entry.Key;
                var quantity = entry.Value;
                total += product.Price * quantity;
            }

            return total;
        }

        /// <summary>
        /// This is added here to return sample active promotions for a real 
        /// project this could come from files, database or external service.
        /// This is assume to be the promotion thatis active.
        /// </summary>

        public static PromotionRule[] GetActivePromotions()
        {
            return new[] {
                new PromotionRule(new Dictionary<Product, int> { { new ProductA(), 3} },130), // 3 A
                new PromotionRule(new Dictionary<Product, int> { { new ProductB(), 2 } },45),  // 2 B
                new PromotionRule(new Dictionary<Product, int> { { new ProductC(), 1 }, { new ProductD(), 1 } }, 30) // 1 C & 1 D
            };
        }
    }
}
