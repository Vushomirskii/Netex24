using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Netex24.MainPage
{
    class NetexFirstStep
    {
        private IWebDriver driver;

        public NetexFirstStep(IWebDriver driver)
        {
            this.driver = driver;
        }


        //You give
        private By giveOutQiwi = By.XPath("//*[contains(@class,'source-direction')]//*[text()='Qiwi']");
        private By giveOutYandexMoney = By.XPath("//*[contains(@class,'source-direction')]//*[text()='Yandex.Money']");
        //You get
        private By getOnBitcoin = By.XPath("//*[contains(@class,'direction target-direction')]//*[text()='Bitcoin']");
        //Form
            //First step
        private By fieldAmountTransfer = By.XPath("//*[@translate-key='amount']/parent ::div/following-sibling::div//input");
        //Min / Max amount tranfer
        private By MinAmountTransfer = By.XPath("//*[@translate-key='minimum']/ancestor ::span/following-sibling::span");
        private By MaxAmountTransfer = By.XPath("//*[@translate-key='maximum']/ancestor ::span/following-sibling::span");

        private By fieldWallet = By.XPath("//*[@translate-key='account']/parent ::div/following-sibling::div//input");
        private By fieldAmountReceivable = By.XPath("//*[@translate-key='reserve']/ancestor::div[@class='vCalculatorLine']/div[@class='v-cl-field']//input");
        //Min /Max receivable
        private By MinAmountReceivable = By.XPath("//*[@translate-key='reserve']/ancestor::div[@class='v-cl-ext']//span[@translate-key='minimum']/ancestor::div[@class='vLabel']//span[@class='v-label-text']");
        private By MaxAmountReceivable = By.XPath("//*[@translate-key='reserve']/ancestor::div[@class='v-cl-ext']//span[@translate-key='maximum']/ancestor::div[@class='vLabel']//span[@class='v-label-text']");

        private By fieldBitcoinAddress = By.XPath("//*[@class='vBtc']//input");
        private By fieldPhoneNamber = By.XPath("//*[@translate-key='phoneNumber']/parent ::div/following-sibling::div//input");
        private By fieldEmail = By.XPath("//*[@type='email']");
        private By checkBoxCaptcha = By.XPath("//*[contains(@class,'recaptcha-checkbox')]");
        private By btnSubmit = By.XPath("//*[@type='submit']");

        




        //Open form
        public NetexFirstStep OpenTranferFormQiwiToBitcoin()
        {
            driver.FindElement(giveOutQiwi).Click();
            driver.FindElement(getOnBitcoin).Click();
            return new NetexFirstStep(driver);
        }
        public NetexFirstStep OpenTranferFormYandexToBitcoin()
        {
            driver.FindElement(giveOutYandexMoney).Click();
            driver.FindElement(getOnBitcoin).Click();
            return new NetexFirstStep(driver);
        }
        //Amount tranfer 
        public NetexFirstStep sendDataInFieldAmountTransfer(string amount)
        {
            IWebElement fieldAmount = driver.FindElement(fieldAmountTransfer);
            fieldAmount.SendKeys(amount);
            return this;
        }
        public string getDataInFieldAmountTransfer()
        {
            string amoutnTtansfer = driver.FindElement(fieldAmountTransfer).GetAttribute("value");
            return amoutnTtansfer;
        }
        public string getMinAmountTransfer()
        {
            string minAmount = driver.FindElement(MinAmountTransfer).Text;
            return minAmount;
        }
        public string getMaxAmountTransfer()
        {
            string maxAmount = driver.FindElement(MaxAmountTransfer).Text;
            return maxAmount;
        }
        //Wallet tranfer 
        public NetexFirstStep sendDataInFiedWallet(string wallet)
        {
            IWebElement FieldWallet = driver.FindElement(fieldWallet);
            FieldWallet.SendKeys(wallet);
            return this;
        }
        public string getDataInFieldWallet()
        {
            string wallet = driver.FindElement(fieldWallet).GetAttribute("value");
            return wallet;
        }
        //Amount Receivable
        public NetexFirstStep sendDataInFiedAmountReceivable(string value)
        {
            IWebElement FieldAmountReceivable = driver.FindElement(fieldAmountReceivable);
            FieldAmountReceivable.SendKeys(value);
            return this;
        }
        public string getDataInFiedAmountReceivable()
        {
            string amountReceivable = driver.FindElement(fieldAmountReceivable).GetAttribute("value");
            return amountReceivable;
        }
        public string getMinAmountReceivable()
        {
            string minAmount = driver.FindElement(MinAmountReceivable).Text;
            return minAmount;
        }
        public string getMaxAmountReceivable()
        {
            string maxAmount = driver.FindElement(MaxAmountReceivable).Text;
            return maxAmount;
        }

        //Bitcoin address
        public NetexFirstStep sendDataInFiedBitcoinAddress(string value)
        {
            IWebElement FieldBitcoinAddress = driver.FindElement(fieldBitcoinAddress);
            FieldBitcoinAddress.SendKeys(value);
            return this;
        }
        public string getDataInFieldBitcoinAddress()
        {
            string wallueReceivable = driver.FindElement(fieldBitcoinAddress).GetAttribute("value");
            return wallueReceivable;
        }
        //Phone
        public NetexFirstStep sendDataInFiedPhone(string value)
        {
            IWebElement FieldPhone = driver.FindElement(fieldPhoneNamber);
            FieldPhone.SendKeys(value);
            return this;
        }
        //Email
        public NetexFirstStep sendDataInFiedEmail(string value)
        {
            IWebElement FieldEmail = driver.FindElement(fieldEmail);
            FieldEmail.SendKeys(value);
            return this;
        }
        //Captca
        public NetexFirstStep selectCheckBoxCaptcha()
        {
            IWebElement checkbox = driver.FindElement(checkBoxCaptcha);
            checkbox.Click();
            return this;
        }
        //button
        public NetexFirstStep clickBtnSubmit()
        {
            IWebElement buttonSubmit = driver.FindElement(btnSubmit);
            buttonSubmit.Click();
            return new NetexFirstStep(driver);
           
        }
    }
}
