using CoffeeShop.Drivers;
using CoffeeShop.Page;
using CoffeeShop.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static CoffeeShopHomePage _coffeeShopHomePage;
        public static CoffeeShopCartPage _coffeeShopCartPage;



        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _coffeeShopHomePage = new CoffeeShopHomePage(driver);
            _coffeeShopCartPage = new CoffeeShopCartPage(driver);
        }


        [TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            // driver.Quit(); 
        }
    }
}
