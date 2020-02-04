using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Netex24.MainPage
{
    class NetexSecondStep
    {
        private IWebDriver driver;
        public NetexSecondStep(IWebDriver driver)
        {
            this.driver = driver;
        }
        //paiment info
        private By AmountTransfer = By.XPath("//img[contains(@src,'yandex')]/parent::div[@class='ti - amount']");
        private By WalletTransfer = By.XPath("//*[@class='ti-wallet']/span");

        private By AmountReceivable = By.XPath("//img[contains(@src,'btc')]/parent::div[@class='ti - amount']");
        private By WalletReceivable = By.XPath("//img[contains(@src,'btc')]/parent::div[@class='ti - amount']");
        //button
        private By btnSubmit = By.XPath("//*[@type='submit']");

        //info payment 
        public string getAmountTransfer()
        {
            string amoutTransfer = driver.FindElement(AmountTransfer).Text;
            return amoutTransfer;
        }
        public string getWalletTransfer()
        {
            string walletTransfer = driver.FindElement(WalletTransfer).Text;
            return walletTransfer;
        }
        public string getAmountReceivable()
        {
            string amoutAmountReceivable = driver.FindElement(AmountReceivable).Text;
            return amoutAmountReceivable;
        }
        public string getWalletReceivable()
        {
            string walletAmountReceivable = driver.FindElement(WalletReceivable).Text;
            return walletAmountReceivable;
        }
        //button
        public NetexSecondStep clickBtnSubmit()
        {
            IWebElement buttonSubmit = driver.FindElement(btnSubmit);
            buttonSubmit.Click();
            return new NetexSecondStep(driver);

        }
    }
}
