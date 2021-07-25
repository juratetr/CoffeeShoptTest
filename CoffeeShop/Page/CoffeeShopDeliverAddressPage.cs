using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Page
{
   public class CoffeeShopDeliveryAddressPage : BasePage
    {
        private const string PageAddress = "https://coffeeshop.lt/index.php?controller=order&step=1";      

        private IWebElement _AddressName => Driver.FindElement(By.CssSelector("#address_delivery > li.address_firstname.lastname"));
        private IWebElement _AddressStreet => Driver.FindElement(By.CssSelector("#address_delivery > li.address_address1"));
        private IWebElement _AddressPostCodeCity => Driver.FindElement(By.CssSelector("#address_delivery > li.address_postcode.city"));
        private IWebElement _AddressCountry => Driver.FindElement(By.XPath("//*[@id='address_delivery']/li[5]"));
        private IWebElement _AddressPhone => Driver.FindElement(By.XPath("//*[@id='address_delivery']/li[6]"));

        public CoffeeShopDeliveryAddressPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public CoffeeShopDeliveryAddressPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public CoffeeShopDeliveryAddressPage CheckName(string expectedName)
        
        {
            Assert.IsTrue(_AddressName.Text.Contains(expectedName), $"Tekstas turėjo būti { expectedName}, bet yra { _AddressName.Text}");                                 
            return this;
        }
        public CoffeeShopDeliveryAddressPage CheckStreet(string expectedStreet)
        {
            Assert.IsTrue(_AddressStreet.Text.Contains(expectedStreet), $"Tekstas turėjo būti { expectedStreet}, bet yra { _AddressStreet.Text}");
            return this;
        }
        public CoffeeShopDeliveryAddressPage CheckPostCode(string postCodeCity)
        {
            Assert.IsTrue(_AddressPostCodeCity.Text.Contains(postCodeCity), $"Tekstas turėjo būti { postCodeCity}, bet yra { _AddressPostCodeCity.Text}");
            return this;
        }
        public CoffeeShopDeliveryAddressPage CheckCountry(string expectedCountry)
        {
            Assert.IsTrue(_AddressCountry.Text.Contains(expectedCountry), $"Tekstas turėjo būti { expectedCountry}, bet yra { _AddressCountry.Text}");
            return this;
        }
        public CoffeeShopDeliveryAddressPage CheckPhone(string expectedPhone)
        {
            Assert.IsTrue(_AddressPhone.Text.Contains(expectedPhone), $"Tekstas turėjo būti { expectedPhone}, bet yra { _AddressPhone.Text}");
            return this;
        }

    }
}
