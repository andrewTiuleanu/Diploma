using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SleniumPOM;
using SleniumPOM.PageObjectModel;
using System;
using System.Threading;

namespace TestsNamespace
{
    public class Tests
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        ChromeOptions options = new ChromeOptions();
        FirefoxOptions f_options = new FirefoxOptions();
        public void GoToURL(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        public void Close()
        {
            _driver.Quit();
        }
        public void Init_Browser()
        {
            options.AddArgument("--window-size=1620,1880");
            options.AddArgument("--incognito");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-popup-blocking");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        public void AssertGreeting()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Hi')]")));
            bool feedBack = _driver.FindElement(By.CssSelector("body")).Text.Contains("Hi Automation");
            Assert.IsTrue(feedBack);
        }
        public void LoginWithValidCredentials()
        {
            {
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
        }
        [SetUp]
        public void Setup()
        {
            Init_Browser();
            GoToURL("https://projectplanappweb-stage.azurewebsites.net/login");
            LoginWithValidCredentials();
        }
        //---------------------------------------------Tests---------------------------------------------

        [Test]
        public void SuccessfulLoginScenario()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.AssertUrl(); 
        }
        public void SuccessfullyDeleteTask()
        {
           
            Navigation navigation = new Navigation(_driver, _wait);
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.ClickViewTasks();
            TasksPage tasksPage = new TasksPage(_driver, _wait);
            tasksPage.SortRowsBy("Priority");
        }
        [Test]
        public void SuccessfullyChangeNumberOfVisibleTasks()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.ClickViewTasks();
            TasksPage tasksPage = new TasksPage(_driver, _wait);
            tasksPage.SelectItemsPerPageAmount(50);

        }

        [Test]
        public void SuccessfullyLogoutScenario()
        {
            
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.ClickLogOutButton();
        }
        [Test]
        public void SortAuditsSectionsRecordsByCreatedBy()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToAuditsPage();
            Audits audits = new Audits(_driver, _wait);
            audits.ClickOnTab("Sections");
            audits.SortRowsBy(4);
        }

        [Test]
        public void SwitchBetweenEveryTabOfAuditsPage()
        {
            
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToAuditsPage();
            Audits audits = new Audits(_driver, _wait);
            for (int i = 1; i <= 6; i++)
            {
                audits.ClickOnTab(i);
            }
        }
        string nameForTesting = "iVAN4IK";
        [Test]
        public void AuditsSectionsCRUDScenario()
        {
            
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToAuditsPage();
            Audits audits = new Audits(_driver, _wait);
            audits.ClickOnTab("Sections");
            audits.AddSection(nameForTesting, "1", "Description");
            audits.Edit(nameForTesting);
            audits.Delete(nameForTesting);

        }
        [Test]
        public void AuditsRecommendationCRUDScenario()
        {
            
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToAuditsPage();
            Audits audits = new Audits(_driver, _wait);
            audits.ClickOnTab("Recommendations");
            audits.AddRecommendation(nameForTesting);
            audits.Edit(nameForTesting);
            audits.Delete(nameForTesting + "For Delete");

        }
        [Test]
        public void AuditsRiscCRUDScenario()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToAuditsPage();
            Audits audits = new Audits(_driver, _wait);
            audits.ClickOnTab("Risks");
            audits.AddRisk(nameForTesting);
            audits.Edit(nameForTesting);
            audits.Delete(nameForTesting + "For Delete");
        }
        [Test]
        public void AuditsQuestionCRUDScenario()
        {
            
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToAuditsPage();
            Audits audits = new Audits(_driver, _wait);
            audits.ClickOnTab("Questions");
            audits.AddQuestion("1", "1", nameForTesting, "Input");
            audits.Edit(nameForTesting);
            audits.Delete(nameForTesting + "For Delete");
        }
        [Test]
        public void AuditsTypesCRUDScenario()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToAuditsPage();
            Audits audits = new Audits(_driver, _wait);
            audits.ClickOnTab("Audit Types");
            audits.AddAuditType(nameForTesting, "Description");
            audits.Edit(nameForTesting);
            audits.Delete(nameForTesting + "For Delete");
        }
        [Test]
        public void SuccessfullyChangeThemeToLightScenario()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.ClickSettingsButton();
            dashboardPage.ClickSettingsThemeButton();
            dashboardPage.SelectLightTheme();
            dashboardPage.ExitThemeSelection();
        }

        [Test]
        public void SuccessfullyChangeThemeToDarkScenario()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.ClickSettingsButton();
            dashboardPage.ClickSettingsThemeButton();
            dashboardPage.SelectDarkTheme();
            dashboardPage.ExitThemeSelection();
        }

        [Test]
        public void SortSettingsSkillsRecordsBySkill()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Skills");
            settingsPage.SortRowsBy("Skill");
        }

        [Test]
        public void SortSettingsSkillsRecordsByCategory()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Skills");
            settingsPage.SortRowsBy("Category");
        }

        [Test]
        public void SortSettingsSkillsRecordsByCreatedBy()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Skills");
            settingsPage.SortRowsBy("Created By");
        }

        [Test]
        public void SortSettingsSkillsRecordsByCreatedAt()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Skills");
            settingsPage.SortRowsBy("Created At");
        }

        [Test]
        public void SortSettingsSkillsRecordsByLinkedEmployees()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Skills");
            settingsPage.SortRowsBy("Linked Employees");
        }



        [Test]
        public void SortSettingsProjectTypesRecordsByProjectType()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Skills");
            settingsPage.SortRowsBy("Skill");
        }

        [Test]
        public void SortSettingsProjectTypesRecordsByCreatedBy()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Project Types");
            settingsPage.SortRowsBy("Created By");
        }

        [Test]
        public void SortSettingsProjectTypesRecordsByCreatedAt()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Project Types");
            settingsPage.SortRowsBy("Created At");
        }

        [Test]
        public void SortSettingsProjectTypesRecordsByProjectsAssigned()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Project Types");
            settingsPage.SortRowsBy("Projects Assigned");
        }

        [Test]
        public void SortSettingsJobRolesRecordsByJobRole()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Job Roles");
            settingsPage.SortRowsBy("Job Role");
        }
        [Test]
        public void SortSettingsJobRolesRecordsByDepartment()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Job Roles");
            settingsPage.SortRowsBy("Department");
        }
        [Test]
        public void SortSettingsJobRolesRecordsByBillable()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Job Roles");
            settingsPage.SortRowsBy("Billable");
        }
        [Test]
        public void SortSettingsJobRolesRecordsByCreatedBy()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Job Roles");
            settingsPage.SortRowsBy("Created By");
        }
        [Test]
        public void SortSettingsJobRolesRecordsByCreatedAt()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Job Roles");
            settingsPage.SortRowsBy("Created At");
        }
        [Test]
        public void SortSettingsJobRolesRecordsByEmployeesCount()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Job Roles");
            settingsPage.SortRowsBy("Employees Count");
        }

        [Test]
        public void SortSettingsAssignmentRolesRecordsByRole()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Assignment Roles");
            settingsPage.SortRowsBy("Role");
        }
        [Test]
        public void SortSettingsAssignmentRecordsByAssociatedJobRole()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait );
            settingsPage.ClickOnTab("Assignment Roles");
            settingsPage.SortRowsBy("Associated Job Role");
        }
        [Test]
        public void SortSettingsAssignmentRolesRecordsByCreatedBy()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Assignment Roles");
            settingsPage.SortRowsBy("Created By");
        }
        [Test]
        public void SortSettingsAssignmentRolesRecordsByCreatedAt()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Assignment Roles");
            settingsPage.SortRowsBy("Created At");
        }
        [Test]
        public void SortSettingsAssignmentRolesRecordsByAssignmentCount()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Assignment Roles");
            settingsPage.SortRowsBy("Assignment Count");
        }


        [Test]
        public void SortSettingsCommunicationTypesRecordsByCommunicationType()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Communication Types");
            settingsPage.SortRowsBy("Communication Type");
        }
        [Test]
        public void SortSettingsCommunicationTypesRecordsByDecription()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Communication Types");
            settingsPage.SortRowsBy("Decription");
        }
        [Test]
        public void SortSettingsCommunicationTypesRecordsByCreatedBy()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Assignment Roles");
            settingsPage.SortRowsBy("Created By");
        }
        [Test]
        public void SortSettingsCommunicationTypesRecordsByCreatedAt()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Assignment Roles");
            settingsPage.SortRowsBy("Created At");
        }

        [Test]
        public void SortSettingsFAQRecordsByQuestion()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("FAQ");
            settingsPage.SortRowsBy("Question");
        }
        [Test]
        public void SortSettingsFAQRecordsByAnswer()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("FAQ");
            settingsPage.SortRowsBy("Answer");
        }
        [Test]
        public void SortSettingsFAQRecordsByCreatedBy()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("FAQ");
            settingsPage.SortRowsBy("Created By");
        }
        [Test]
        public void SortSettingsFAQRecordsByCreatedAt()
        {
            DashboardPage dashboardPage = new DashboardPage(_driver, _wait);
            dashboardPage.GoToSettingsPage();
            SettingsPage settingsPage = new SettingsPage(_driver, _wait);
            settingsPage.ClickOnTab("Assignment Roles");
            settingsPage.SortRowsBy("Created At");
        }


        [TearDown]
        public void Teardown()
        {
            Thread.Sleep(5000);
            Close();
        }



    }


}