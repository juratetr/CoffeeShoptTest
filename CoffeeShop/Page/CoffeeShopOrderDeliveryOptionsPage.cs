using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Page
{
    public class CoffeeShopOrderDeliveryOptionsPage : BasePage
    {
        private const string PageAddress = "https://coffeeshop.lt/index.php?controller=order";
        private IWebElement _TermsOfServiceField => Driver.FindElement(By.CssSelector("#form > div > p.checkbox > a"));
        private IWebElement _TermsOfServiceCheckBox => Driver.FindElement(By.Id("cgv"));
        private IWebElement _TermsOfServicesWindow => Driver.FindElement(By.CssSelector("#order > div.fancybox-overlay.fancybox-overlay-fixed > div"));
        private IWebElement _CloseTermsOfServiceButton => Driver.FindElement(By.CssSelector("#order > div.fancybox-overlay.fancybox-overlay-fixed > div > div > a"));
        private IWebElement _GoToPaymentButton => Driver.FindElement(By.CssSelector("#form > p > button"));
        private IWebElement _ErrorMessageWindow => Driver.FindElement(By.CssSelector("#order > div.fancybox-overlay.fancybox-overlay-fixed > div > div > div > div > p"));
        private IWebElement _CloseErrorMessageWindow => Driver.FindElement(By.CssSelector("#order > div.fancybox-overlay.fancybox-overlay-fixed > div > div > a"));
        private IWebElement _CarrierArea => Driver.FindElement(By.Id("#form"));
        public CoffeeShopOrderDeliveryOptionsPage(IWebDriver webdriver) : base(webdriver)
        {
            
        }

        public CoffeeShopOrderDeliveryOptionsPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        
        public CoffeeShopOrderDeliveryOptionsPage OpenTermsAndConditionsWindow()
        {
            Driver.SwitchTo().Frame(_CarrierArea);
            Actions action = new Actions(Driver);
            action.MoveToElement(_TermsOfServiceField);
            action.Build().Perform();
            _TermsOfServiceField.Click();
            return this;
        }
        public CoffeeShopOrderDeliveryOptionsPage CheckIfOpenedTermsAndConditionsWindow(string expectedText)
        {
            Driver.SwitchTo().Frame("fancybox-frame1627159206321");
            Assert.IsTrue(_TermsOfServicesWindow.Text.Contains(expectedText), $"Tekstas turėjo būti { expectedText}, bet yra { _TermsOfServicesWindow}");
            return this;
        }

        public CoffeeShopOrderDeliveryOptionsPage CloseTermsAndConditionsWindow()
        {
            _CloseTermsOfServiceButton.Click();
            return this;
        }

        public CoffeeShopOrderDeliveryOptionsPage DeselectCheckBox()
        {
            if (_TermsOfServiceCheckBox.Selected)
                _TermsOfServiceCheckBox.Click();
            return this;
        }

        public CoffeeShopOrderDeliveryOptionsPage GoToPayment()
        {
            _GoToPaymentButton.Click();
            return this;
        }

        public CoffeeShopOrderDeliveryOptionsPage CheckIfOpenedErrorMessage(string expectedMessage)
        {
            
            Assert.IsTrue(_ErrorMessageWindow.Text.Contains(expectedMessage), $"Tekstas turėjo būti { expectedMessage}, bet yra { _ErrorMessageWindow}");
            return this;
        }

        public CoffeeShopOrderDeliveryOptionsPage CloseErrorMessage()
        {
            _CloseErrorMessageWindow.Click();
            return this;
        }

    }
}
