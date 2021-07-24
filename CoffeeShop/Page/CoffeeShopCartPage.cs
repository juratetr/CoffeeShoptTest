using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeShop.Page
{
    public class CoffeeShopCartPage : BasePage
    {
        private const string PageAddress = "https://coffeeshop.lt/index.php?controller=order";
        private IWebElement _VirdulysBeemTeatimeQuantityInputField => Driver.FindElement(By.CssSelector("#product_543_0_0_0 > td.cart_quantity.text-center > input.cart_quantity_input.form-control.grey"));
        private IWebElement _NivonaNicr930quantityInputField => Driver.FindElement(By.CssSelector("#product_507_0_0_0 > td.cart_quantity.text-center > input.cart_quantity_input.form-control.grey"));
        private IWebElement _TotalPriceContainer => Driver.FindElement(By.Id("total_price"));
        private IWebElement _DiscountCodeInputField => Driver.FindElement(By.Id("discount_name"));
        private IWebElement _SubmitDiscountCodeButton => Driver.FindElement(By.CssSelector("#discount_name"));
        private IWebElement _AlertMessageBox => Driver.FindElement(By.CssSelector("#center_column > div.alert.alert-danger"));

        public CoffeeShopCartPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public CoffeeShopCartPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public CoffeeShopCartPage InsertVirdulysBeemTeatimeQuantity(string guantity)
        {
            _VirdulysBeemTeatimeQuantityInputField.Clear();
            _VirdulysBeemTeatimeQuantityInputField.SendKeys(guantity);
            return this;
        }
        public CoffeeShopCartPage InsertNivonaNicr930Quantity(string guantity)
        {
            _NivonaNicr930quantityInputField.Clear();
            _NivonaNicr930quantityInputField.SendKeys(guantity);
            return this;
        }
        public CoffeeShopCartPage CheckTotalPrice(string expectedPrice)
        {
            string preparedSum = _TotalPriceContainer.Text.Replace(" ", "").TrimEnd('€');
            Assert.IsTrue(preparedSum.Contains(expectedPrice), $"Visa krepšelio kaina turėjo būti { expectedPrice + " Eur"} , bet yra { preparedSum + " Eur"}");
            return this;
        }
        public CoffeeShopCartPage Wait()
        {
            Thread.Sleep(2000);
            return this;           
        }

        public CoffeeShopCartPage InsertInvalidDiscountCode(string code)
        {          
            _DiscountCodeInputField.Click();
            _DiscountCodeInputField.SendKeys(code);
            _SubmitDiscountCodeButton.Click();
            return this;
        }

        public CoffeeShopCartPage CheckInvalidDiscountCodeResult(string expectedMessage)
        {
            string result = _AlertMessageBox.Text;
            Assert.True(result.Contains(expectedMessage), $"Pranešimas {expectedMessage} nepasirodė. {result}");
            return this;
        }
    }
}
