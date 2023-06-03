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
    internal class PasswordPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public PasswordPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;

        }
        public void FillPasswordField()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='password']"))).SendKeys("example.user.Pass");

            //IWebElement input => driver.findElement(By.xpath("//input[contains[@placeholder,’pass’]"));
            //IWebElement input => driver.findElement(By.xpath("//input[starts-with [@placeholder,’pass’]"));

        }
        public void ClickNextButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//input[@type='submit']")))).Click();
        }
        public void AssertError()
        {
            string actualResult = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("passwordError"))).Text;
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile("C://Image.png",
            ScreenshotImageFormat.Png);
            Assert.AreEqual("Неправильная учетная запись или пароль. Если вы не помните свой пароль, сбросьте его.", actualResult);
        }
    }


}