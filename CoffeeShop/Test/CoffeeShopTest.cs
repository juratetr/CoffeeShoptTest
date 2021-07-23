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
        public void AddToChartFromHomepage()
        {
            _coffeeShopHomePage.NavigateToDefaultPage()
                 .CloseCookie()
                 .AddToChartBeemVirdulysTeaTime()
                 .AddToChartBeemMokaKavinukas()
                 .CheckQuantity("2");
        }
    }
}
