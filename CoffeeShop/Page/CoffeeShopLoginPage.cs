using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Page
{
    public class CoffeeShopLoginPage : BasePage
    {
        private const string PageAddress = "https://coffeeshop.lt/index.php?controller=authentication&back=my-account";
        private IWebElement _EmailInputField => Driver.FindElement(By.Id("email"));
        private IWebElement _PasswordInputField => Driver.FindElement(By.Id("passwd"));
        private IWebElement _LoginButton => Driver.FindElement(By.Id("SubmitLogin"));
        private IWebElement _AlertMessageBox => Driver.FindElement(By.CssSelector("#center_column > div.alert.alert-danger"));
        private IWebElement _CustomerNameField => Driver.FindElement(By.CssSelector("#header > div > div > div > div.userbar.col-xs-12 > div > a.account"));

        public CoffeeShopLoginPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public CoffeeShopLoginPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public CoffeeShopLoginPage InsertEmail(string email)
        {
            _EmailInputField.Clear();
            _EmailInputField.Click();
            _EmailInputField.SendKeys(email);
            return this;
        }

        public CoffeeShopLoginPage InsertPassword(string password)
        {
            _PasswordInputField.Clear();
            _PasswordInputField.Click();
            _PasswordInputField.SendKeys(password);
            return this;
        }

        public CoffeeShopLoginPage SubmitLogin()
        {
            _LoginButton.Click();
            return this;
        }

        public CoffeeShopLoginPage CheckLoginWithInvalidCredentialsResult(string expectedMessage)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => _AlertMessageBox.Displayed);
            string result = _AlertMessageBox.Text;
            Assert.True(result.Contains(expectedMessage), $"Pranešimas {expectedMessage} nepasirodė. {result}");
            return this;
        }

        public CoffeeShopLoginPage CheckLoginWithValidCredentialsResult(string customerName)
        {
            
            Assert.True(_CustomerNameField.Text.Contains(customerName), $"Pranešimas {customerName} nepasirodė. {_CustomerNameField.Text}");
            return this;

        }
    }
}
