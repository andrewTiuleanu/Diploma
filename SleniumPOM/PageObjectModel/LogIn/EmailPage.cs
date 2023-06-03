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
    internal class EmailPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public EmailPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        public void FillEmailField()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//input[@type='email']")))).SendKeys("example.user");
            //

        }
        public void ClickNextButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//input[@type= 'submit']")))).Click();
        }
        public void AssertError()
        {
            string actualResult = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("usernameError"))).Text;
            Assert.AreEqual("Введите допустимый адрес электронной почты, номер телефона или логин Skype.", actualResult);
        }
    }
}