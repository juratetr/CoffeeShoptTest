

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace CoffeeShop.Page
{
    public class CoffeeShopHomePage : BasePage
    {
        private const string PageAddress = "https://coffeeshop.lt";
        private IWebElement _QookieX => Driver.FindElement(By.CssSelector("#cookieNoticeContent > table > tbody > tr:nth-child(2) > td > span"));
        private IWebElement _ThumbnailBeemVirdulysTeaTime => Driver.FindElement(By.CssSelector("#blocknewproducts > li.ajax_block_product.col-xs-12.col-sm-4.col-md-3.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line"));
        private IWebElement _AddToChartBeemVirdulysTeaTimeButton => Driver.FindElement(By.CssSelector("#blocknewproducts > li.ajax_block_product.col-xs-12.col-sm-4.col-md-3.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line > div > div.right-block > div.button-container > a.button.ajax_add_to_cart_button.btn.btn-default > span"));
        private IWebElement _ContinueShoppingFromBeemVirdulysTeaTime => Driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > span"));
        private IWebElement _SpecialOffersBlock => Driver.FindElement(By.ClassName("blockspecials"));
        private IWebElement _ThumbnailNivonaNicr930 => Driver.FindElement(By.CssSelector("#blockspecials > li:nth-child(1) > div"));
        private IWebElement _QuickViewNivonaNicr930 => Driver.FindElement(By.CssSelector("#blockspecials > li:nth-child(1) > div > div.left-block > div > a.quick-view > span"));
        private IWebElement _QuantityWantedNivonaNicr930Input => Driver.FindElement(By.Id("quantity_wanted"));
        private IWebElement _PlusOneNivonNicr930Button => Driver.FindElement(By.CssSelector("#quantity_wanted_p > a.btn.btn-default.button-plus.product_quantity_up"));
        private IWebElement _AddToChartNivonaNicr930Button => Driver.FindElement(By.CssSelector("#blockspecials > li.ajax_block_product.col-xs-12.col-sm-4.col-md-3.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line.hovered > div > div.right-block > div.button-container > a.button.ajax_add_to_cart_button.btn.btn-default > span"));
        private IWebElement _ContinueShoppingtNivonaNicr930Button => Driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > span"));
        private IWebElement _ChartQuantity => Driver.FindElement(By.CssSelector("#header > div > div > div > div.col-sm-4.clearfix > div > div.block_content > a > span.ajax_cart_quantity"));
        private IWebElement _AddTochartNivonaNicr930FromQoickViewButton => Driver.FindElement(By.CssSelector("#add_to_cart > button"));

        public CoffeeShopHomePage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public CoffeeShopHomePage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public CoffeeShopHomePage CloseCookie()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => _QookieX.Displayed);
            _QookieX.Click();
            return this;
        }

        public CoffeeShopHomePage AddToChartBeemVirdulysTeaTime()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(_ThumbnailBeemVirdulysTeaTime);
            action.Build().Perform();
            _AddToChartBeemVirdulysTeaTimeButton.Click();
            _ContinueShoppingFromBeemVirdulysTeaTime.Click();
            return this;
        }
        public CoffeeShopHomePage AddToChartBeemMokaKavinukas()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(_SpecialOffersBlock);
            action.Build().Perform();
            _SpecialOffersBlock.Click();
            action.MoveToElement(_ThumbnailNivonaNicr930);
            action.Build().Perform();
            _QuickViewNivonaNicr930.Click();
            
            _PlusOneNivonNicr930Button.Click();
           // _QuantityWantedNivonaNicr930Input.Clear();
           // _QuantityWantedNivonaNicr930Input.SendKeys("2");
            _AddTochartNivonaNicr930FromQoickViewButton.Click();
            //_AddToChartNivonaNicr930Button.Click();
            _ContinueShoppingtNivonaNicr930Button.Click();
            return this;
        }
        public CoffeeShopHomePage CheckQuantity(string expectedQuantity)
        {
            Assert.IsTrue(_ChartQuantity.Text.Equals(expectedQuantity), $"Kiekis turėjo būti { expectedQuantity}, bet yra { _ChartQuantity}");
            return this;
        }


    }
}
