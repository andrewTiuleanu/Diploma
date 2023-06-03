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

namespace SleniumPOM.PageObjectModel
{
    internal class SettingsPage : Tabs
    {
        public SettingsPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }
        private IWebElement addButton => _driver.FindElement(By.XPath("//span[@class='icon-btn-label' and contains(text(),'Add')]"));
        public void AddSkill()
        {
            Assert.That(GetURL, Is.EqualTo("example.com/settings/skills"));
            addButton.Click();
        }
        public void AddProjectType()
        {
            Assert.That(GetURL, Is.EqualTo("example.com/setting/project-types"));
            addButton.Click();
        }

        public void AddJobRole()
        {
            Assert.That(GetURL, Is.EqualTo("example.com/settings/job-roles"));
            addButton.Click();
        }
        public void AddRole()
        {
            Assert.That(GetURL, Is.EqualTo("example.com/settings/assignment-roles"));
            addButton.Click();
        }
        public void AddCommunicationType()
        {
            Assert.That(GetURL, Is.EqualTo("example.com/settings/communication-types"));
            addButton.Click();
        }
        public void AddFAQ()
        {
            Assert.That(GetURL, Is.EqualTo("example.com/settings/faq"));
            addButton.Click();
        }

        public void AddPipeline()
        {
            Assert.That(GetURL, Is.EqualTo("example.com/settings/pipelines"));
            addButton.Click();
        }
        public void AddLeadSource()
        {
            Assert.That(GetURL, Is.EqualTo("example.com/settings/lead-source"));
            addButton.Click();
        }
        public void AddSector()
        {
            Assert.That(GetURL, Is.EqualTo("example.com/settings/sectors"));
            addButton.Click();
        }
        public void AddTower()
        {
            Assert.That(GetURL, Is.EqualTo("example.com/settings/towers"));
            addButton.Click();
        }
        public void AddPeipelineOrder()
        {
            Assert.That(GetURL, Is.EqualTo("example.com/settings/pipeline-orders"));
            addButton.Click();
        }


    }
}

