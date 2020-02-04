using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace Netex24
{
    public class NetexTest
    {

        [TestFixture]
        public class TestsTests
        {

            public static IWebDriver driver;

            MainPage.NetexFirstStep netexFirstStep;
            MainPage.NetexSecondStep netexSecondStep;


            [SetUp]
            public void SetUp()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);


                driver.Navigate().GoToUrl("https://www.netex24.net/#/en/");
                netexFirstStep = new MainPage.NetexFirstStep(driver);
                netexSecondStep = new MainPage.NetexSecondStep(driver);

            }
            [Test]
            public void QiwiToBitcoinMinTarnsfer()
            {
                netexFirstStep.OpenTranferFormQiwiToBitcoin();
                Thread.Sleep(500);
                string amountMin = netexFirstStep.getMinAmountTransfer();
                netexFirstStep.sendDataInFieldAmountTransfer(amountMin);
                netexFirstStep.sendDataInFiedWallet("+79031234567");
                netexFirstStep.sendDataInFiedBitcoinAddress("1F6Mgo2hFfAdqvGCQbqsRtc9cQszDq8xo");
                netexFirstStep.sendDataInFiedPhone("+79602435301");
                netexFirstStep.sendDataInFiedEmail("ivanov@mail.ru");
                string valueAmountReceivable = netexFirstStep.getDataInFiedAmountReceivable();
                string valueMinAmountReceivable = netexFirstStep.getMinAmountReceivable();
                driver.SwitchTo().Frame(0);
                netexFirstStep.selectCheckBoxCaptcha();
                Assert.IsTrue(valueAmountReceivable.Contains(valueAmountReceivable), valueMinAmountReceivable);
            }

            [Test]
            public void QiwiToBitcoinMaxTarnsfer()
            {
                netexFirstStep.OpenTranferFormQiwiToBitcoin();
                Thread.Sleep(500);
                string amountMax = netexFirstStep.getMaxAmountTransfer();
                netexFirstStep.sendDataInFieldAmountTransfer(amountMax);
                netexFirstStep.sendDataInFiedWallet("+79031234567");
                netexFirstStep.sendDataInFiedBitcoinAddress("1F6Mgo2hFfAdqvGCQbqsRtc9cQszDq8xo");
                netexFirstStep.sendDataInFiedPhone("+79602435301");
                netexFirstStep.sendDataInFiedEmail("ivanov@mail.ru");
                string valueAmountReceivable = netexFirstStep.getDataInFiedAmountReceivable();
                string valueMaxAmountReceivable = netexFirstStep.getMaxAmountReceivable();
                driver.SwitchTo().Frame(0);
                netexFirstStep.selectCheckBoxCaptcha();
                Assert.IsTrue(valueAmountReceivable.Contains(valueAmountReceivable), valueMaxAmountReceivable);
            }
            [Test]
            public void YandexToBitcoinMinTarnsfer()
            {
                //Fisrt step
                Thread.Sleep(500);
                netexFirstStep.OpenTranferFormYandexToBitcoin();
                netexFirstStep.sendDataInFiedWallet("41001114945713");
                driver.Navigate().Refresh();
                /*баг кошелька невалидный кошелек становится валидным*/
                netexFirstStep.OpenTranferFormYandexToBitcoin();
                Thread.Sleep(1500);
                string amountMin = netexFirstStep.getMinAmountTransfer();
                netexFirstStep.sendDataInFieldAmountTransfer(amountMin);

                netexFirstStep.sendDataInFiedBitcoinAddress("1F6Mgo2hFfAdqvGCQbqsRtc9cQszDq8xo");
                netexFirstStep.sendDataInFiedPhone("+79602435301");
                netexFirstStep.sendDataInFiedEmail("ivanov@mail.ru");
                string amountTarnsferFirstStep = netexFirstStep.getDataInFieldAmountTransfer();
                string wallueTaransferFirstStep = netexFirstStep.getDataInFieldWallet();
                string ammountReceivableFirstStep = netexFirstStep.getDataInFiedAmountReceivable();
                string walletReceivableFirstStep = netexFirstStep.getDataInFieldBitcoinAddress();
                netexFirstStep.clickBtnSubmit();
                //Second step
                string amountTransfer = netexSecondStep.getAmountTransfer();
                Assert.AreEqual(amountTransfer, amountTarnsferFirstStep);
                string walletTarnsfer = netexSecondStep.getWalletTransfer();
                Assert.AreEqual(walletTarnsfer, wallueTaransferFirstStep);
                string amountReceivable = netexSecondStep.getAmountReceivable();
                Assert.AreEqual(amountReceivable, ammountReceivableFirstStep);
                string walletReceivable = netexSecondStep.getWalletReceivable();
                Assert.AreEqual(walletReceivable, walletReceivableFirstStep);
                netexSecondStep.clickBtnSubmit();
                string url = driver.Url;
                Assert.AreEqual("https://money.yandex.ru/quickpay/confirm.xml", url);
            }

            [Test]
            public void YandexToBitcoinMaxTarnsfer()
            {
                //Fisrt step
                Thread.Sleep(500);
                netexFirstStep.OpenTranferFormYandexToBitcoin();
                netexFirstStep.sendDataInFiedWallet("41001114945713");
                driver.Navigate().Refresh();
                /*баг кошелька невалидный кошелек становится валидным*/
                netexFirstStep.OpenTranferFormYandexToBitcoin();
                Thread.Sleep(  1500);
                string amountMax = netexFirstStep.getMaxAmountTransfer();
                netexFirstStep.sendDataInFieldAmountTransfer(amountMax);
                
                netexFirstStep.sendDataInFiedBitcoinAddress("1F6Mgo2hFfAdqvGCQbqsRtc9cQszDq8xo");
                netexFirstStep.sendDataInFiedPhone("+79602435301");
                netexFirstStep.sendDataInFiedEmail("ivanov@mail.ru");
                string amountTarnsferFirstStep = netexFirstStep.getDataInFieldAmountTransfer();
                string wallueTaransferFirstStep = netexFirstStep.getDataInFieldWallet();
                string ammountReceivableFirstStep = netexFirstStep.getDataInFiedAmountReceivable();
                string walletReceivableFirstStep = netexFirstStep.getDataInFieldBitcoinAddress();
                netexFirstStep.clickBtnSubmit();
                //Second step
                string amountTransfer = netexSecondStep.getAmountTransfer();
                Assert.AreEqual(amountTransfer,amountTarnsferFirstStep);
                string walletTarnsfer = netexSecondStep.getWalletTransfer();
                Assert.AreEqual(walletTarnsfer,wallueTaransferFirstStep);
                string amountReceivable = netexSecondStep.getAmountReceivable();
                Assert.AreEqual(amountReceivable,ammountReceivableFirstStep);
                string walletReceivable = netexSecondStep.getWalletReceivable();
                Assert.AreEqual(walletReceivable,walletReceivableFirstStep);
                netexSecondStep.clickBtnSubmit();
                string url = driver.Url;
                Assert.AreEqual("https://money.yandex.ru/quickpay/confirm.xml", url);
            }
            [TearDown]
            public void TearDown()
            {
                driver.Quit();
            }
        }
    }
}   