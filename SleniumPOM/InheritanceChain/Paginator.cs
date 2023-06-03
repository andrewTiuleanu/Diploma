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
    internal class Paginator : Navigation
    {
        public Paginator(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        private IWebElement itemsPerPageMenu => _driver.FindElement(By.XPath("//mat-select[@role='listbox' and @aria-label='Items per page:']/div/div/div"));
        private IWebElement nextPageButton => _driver.FindElement(By.XPath("//button[@aria-label='Next page']"));
        private IWebElement previousPageButton => _driver.FindElement(By.XPath("//button[@aria-label='Previous page']"));
        private IWebElement lastPageButton => _driver.FindElement(By.XPath("//button[@aria-label='Last page']"));
        private IWebElement firstPageButton => _driver.FindElement(By.XPath("//button[@aria-label='First page']"));
        private By sortByLastBy => By.XPath("(//button[contains(@aria-label,'Change sorting for')])[last()]");
        private IWebElement sortByLastElement => _driver.FindElement(By.XPath("(//button[contains(@aria-label,'Change sorting for')])[last()]"));
        private string sortElementXpathString => "(//button[contains(@aria-label,'Change sorting for')])";
        private IWebElement itemsPerPagebLastElement => _driver.FindElement(By.XPath("(//mat-option/span[@class = 'mat-option-text'])[last()]"));
        private string itemsPerPageElementXpathString => "(//mat-option/span[@class = 'mat-option-text'])";

        // On every page where Paginator class is appliable icon of Edit is always first, thus [1] and delete second, thus [2]
        string editIcon = "(//div[contains(@class ,'block-icons')]/i[1])";
        string deleteIcon = "(//div[contains(@class ,'block-icons')]/i[2])";
        protected bool HasReachedLastElement(IWebElement LastElement, string currentElementXpath, int index)
        {
            if (!String.Equals(LastElement.Text, _driver.FindElement(By.XPath(itemsPerPageElementXpathString + "[" + index + "]")).Text))
                return true;
            else return false;
        }
        private Dictionary<string, string> itemsPerPageDictionary = new Dictionary<string, string>();
        //This method analyses which is the last items Per Page creates a hash map of all the previuos elements.
        //It's also checking, whether map is created with items per page options, so it does'nt have to create it again.
        private void createItemsPerPageMap()
        {
            int index = 1;
            if (itemsPerPageDictionary.Count == 0)
            {
                for (; HasReachedLastElement(itemsPerPagebLastElement, itemsPerPageElementXpathString, index) == true; index++)
                {
                    string temp = (_driver.FindElement(By.XPath(itemsPerPageElementXpathString + "[" + index + "]")).Text).Replace(" ", String.Empty);
                    itemsPerPageDictionary.Add(temp, (_driver.FindElement(By.XPath(itemsPerPageElementXpathString + "[" + index + "]"))).Text);
                }
                itemsPerPageDictionary.Add(itemsPerPagebLastElement.Text.Replace(" ", String.Empty), itemsPerPagebLastElement.Text);
            }
        }
        public void SelectItemsPerPageAmount(string items)
        {
            ClickItemsPerPageMenu();
            createItemsPerPageMap();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("(//mat-option/span[contains(text(),'" + itemsPerPageDictionary[items] + "')])[1]")))).Click();
            Thread.Sleep(1500);
        }

        public void SelectItemsPerPageAmount(int i)
        {
            SelectItemsPerPageAmount(i.ToString());
        }
        private Dictionary<int, string> sortDictionary = new Dictionary<int, string>();
        protected bool IsMapClear(IDictionary<int, string> map)
        {
            if (map.Count == 0) return true;
            else return false;
        }
        protected void CreateSortingOptionsMap()
        {
            Thread.Sleep(300);
            if (pageURL != GetURL)
            {
                sortDictionary.Clear();
            }
            if (IsMapClear(sortDictionary))
            {
                int i = 1;
                for (; !String.Equals(sortByLastElement.Text, _driver.FindElement(By.XPath(sortElementXpathString + "[" + i + "]")).Text); i++)
                {
                    sortDictionary.Add(i, _driver.FindElement(By.XPath(sortElementXpathString + "[" + i + "]")).Text);
                }
                sortDictionary.Add(i, sortByLastElement.Text);
            }
            pageURL = GetURL;

        }
        public void SortRowsBy(int i)
        {
            CreateSortingOptionsMap();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//button[contains(text(),'" + sortDictionary[i] + "')]")))).Click();
        }
        public void SortRowsBy(string sortingOption)
        {
            CreateSortingOptionsMap();
            if (sortDictionary.ContainsValue(sortingOption))
                _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//button[contains(text(),'" + sortingOption + "')]")))).Click();
        }

        public void ClickNextTasksPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(nextPageButton)).Click();
        }
        public void ClickPreviousTasksPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(previousPageButton)).Click();
        }
        public void ClickLastTasksPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(lastPageButton)).Click();
        }
        public void ClickFirstPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(firstPageButton)).Click();
        }
        public void ClickItemsPerPageMenu()
        {
            Thread.Sleep(1500);
            _wait.Until(ExpectedConditions.ElementToBeClickable(itemsPerPageMenu)).Click();
        }

        IWebElement searchField => _driver.FindElement(By.XPath("//input[@placeholder='Search']"));
        public void Edit(int index)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath(editIcon + "[" + index + "]")))).Click();
        }
        public void Delete()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(deleteIcon + "[1]"))).Click();
        }
        public void Delete(int index)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(deleteIcon + "[" + index + "]"))).Click();
        }

        //Garbage
        //private Dictionary<int, string> itemsPerPageTypes = new Dictionary<int, string>()
        //{
        //{ 10, "10"},
        //{ 20, "20"},
        //{ 50, "50"},
        //{ 100, "100"}
        //};
        //public void SelectItemsPerPageAmount(int i)
        //{
        //    ClickItemsPerPageMenu();
        //    switch (i)
        //    {
        //        case 10:
        //        case 20:
        //        case 50:
        //        case 100:
        //            {
        //                _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//mat-option/span[@class = 'mat-option-text' and text()=' " + itemsPerPageTypes[i] + " ']")))).Click();
        //                break;
        //            }
        //        default:
        //            {
        //                Assert.Fail("No such amount of items");
        //                break;
        //            }
        //    }
        //}
        /*IsMapClearLegacy
         if (pageURL != GetURL && (map.Count != 0))
            {
                map.Clear();
                pageURL = GetURL;
                return true;
            }
            else if (pageURL is null && (map.Count != 0))
            {
                return false;
            }
            else if (pageURL is null)
            {
                pageURL = GetURL;
                map.Clear();
                return true;
            }
            else if (pageURL is not null && (map.Count == 0))
            {
                return true;
            }
        `   */
    }
}

