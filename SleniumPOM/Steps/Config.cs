using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SeleniumFramework.Steps
{
    [Binding]
    public sealed class Config
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
    }
}