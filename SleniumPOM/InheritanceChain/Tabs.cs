using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace SleniumPOM
{
    internal class Tabs : Paginator
    {
        public Tabs(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }
        private IWebElement tabLastElement => _driver.FindElement(By.XPath("//div[@class = 'mat-tab-links']/a[last()]"));
        public int tabLastElementIndex;
        //Xpath for finding tab for the first time. Used in method to create Dictionary for tabs.
        private string tabIndexElementXpath => "(//div[@class = 'mat-tab-links']/a[contains(@class,'mat-tab-link')])";
        //Xpath for finding tab from the created Dictionary for tabs on any specific page.
        private string tabNameElementXpath => "(//div[@class = 'mat-tab-links']/a[contains(text(),'{0}')])";

        private Dictionary<int, string> tabDictionary = new Dictionary<int, string>();
        private void createTabMap()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(tabLastElement));
            if (IsMapClear(tabDictionary))
            {
                int index = 1;
                for (; !String.Equals(tabLastElement.Text, (_driver.FindElement(By.XPath(tabIndexElementXpath + "[" + index + "]"))).Text); index++)
                {
                    tabDictionary.Add(index, (_driver.FindElement(By.XPath(tabIndexElementXpath + "[" + index + "]"))).Text);
                }
                tabDictionary.Add(index, tabLastElement.Text);
                tabLastElementIndex = index;
            }
        }
        public void ClickOnTab(int indexTab)
        {
            createTabMap();
            if (tabDictionary.ContainsKey(indexTab) == true)
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath(string.Format(tabNameElementXpath, tabDictionary[indexTab]))))).Click();
                CreateSortingOptionsMap();
            }
            else Assert.Fail("There is no tab with such index on the page");
        }
        public void ClickOnTab(string tabName)
        {
            createTabMap();
            if (tabDictionary.ContainsValue(tabName) == true)
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath(string.Format(tabNameElementXpath, tabName))))).Click();
                CreateSortingOptionsMap();
            }
            else Assert.Fail("There is no such tab on the page");
        }
    }
}
