using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleniumPOM.PageObjectModel
{
    internal class StayInSystemPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        public StayInSystemPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        public void SelectCheckbox()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//input[@type='checkbox']")))).Click();
        }
        public void ClickNoButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//input[@type='button']")))).Click();
        }
        public void ClickYesButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//input[@type='submit']")))).Click();
        }


    }
}