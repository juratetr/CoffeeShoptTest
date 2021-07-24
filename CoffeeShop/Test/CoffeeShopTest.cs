using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Test
{
    public class CoffeeShopTest : BaseTest
    {
        [Test]
        public void AddProductToCartFromHomepageandFromQoickViewWindow()
        {
            _coffeeShopHomePage.NavigateToDefaultPage()
                 .CloseCookie()
                 .AddToCartBeemVirdulysTeaTime()
                 .AddToCartBeemMokaKavinukas()
                 .CheckQuantity("3");
        }

        [TestCase("5", "3", "3521,96", TestName = "5 virduliai + 2 kavos aparatai = 3 521,96 Eur")]
        [TestCase("1", "1", "1139,99", TestName = "1 virdulys + 1 kavos aparatas = 1139,99 Eur")]
        [TestCase("-1", "1", "1139,99", TestName = "1 virdulys + 1 kavos aparatas = 1139,99 Eur")]
        public void TestTotalPrice(string quantity1, string quantity2, string expectedPrice)
        {
            _coffeeShopCartPage.NavigateToDefaultPage()
                               .InsertVirdulysBeemTeatimeQuantity(quantity1)
                               .InsertNivonaNicr930Quantity(quantity2)
                               .Wait()
                               .CheckTotalPrice(expectedPrice);              
        }

        [Test]
        public void AddInvalidDiscountCode()
        {            
            _coffeeShopCartPage.InsertInvalidDiscountCode("12345")
                               .CheckInvalidDiscountCodeResult("Kuponas neegzistuoja.");            
              
        }

    }


    
}
