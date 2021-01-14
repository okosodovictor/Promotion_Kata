using NUnit.Framework;
using Promotion_Kata.Engine.DomainModels;
using Promotion_Kata.Engine.Models;
using Promotion_Kata.Engine.Services;
using System.Collections.Generic;

namespace Promotion_Kata.Test
{
    public class PromotionServiceTest
    {
        private PromotionRule[] activePromotions;
        [SetUp]
        public void Setup()
        {
            activePromotions = PromotionService.GetActivePromotions();
        }

        /// <summary>
        ///Feature: Cart Item for Scenario A
        ///Given      1    * A	 50
        /// And       1	   * B	 30
        /// And       1	   * C	 20
        ///When active promotion rule is applied
        ///Then output should be 100
        /// </summary>
        [Test]
        public void Scenerio_A()
        {
            //Arrange
            var cart = new CartItem[] {
                    new CartItem( new ProductA(), 1 ),
                    new CartItem( new ProductB(), 1 ),
                    new CartItem( new ProductC(), 1 ),
            };

            //Act
            var actual = PromotionService.GetPrice(cart, activePromotions);
            Assert.AreEqual(100, actual);
        }

        /// <summary>
        ///Feature: Cart Item for Scenario B
        ///Given      5 * A	   130 + 2 * 50
        /// And       5	* B	   45 + 45 + 30
        /// And       1	* C	   20
        ///When active promotion rule is applied
        ///Then output should be 370
        /// </summary>
        [Test]
        public void Scenerio_B()
        {
            //Arrange
            var cart = new CartItem[] {
                    new CartItem( new ProductA(), 5 ),
                    new CartItem( new ProductB(), 5 ),
                    new CartItem( new ProductC(), 1 ),
            };

            //Act
            var actual = PromotionService.GetPrice(cart, activePromotions);
            Assert.AreEqual(370, actual);
        }

        /// <summary>
        ///Feature: Cart Item for Scenario C
        ///Given      3 * A	               130
        /// And       5	* B	               45 + 45 + 1 * 30
        /// And       1	* C	 & 1 * D	   30
        ///When active promotion rule is applied
        ///Then output should be 280
        /// </summary>
        [Test]
        public void Scenerio_C()
        {
            //Arrange
            var cart = new CartItem[] {
                    new CartItem( new ProductA(), 3 ),
                    new CartItem( new ProductB(), 5 ),
                    new CartItem( new ProductC(), 1 ),
                    new CartItem( new ProductD(), 1 ),
            };

            //Act
            var actual = PromotionService.GetPrice(cart, activePromotions);
            Assert.AreEqual(280, actual);
        }

        /// <summary>
        ///Feature: Cart Item for Scenario D
        ///Given      3 * A	          130
        /// And       3	* B	          45 + 1 * 45
        /// And       3	* C	 
        /// And       1 * D  
        ///When active promotion rule is applied  130 + 45 + 30 + 30 + 2 * 20
        ///Then output should be 275 
        /// </summary>
        [Test]
        public void Scenerio_D()
        {
            //Arrange
            var cart = new CartItem[] {
                    new CartItem( new ProductA(), 3 ),
                    new CartItem( new ProductB(), 3 ),
                    new CartItem( new ProductC(), 3 ),
                    new CartItem( new ProductD(), 1 ),
            };

            //Act
            var actual = PromotionService.GetPrice(cart, activePromotions);
            Assert.AreEqual(275, actual);
        }

        /// <summary>
        ///Feature: Cart Item for Scenario E
        ///Given      5 * A	         
        /// And       2	* B	         
        /// And       1	* C	     
        /// And       2 * D       
        ///When active promotion rule is applied 130  + 2 * 50 +  45 + 30  +  15
        ///Then output should be 320
        /// </summary>
        [Test]
        public void Scenerio_E()
        {
            //Arrange
            var cart = new CartItem[] {
                    new CartItem( new ProductA(), 5 ),
                    new CartItem( new ProductB(), 2 ),
                    new CartItem( new ProductC(), 1 ),
                    new CartItem( new ProductD(), 2 ),
            };

            //Act
            var actual = PromotionService.GetPrice(cart, activePromotions);
            Assert.AreEqual(320, actual);
        }
    }
}