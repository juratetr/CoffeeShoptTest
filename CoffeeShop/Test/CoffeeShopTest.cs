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
        [Order(0)]
        [Test]
        public void AddProductToCartFromHomepageandFromQuickViewWindow()
        {
            _coffeeShopHomePage.NavigateToDefaultPage()
                               .CloseCookie()
                               .AddToCartKavamaleNivonaCafeGranoNICG130()
                               .AddToCartNivonaNicr930()
                               .CheckQuantity("3");
        }

        [Order(1)]
        [TestCase("5", "3", "3692,00", TestName = "5 kavamalės + 2 kavos aparatai = 3692,00 Eur")]
        [TestCase("1", "1", "1174,00", TestName = "1 kavamalė + 1 kavos aparatas = 1174,00 Eur")]
        [TestCase("-1", "1", "1174,00", TestName = "1 kavamalė + 1 kavos aparatas = 1174,00 Eur")]
        public void TotalPriceTest(string quantity1, string quantity2, string expectedPrice)
        {
            _coffeeShopCartPage.NavigateToDefaultPage()
                               .InsertKavamaleNivonaCafeGranoNICG130Quantity(quantity1)
                               .InsertNivonaNicr930Quantity(quantity2)
                               .Wait()
                               .CheckTotalPrice(expectedPrice);              
        }
                 
        [Order(2)]
        [Test]
         public void AddInvalidDiscountCode()
         {            
             _coffeeShopCartPage.InsertInvalidDiscountCode("12345")
                                .Wait()
                                .CheckInvalidDiscountCodeResult("Kuponas neegzistuoja.");       

         }

        [Order(3)]
        [TestCase("aaaa@bbbb", "xSPrFkuu", "Klaidingas el. pašto adresas.", TestName = "Prisijungimas su blogu el.p.")]
        [TestCase("", "xSPrFkuu", "Reikalingas el. pašto adresas.", TestName = "Prisijungimas paliekant tuščią el.p. lauką")]
        [TestCase("jurategil@gmail.com", "abcd", "Neteisingas slaptažodis.", TestName = "Prisijungimas su blogu slaptažodžiu.")]
        [TestCase("jurategil@gmail.com", "", "Būtinas slaptažodis.", TestName = "Prisijungimas paliekant tuščią slaptažodžio lauką")]
        [TestCase("", "", "Reikalingas el. pašto adresas.", TestName = "Prisijungimas paliekant tuščius el.p. ir slaptažodžio laukus")]
        
        public void LoginWithInvalidCredentials(string email, string password, string expectedMessage)
        {
            _coffeeShopLoginPage.NavigateToDefaultPage()
                                .InsertEmail(email)
                                .InsertPassword(password)
                                .SubmitLogin()
                                .CheckLoginWithInvalidCredentialsResult(expectedMessage);
        }

        [Order(4)]
        [Test]
        public void LoginWithValidCredentials()
        {
            _coffeeShopLoginPage.NavigateToDefaultPage()
                .InsertEmail("jurategil@gmail.com")
                .InsertPassword("xSPrFkuu")
                .SubmitLogin()
                .CheckLoginWithValidCredentialsResult("Jūratė Trinkūnienė");

        }

        [Order(5)]
        [Test]
        public void CheckAddress()
        {
            _coffeeShopDeliveryAddressPage.NavigateToDefaultPage()
                .CheckName("Jūratė Trinkūnienė")
                .CheckStreet("Saulės g. 99")
                .CheckPostCode("12345 Vilnius")
                .CheckCountry("Lithuania")
                .CheckPhone("865562942")
                .GoToPayment();
        }         
             
        [Order(6)]
        [Test]
        public void PurchaseWithoutTheAgreementOfTermsAndConditions()
        {
            _coffeeShopOrderDeliveryOptionsPage.NavigateToDefaultPage()
                .DeselectCheckBox()
                .GoToPayment()
                .CheckForErrorMessage("Prieš tęsdami turite sutikti su paslaugų teikimo sąlygomis")
                .CloseErrorMessage();
        }

        [Order(7)]
        public void PurchaseWithTheAgreementOfTermsAndConditions()
        {
            _coffeeShopOrderDeliveryOptionsPage.NavigateToDefaultPage()
                .SelectCheckBox()
                .GoToPayment()
                .CheckIfThereIsNoErrorMessage();
        }
        
       

        
    }


    
}
