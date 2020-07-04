using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PromotionEngine.Models
{
    public class PromotionRepository : IPromotionRepository
    {
        public List<Promotion> GetActivePromotion()
        {
            List<Promotion> promotions = new List<Promotion>();

            Promotion promotionA = new Promotion();

            promotionA.PromotionId = 1;
            promotionA.PromotionCode = "A";
            promotionA.PromoQuantity = 3;
            promotionA.PromotionDescription = "3 of A's";
            promotionA.Amount = 130;
            promotions.Add(promotionA);

            Promotion promotionB = new Promotion();
            promotionB.PromotionId = 1;
            promotionB.PromotionCode = "B";
            promotionB.PromoQuantity = 2;
            promotionB.PromotionDescription = "2 of B's";
            promotionB.Amount = 45;
            promotions.Add(promotionB);

            Promotion promotionCD = new Promotion();

            promotionCD.PromotionId = 1;
            promotionCD.PromotionCode = "CD";
            promotionCD.PromoQuantity = 1;
            promotionCD.PromotionDescription = "C & D";
            promotionCD.Amount = 30;

            promotions.Add(promotionCD);


            return promotions;
        }
    }
}