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
    internal class Navigation
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        protected string pageURL;
        protected string GetURL
        {
            get { return _driver.Url; }
        }
        public Navigation(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        private IWebElement mainPageIcon => _driver.FindElement(By.LinkText("dashboard"));
        private IWebElement projectsPageIcon => _driver.FindElement(By.PartialLinkText("Proj"));
        private IWebElement overviewPageIcon => _driver.FindElement(By.XPath("//a[@id = 'overview-tab']"));
        private IWebElement employeesPageIcon => _driver.FindElement(By.XPath("/html/body/app-root/app-layout/div/app-nav/nav/div[2]/ng-scrollbar/div/div/div/div/ul/li[3]/a/mat-icon"));
        private IWebElement contactsPageIcon => _driver.FindElement(By.XPath("//a[@id = 'contacts-tab']"));
        private IWebElement clientsPageIcon => _driver.FindElement(By.XPath("//a[@id = 'clients-tab']"));
        private IWebElement opportunitiesPageIcon => _driver.FindElement(By.XPath("//a[@id = 'opportunities-tab']"));
        private IWebElement workforcePageIcon => _driver.FindElement(By.XPath("//a[@id = 'workforce-tab']"));
        private IWebElement aiInsightsPageIcon => _driver.FindElement(By.XPath("//a[@id = 'ai insights-tab']"));
        private IWebElement auditsPageIcon => _driver.FindElement(By.XPath("//a[@id = 'audits-tab']"));
        private IWebElement reportsPageIcon => _driver.FindElement(By.XPath("//a[@id = 'reports-tab']"));
        private IWebElement financePageIcon => _driver.FindElement(By.XPath("//a[@id = 'finance-tab']"));
        private IWebElement deliverySitesPageIcon => _driver.FindElement(By.XPath("//a[@id = 'delivery sites-tab']"));
        private IWebElement settingsPageIcon => _driver.FindElement(By.XPath("//a[@id = 'settings-tab']"));
        private IWebElement userProfileButton => _driver.FindElement(By.XPath("//a[@class='user-name']"));
        private IWebElement viewTasksButton => _driver.FindElement(By.XPath("//button[@id='viewTasksButton']"));
        private IWebElement notificationsButton => _driver.FindElement(By.XPath("//button/span/mat-icon"));
        private IWebElement settingsButton => _driver.FindElement(By.XPath("//div[@class='mat-menu-trigger settings']"));
        private IWebElement logOutButton => _driver.FindElement(By.XPath("//div[@class='log-out']"));
        private IWebElement themeButton => _driver.FindElement(By.XPath("//button[contains(text(),'Theme')]"));
        private IWebElement blackThemeImgIcon => _driver.FindElement(By.XPath("//img[@src='assets/images/dark-theme-icon.png']"));
        private IWebElement whiteThemeImgIcon => _driver.FindElement(By.XPath("//img[@src='assets/images/light-theme-icon.png']"));
        private IWebElement manageSubscriptionsSButton => _driver.FindElement(By.XPath("//button[contains(text(),'Manage Subscriptions')]"));
        private IWebElement exitButton => _driver.FindElement(By.XPath("//div/mat-icon[@type='button' and text()='cancel']"));
        private IWebElement unreadNotificationsGroup => _driver.FindElement(By.XPath("//button/div[contains(text(),'Unread')]"));
        private IWebElement readNotificationsGroup => _driver.FindElement(By.XPath("//button/div[contains(text(),'Read')]"));

        private string notificationMessage = "//mat-card/div[@class='message']";
        private string notificationCheck => "//div[@class='notification-check']/button[1]";

        private string notificationDelete = "//div[@class='notification-check']/button/*/i[@class='fas fa-trash']";
        private IWebElement advancedFilterNotificationsGroup => _driver.FindElement(By.XPath("//div[@class='actions']/button[1]"));
        private IWebElement readAllNotifications => _driver.FindElement(By.XPath("//div[@class='actions']/button[2]"));
        private IWebElement deleteAllNotifications => _driver.FindElement(By.XPath("//div[@class='actions']/button[3]"));

        private string subscribtionSwitchXpath = "//mat-slide-toggle/label";
        private string subscribtionNameXpath = "//div[contains(text(),'";
        protected string forDeletePrefix = "For Delete";
        protected string forUpdatePrefix = "For Update";
        public void GoToMainPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(mainPageIcon)).Click();
        }
        public void GoToOverviewPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(overviewPageIcon)).Click();
        }
        public void GoToProjectsPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(projectsPageIcon)).Click();
        }
        public void GoToEmployeesPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(employeesPageIcon)).Click();
        }
        public void GoToContactsPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(contactsPageIcon)).Click();
        }
        public void GoToClientsPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(clientsPageIcon)).Click();
        }
        public void GoToOpportunitiesPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(opportunitiesPageIcon)).Click();
        }
        public void GoToWorkforcePage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(workforcePageIcon)).Click();
        }
        public void GoToAiInsightsPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(aiInsightsPageIcon)).Click();
        }
        public void GoToAuditsPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(auditsPageIcon)).Click();
        }
        public void GoToReportsPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(reportsPageIcon)).Click();
        }
        public void GoToFinancePage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(financePageIcon)).Click();
        }
        public void GoToDeliverySitesPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(deliverySitesPageIcon)).Click();
        }
        public void GoToSettingsPage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(settingsPageIcon)).Click();
        }

        public void GoToUserProfile()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(userProfileButton)).Click();
        }
        public void ClickViewTasks()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(viewTasksButton)).Click();
        }
        public void ClickNotificationsButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(notificationsButton)).Click();
        }
        public void SelectUnreadNotificationByIndex(int index)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(" + notificationMessage + ")" + "[" + index + "]"))).Click();
        }
        public void DeleteNotificationByIndex(int index)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(" + notificationDelete + ")" + "[" + index + "]"))).Click();
        }
        public void ClickSettingsButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(settingsButton)).Click();
        }
        public void ClickLogOutButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(logOutButton)).Click();
        }
        public void ClickSettingsThemeButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(themeButton)).Click();
        }
        public void SelectDarkTheme()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(blackThemeImgIcon)).Click();
        }
        public void SelectLightTheme()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(whiteThemeImgIcon)).Click();
        }
        public void SelectSystemDefaultTheme()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(whiteThemeImgIcon)).Click();
        }
        public void ExitThemeSelection()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(exitButton)).Click();
        }
        public void ClickSettingsManageSubscriptions()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(manageSubscriptionsSButton)).Click();
        }
        public void TurnOffByIndexSubscription(int index)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("(" + subscribtionSwitchXpath + ")" + "[" + index + "]")))).Click();
        }
        public void TurnOffByNameSubscription(string name)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath(subscribtionNameXpath + name + "')]/../..(" + subscribtionSwitchXpath + ")")))).Click();
        }
        public void ExitSubscriptionsSelection()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(exitButton)).Click();
        }
        public void WriteText(IWebElement element, string text)
        {
            element.Click();
            element.SendKeys(text);
        }

    }
}
