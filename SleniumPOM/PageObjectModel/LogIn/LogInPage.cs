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
    internal class LogInPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LogInPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        public void ClickLogInButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.CssSelector("body > app-root > app-login > div > div.main > div")))).Click();
        }


    }
}
