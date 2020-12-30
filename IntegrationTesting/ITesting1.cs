using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace IntegrationTesting
{
    [TestFixture]
    public class ITesting1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheITesting1Test()
        {
            driver.Navigate().GoToUrl("https://elp.duetbd.org/");
            driver.FindElement(By.Id("login_password")).Clear();
            driver.FindElement(By.Id("login_password")).SendKeys("Fuckyou69!");
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.CssSelector("#username")).Click();
            driver.FindElement(By.Id("username")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=username | ]]
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("yui_3_17_2_1_1609320384933_22")).Click();
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=password | ]]
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("loginbtn")).Click();
            driver.FindElement(By.Id("action-menu-toggle-1")).Click();
            driver.FindElement(By.Id("actionmenuaction-6")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
