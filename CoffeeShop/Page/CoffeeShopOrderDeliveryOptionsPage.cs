using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeShop.Page
{
    public class CoffeeShopOrderDeliveryOptionsPage : BasePage
    {
        private const string PageAddress = "https://coffeeshop.lt/index.php?controller=order";
        private IWebElement _TermsOfServiceField => Driver.FindElement(By.CssSelector("#form > div > p.checkbox > a"));
        private IWebElement _TermsOfServiceCheckBox => Driver.FindElement(By.Id("cgv"));
        private IWebElement _GoToPaymentButton => Driver.FindElement(By.CssSelector("#form > p > button"));
        private IWebElement _ErrorMessageWindow => Driver.FindElement(By.CssSelector("#order > div.fancybox-overlay.fancybox-overlay-fixed > div > div > div > div > p"));
        private IWebElement _CloseErrorMessageWindow => Driver.FindElement(By.CssSelector("#order > div.fancybox-overlay.fancybox-overlay-fixed > div > div > a"));
       

        public CoffeeShopOrderDeliveryOptionsPage(IWebDriver webdriver) : base(webdriver)
        {
            
        }

        public CoffeeShopOrderDeliveryOptionsPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }               
            
        public CoffeeShopOrderDeliveryOptionsPage DeselectCheckBox()
        {
            if (_TermsOfServiceCheckBox.Selected)
                _TermsOfServiceCheckBox.Click();
            return this;
        }

        public CoffeeShopOrderDeliveryOptionsPage SelectCheckBox()
        {
            if (!_TermsOfServiceCheckBox.Selected)
                _TermsOfServiceCheckBox.Click();
            return this;
        }

        public CoffeeShopOrderDeliveryOptionsPage GoToPayment()
        {
            _GoToPaymentButton.Click();
            return this;
        }

        public CoffeeShopOrderDeliveryOptionsPage CheckForErrorMessage(string expectedMessage)
        {
            
            Assert.IsTrue(_ErrorMessageWindow.Text.Contains(expectedMessage), $"Tekstas turėjo būti { expectedMessage}, bet yra { _ErrorMessageWindow.Text}");
            return this;
        }

        public CoffeeShopOrderDeliveryOptionsPage CloseErrorMessage()
        {
            _CloseErrorMessageWindow.Click();
            return this;
        }

        public CoffeeShopOrderDeliveryOptionsPage Wait()
        {
            Thread.Sleep(2000);
            return this;
        }

        public CoffeeShopOrderDeliveryOptionsPage CheckIfThereIsNoErrorMessage()
        {
            Assert.IsFalse(_ErrorMessageWindow.Displayed, $"Pasirodė klaidos pranešimas {_ErrorMessageWindow.Text} ");
            return this;
        }
       

    }
}
