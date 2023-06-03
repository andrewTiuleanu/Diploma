using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SleniumPOM.PageObjectModel;
using System;
using TechTalk.SpecFlow;

namespace SeleniumFramework.Steps
{
    [Binding]
    public sealed class StepsDefinitions
    {
        IWebDriver _driver;
        WebDriverWait _wait;
        public void LoginWithValidCredentials()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--window-size=1620,1880");
            options.AddArgument("--incognito");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-popup-blocking");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl("example.com/login");
            LogInPage logInPage = new LogInPage(_driver, _wait);
            logInPage.ClickLogInButton();
            EmailPage emailPage = new EmailPage(_driver, _wait);
            emailPage.FillEmailField();
            emailPage.ClickNextButton();
            PasswordPage passwordPage = new PasswordPage(_driver, _wait);
            passwordPage.FillPasswordField();
            passwordPage.ClickNextButton();
            StayInSystemPage stayInSystemPage = new StayInSystemPage(_driver, _wait);
            stayInSystemPage.SelectCheckbox();
            stayInSystemPage.ClickYesButton();
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.AssertUrl();

        }

        [Given(@"I launch Advance Application")]
        public void GivenILaunchAdvanceApplication()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--window-size=1620,1880");
            options.AddArgument("--incognito");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-popup-blocking");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl("example.com/login");
        }

        [Given(@"I click login button")]
        public void GivenIClickLoginButton()
        {
            LogInPage logInPage = new LogInPage(_driver, _wait);
            logInPage.ClickLogInButton();

        }

        [Given(@"I enter following email")]
        public void GivenIEnterFollowingEmail()
        {
            EmailPage emailPage = new EmailPage(_driver, _wait);
            emailPage.FillEmailField();
        }

        [Given(@"I click submit button")]
        public void GivenIClickSubmitButton()
        {
            EmailPage emailPage = new EmailPage(_driver, _wait);
            emailPage.ClickNextButton();
        }

        [Given(@"I enter following password")]
        public void GivenIEnterFollowingPassword()
        {
            PasswordPage passwordPage = new PasswordPage(_driver, _wait);
            passwordPage.FillPasswordField();
        }
        [Given(@"I click next button")]
        public void GivenIClickNextButton()
        {
            PasswordPage passwordPage = new PasswordPage(_driver, _wait);
            passwordPage.ClickNextButton();
        }

        [Given(@"I agree i want to stay in system")]
        public void GivenIAgreeIWantToStayInSystem()
        {
            StayInSystemPage stayInSystemPage = new StayInSystemPage(_driver, _wait);
            stayInSystemPage.SelectCheckbox();
            stayInSystemPage.ClickYesButton();
        }


        [Then(@"Dashboard page appears")]
        public void ThenDashboardPageAppears()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.AssertUrl();
        }

        [Given(@"I am on the Advance application audits page")]
        public void GivenIAmOnTheAdvanceApplicationAuditsPage()
        {
            LoginWithValidCredentials();
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToAuditsPage();
        }

        [When(@"I click section tab")]
        public void WhenIClickSectionTab()
        {
            Audits audits = new Audits(_driver, _wait);
            audits.ClickOnTab("Sections");
        }

        [When(@"I click Section Title sorting option")]
        public void WhenIClickSectionTitleSortingOption()
        {
            Audits audits = new Audits(_driver, _wait);
            audits.SortRowsBy("Title");
        }

        [Then(@"Records are sorted by Section Title")]
        public void ThenRecordsAreSortedBySectionTitle()
        {
            Audits audits = new Audits(_driver, _wait);
            audits.AssertSortApplied();
        }

        [When(@"I click Audit type sorting option")]
        public void WhenIClickAuditTypeSortingOption()
        {
            Audits audits = new Audits(_driver, _wait);
            audits.SortRowsBy("Audit Type");
        }

        [Then(@"Records are sorted by Audit type")]
        public void ThenRecordsAreSortedByAuditType()
        {
            Audits audits = new Audits(_driver, _wait);
            audits.AssertSortApplied();
        }

        [When(@"I click Description sorting option")]
        public void WhenIClickDescriptionSortingOption()
        {
            Audits audits = new Audits(_driver, _wait);
            audits.SortRowsBy("Description");
        }

        [Then(@"Records are sorted by Description")]
        public void ThenRecordsAreSortedByDescription()
        {
            Audits audits = new Audits(_driver, _wait);
            audits.AssertSortApplied();
        }
        [When(@"I click Created By sorting option")]
        public void WhenIClickCreatedBySortingOption()
        {
            Audits audits = new Audits(_driver, _wait);
            audits.SortRowsBy("Created By");
        }
        [Then(@"Records are sorted by Created By")]
        public void ThenRecordsAreSortedByCreatedBy()
        {
            Audits audits = new Audits(_driver, _wait);
            audits.AssertSortApplied();
        }
        [When(@"I click Created At sorting option")]
        public void WhenIClickCreatedAtSortingOption()
        {
            Audits audits = new Audits(_driver, _wait);
            audits.SortRowsBy("Created At");
        }
        [Then(@"Records are sorted by Created At")]
        public void ThenRecordsAreSortedByCreatedAt()
        {
            Audits audits = new Audits(_driver, _wait);
            audits.AssertSortApplied();
        }
        [Then(@"Add Section Form is displayed")]


        [When(@"I click Add Section button")]
        public void WhenIClickAddSectionButton()
        {
        }

        public void ThenAddSectionFormIsDisplayed()
        {
        }

        [When(@"I fill data with (.*), (.*), (.*)")]
        public void WhenIFillDataWithAuditTitleAuditTypeDescription(string title,string type,string decription)
        {
            Audits audits = new Audits(_driver, _wait);
            audits.AddSection(title,type,decription);
            audits.AssertSuccessfullMessage();
        }
        [When(@"I Click save bytton")]
        public void WhenIClickSaveBytton()
        {
           
        }
        [Then(@"Audit Section is Saved")]
        public void ThenAuditSectionIsSaved()
        {
        }




    }
}