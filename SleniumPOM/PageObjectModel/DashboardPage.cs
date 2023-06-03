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
    internal class DashboardPage : Navigation
    {
        public DashboardPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }
        public void AssertUrl()
        {
            if (_wait.Until(ExpectedConditions.UrlContains("overview")))
            {
                Assert.AreEqual("example.com", _driver.Url);
            }
            else Assert.Pass("Could not process overview Page");
        }

    }
}