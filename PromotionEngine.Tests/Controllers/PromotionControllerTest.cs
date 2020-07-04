using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PromotionEngine.Controllers;
using PromotionEngine.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PromotionEngine.Tests.Controllers
{
    [TestClass]
    public class PromotionControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void GetTotalOrderBySenarioA()
        {

         // Senario A

            List<UnitPrice> unitPrices = new List<UnitPrice>();

            UnitPrice unitPriceA = new UnitPrice();
            unitPriceA.STUId = "A";
            unitPriceA.Value = 50;
            unitPriceA.UnitQty = 1;
            unitPrices.Add(unitPriceA);

            UnitPrice unitPriceB = new UnitPrice();

            unitPriceB.STUId = "B";
            unitPriceB.Value = 30;
            unitPriceB.UnitQty = 1;
            unitPrices.Add(unitPriceB);

            UnitPrice unitPriceC = new UnitPrice();
            unitPriceC.STUId = "C";
            unitPriceC.Value = 20;
            unitPriceC.UnitQty = 1;
            unitPrices.Add(unitPriceC);
           
            IPromotionRepository promotionRepository = new PromotionRepository();

            var controller = new PromotionController(promotionRepository);

            var result = controller.CalCulateOrderAmount(unitPrices) as ViewResult;

            var data = result.Model as OrderSummary;

            Assert.AreEqual(100, data.Total, "Total Order Value not correct");

        }

        [TestMethod]
        public void GetTotalOrderBySenarioB()
        {

            //Senario B

            List<UnitPrice> unitPrices = new List<UnitPrice>();

            UnitPrice unitPriceA = new UnitPrice();
            unitPriceA.STUId = "A";
            unitPriceA.Value = 50;
            unitPriceA.UnitQty = 5;
            unitPrices.Add(unitPriceA);

            UnitPrice unitPriceB = new UnitPrice();

            unitPriceB.STUId = "B";
            unitPriceB.Value = 30;
            unitPriceB.UnitQty = 5;
            unitPrices.Add(unitPriceB);

            UnitPrice unitPriceC = new UnitPrice();
            unitPriceC.STUId = "C";
            unitPriceC.Value = 20;
            unitPriceC.UnitQty = 1;
            unitPrices.Add(unitPriceC);

            IPromotionRepository promotionRepository = new PromotionRepository();

            var controller = new PromotionController(promotionRepository);

            var result = controller.CalCulateOrderAmount(unitPrices) as ViewResult;

            var data = result.Model as OrderSummary;

            Assert.AreEqual(370, data.Total, "Total Order Value not correct");

        }
        [TestMethod]
        public void GetTotalOrderBySenarioC()
        {

            //Senario C

            List<UnitPrice> unitPrices = new List<UnitPrice>();

            UnitPrice unitPriceA = new UnitPrice();
            unitPriceA.STUId = "A";
            unitPriceA.Value = 50;
            unitPriceA.UnitQty = 5;
            unitPrices.Add(unitPriceA);

            UnitPrice unitPriceB = new UnitPrice();

            unitPriceB.STUId = "B";
            unitPriceB.Value = 30;
            unitPriceB.UnitQty = 5;
            unitPrices.Add(unitPriceB);

            UnitPrice unitPriceC = new UnitPrice();
            unitPriceC.STUId = "C";
            unitPriceC.Value = 20;
            unitPriceC.UnitQty = 1;
            unitPrices.Add(unitPriceC);

            IPromotionRepository promotionRepository = new PromotionRepository();

            var controller = new PromotionController(promotionRepository);

            var result = controller.CalCulateOrderAmount(unitPrices) as ViewResult;

            var data = result.Model as OrderSummary;

            Assert.AreEqual(370, data.Total, "Total Order Value not correct");

        }

    }
}
