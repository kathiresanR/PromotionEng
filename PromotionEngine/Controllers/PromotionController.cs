using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PromotionEngine.Models;

namespace PromotionEngine.Controllers
{
        
    public class PromotionController : Controller
    {
        private IPromotionRepository repository;
        // GET: Promotion
        
        public PromotionController(IPromotionRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CalCulateOrderAmount(List<UnitPrice> unitPrices)
        {

            int output = 0;
            foreach (var unit in unitPrices)
            {

                if (unit.Value == null)
                {
                    unit.Value = 0;
                }

                if (unit.Value > 0)
                {
                    var activePromotion = this.repository.GetActivePromotion();

                    var findpromotion = activePromotion.Where(x => x.PromotionCode.Contains(unit.STUId)).FirstOrDefault();


                    if (findpromotion != null && unit.UnitQty > 0)
                    {
                        if (findpromotion.PromoQuantity < unit.UnitQty)
                        {
                            int x = Convert.ToInt32(unit.UnitQty) % findpromotion.PromoQuantity;

                            int y = Convert.ToInt32(unit.UnitQty / findpromotion.PromoQuantity);

                            int unitQ = unit.UnitQty - findpromotion.PromoQuantity;

                            output += ((y * findpromotion.Amount) + Convert.ToInt32(x * unit.Value));

                        }
                        else
                        {
                            if (findpromotion.PromoQuantity == unit.UnitQty)
                            {
                                if (unit.Value.HasValue)
                                {
                                    output += Convert.ToInt32(unit.UnitQty * unit.Value);
                                }
                                else
                                {
                                    output += findpromotion.Amount;
                                }
                            }
                            else
                            {
                                output += Convert.ToInt32(unit.UnitQty * unit.Value);
                            }
                        }
                    }
                    else
                    {
                        output += Convert.ToInt32(unit.UnitQty * unit.Value);
                    }
                }
            }
            var model = new OrderSummary();
            model.Total = output;
            return this.View(model);
        }
    }
}