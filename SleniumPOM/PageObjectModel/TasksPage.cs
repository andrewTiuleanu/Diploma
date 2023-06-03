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
    internal class TasksPage : Paginator
    {
        public TasksPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }
        private IWebElement menuItemLast => _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("(//mat-option[@role='option']/span)[last()]"))));
        private string menuItemXpath => "(//mat-option[@role='option']/span)";

        private Dictionary<int, string> menuItems = new Dictionary<int, string>();
        private void createMenuMap()
        {
            int i = 1;
            string temp = menuItemLast.Text;
            while (!String.Equals(temp, _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath(menuItemXpath + "[" + i + "]")))).Text))
            {
                menuItems.Add(i, _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath(menuItemXpath + "[" + i + "]")))).Text);
                i++;
            }
            menuItems.Add(i, menuItemLast.Text);

        }

        public void selectByIndex(int i)
        {
            menuItems.Clear();
            createMenuMap();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//mat-option[@role='option']/span[contains(text(),'" + menuItems[i] + "')]")))).Click();
        }

        public void selectByIndex(string menuOption)
        {
            menuItems.Clear();
            createMenuMap();
            if (menuItems.ContainsValue(menuOption))
                _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//mat-option[@role='option']/span[contains(text(),'" + menuOption + "')]")))).Click();
        }


        private By burgerTaskIcon => By.XPath("//div[@class='burger ng-star-inserted']/i");
        private IWebElement addTaskIcon => _driver.FindElement(By.XPath("//*[contains(text(),'Add Task') and @class='icon']"));

        //creation of the task form fields
        private IWebElement taskTypeMenu => _driver.FindElement(By.XPath("//*[@aria-label='Task Type']"));
        private IWebElement taskSubjectFieldForm => _driver.FindElement(By.XPath("(//input[@name='subject'])"));
        private IWebElement taskStatusMenuForm => _driver.FindElement(By.XPath("//*[@aria-label='Status']"));
        private IWebElement taskPriorityMenuForm => _driver.FindElement(By.XPath("//*[@aria-label='Priority']"));
        private IWebElement deadlineFieldForm => _driver.FindElement(By.XPath("//*/input[@id='deadline']"));
        private IWebElement descriptionFieldForm => _driver.FindElement(By.XPath("//*/div[@data-placeholder='Description']"));
        private IWebElement NewTaskButton => _driver.FindElement(By.ClassName("mat-focus-indicator mat-raised-button mat-button-base mat-primary"));


        //--------------------------------------------------------------------------------------

        //"Add activity task" form
        //Task Type

        private void ClickHamburgerIconAddTask()
        {
            _wait.Until(ExpectedConditions.ElementExists(burgerTaskIcon)).Click();
        }
        public void ClickAddTask()
        {
            bool clickHappened = false;
            do
            {
                if (_wait.Until(ExpectedConditions.TextToBePresentInElement(addTaskIcon, "Add Task")))
                {
                    _wait.Until(ExpectedConditions.ElementToBeClickable(addTaskIcon)).Click();
                    clickHappened = true;
                }
                else
                {
                    ClickHamburgerIconAddTask();
                    clickHappened = true;
                }
            } while (!clickHappened);
        }
        public void ClickTaskTypeMenu()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(NewTaskButton)).Click();
        }

        public void SelectAddActivityTaskTypeFirstSubtype()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//div/span[contains(text(),'Select')]")))).Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//*/mat-option[@role='option'][1]")))).Click();
        }

        //Subject
        public void FillTaskCreationSubject()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(taskSubjectFieldForm)).SendKeys("Default Value Of Subject");
        }
        public void FillTaskCreationSubject(string subject)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//*[@name='subject']")))).SendKeys(subject);
        }
        //Status
        public void ClickTaskStatusMenu()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(taskStatusMenuForm)).Click();
        }
        /*private bool CheckIfStatusIsPresent(string name)
        {
            if (statusTypesForm.ContainsValue(name)) return true;
            else return false;
        }*/
        public void SelectAddActivityStatusType()
        {
            ClickTaskStatusMenu();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//span[@class = 'mat-option-text' and text()='In Progress']")))).Click();
        }
        /*public void SelectAddActivityStatusType(int taskTypeIndex)
        {
            if (CheckIfStatusIsPresent(statusTypesForm[taskTypeIndex]))
            {
                ClickTaskStatusMenu();
                _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//span[@class = 'mat-option-text' and text()='" + statusTypesForm[taskTypeIndex] + "']")))).Click();
            }
            else Assert.Pass("No such status in Status Type Menu");
        }*/
        //Priority
        public void ClickTaskPriorityMenu()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(taskPriorityMenuForm)).Click();
        }
        /*private bool CheckIfPriorityIsPresent(string name)
        {
            if (priorityTypesForm.ContainsValue(name)) return true;
            else return false;
        }*/
        public void SelectAddActivityPriorityType()
        {
            ClickTaskPriorityMenu();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//span[@class = 'mat-option-text' and text()='High ']")))).Click();
        }

        /*   public void SelectAddActivityPriorityType(int taskPriorityIndex)
        {
            if (CheckIfPriorityIsPresent(priorityTypesForm[taskPriorityIndex]))
            {
                ClickTaskPriorityMenu();
                _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//span[@class = 'mat-option-text' and text()='" + priorityTypesForm[taskPriorityIndex] + "']")))).Click();
            }
            else Assert.Pass("No such priority in priority Type Menu");
        }*/

        //Deadline
        public void ClickTaskDeadlinefield()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(deadlineFieldForm)).Click();
        }
        public void SelectDeadlineFisrstDayNextMonth()
        {
            ClickTaskDeadlinefield();

            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//*[@aria-label='Next month']")))).Click();

            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//*/div[@class='mat-calendar-body-cell-content' and text()= 1]")))).Click();
        }
        //Description
        public void FillTaskCreationDescription()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(descriptionFieldForm)).SendKeys("DefaultDescription");
        }
        public void FillTaskCreationDescription(string description)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(descriptionFieldForm)).SendKeys(description);
        }
        //Save
        public void ClickSaveTaskButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//button/span[@class= 'mat-button-wrapper' and text()='Save']")))).Click();
        }

        string expandTaskIcon = "(//div[contains(@class ,'block-icons')]/i[3])";
        string taskSubjectName = "(//mat-row/mat-cell/span[contains(text(),'Subject')]/../span[contains(@class,'cell-content')])";
        string taskStatusName = "(//mat-row/mat-cell/span[contains(text(),'Status')]/../span[contains(@class,'cell-content')])";
        string taskPriorityName = "(//mat-row/mat-cell/span[contains(text(),'Priority')]/../span[contains(@class,'cell-content')])";
        string taskAssignedToName = "(//mat-row/mat-cell/span[contains(text(),'Assigned To')]/../span[contains(@class,'cell-content')])";
        string taskDeadlineName = "(//mat-row/mat-cell/span[contains(text(),'Deadline')]/../span[contains(@class,'cell-content')])";
        string taskRelatedToName = "(//mat-row/mat-cell/span[contains(text(),'Related to')]/../span[contains(@class,'cell-content')])";



        //method edits the task selected by index in tasks list

        //Garbage(NOT FOR USE)
        /*public void SelectTaskCreationStatusInProgress()
        {
            taskStatusMenu.Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//*[contains(text(),'In Progress')]")))).Click();
        }
        public void SelectTaskCreationStatusAchieved()
        {
            taskStatusMenu.Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//*[contains(text(),'Achieved')]")))).Click();
        }
        */
        /*public void SelectTaskCreationPriorityHigh()
        {
            taskPriorityMenu.Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//*[contains(text(),'High')]")))).Click();
        }
        public void SelectTaskCreationPriorityMedium()
        {
            taskPriorityMenu.Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//*[contains(text(),'Medium')]")))).Click();
        }
        public void SelectTaskCreationPriorityLow()
        {
            taskPriorityMenu.Click();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//*[contains(text(),'Low')]")))).Click();
        }*/
        /*//Items per Page list
        private IWebElement itemsPerPageMenu => _driver.FindElement(By.XPath("//*[@role='listbox']/div/div[2]"));
        public void ClickItemsPerPageMenuMenu()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(itemsPerPageMenu)).Click();
        }
        private Dictionary<int, string> itemsPerPageTypes = new Dictionary<int, string>()
        {
        { 10, " 10 "},
        { 20, " 20 "},
        { 50, " 50 "},
        { 100, " 100 "}
        };
        public void SelectItemsPerPageAmount(int i)
        {
            Thread.Sleep(1500);
            ClickItemsPerPageMenuMenu();
            Thread.Sleep(1500);
            switch (i)
            {
                case 10:
                case 20:
                case 50:
                case 100:
                    {
                        _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//mat-option/span[@class = 'mat-option-text' and text()='" + itemsPerPageTypes[i] + "']")))).Click();
                        break;
                    }
                default:
                    {
                        Assert.Fail("No such amount of items");
                        break;
                    }
            }
        }*/
        /*private Dictionary<int, string> taskTypes = new Dictionary<int, string>()
        {
        { 1, " Client"},
        { 2, " Opportunity"},
        { 3, " Project"},
        { 4, " General Task"}
        };
        private By generalTaskType = By.XPath("//mat-option/span[text()=' General Task']");
        private By projectTaskType = By.XPath("//mat-option/span[contains(text(), 'Project')]");
        private By opportunityTaskType = By.XPath("//mat-option/span[contains(text(), 'Opportunity')]");
        private By contactTaskType = By.XPath("//mat-option/span[contains(text(), 'Contact')]");
        private By clientTaskType = By.XPath("//mat-option/span[contains(text(), 'Client')]");
        public void SelectTaskType(int taskTypeIndex)
        {
            if (taskTypes.ContainsKey(taskTypeIndex))
            {
                ClickTaskTypeMenu();
                _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath("//mat-option/span[contains(text(),'" + taskTypes[taskTypeIndex] + "']")))).Click();
            }
            else Assert.Fail("No such type in Task Type Menu");
        }
        public void SelectTaskType(string taskTypeName)
        {
            taskTypeName = taskTypeName.ToLower();
            switch (taskTypeName)
            {
                case "client":
                    {
                        _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(clientTaskType))).Click();
                        break;
                    }
                case "contact":
                    {
                        _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(contactTaskType))).Click();
                        break;
                    }
                case "opportunity":
                    {
                        _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(opportunityTaskType))).Click();
                        break;
                    }
                case "project":
                    {
                        _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(projectTaskType))).Click();
                        break;
                    }

                case "general task":
                    {
                        _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(generalTaskType))).Click();
                        break;
                    }
                default: Assert.Fail("No such type in Task Type Menu"); break;
            }
        }
        private Dictionary<int, string> statusTypesForm = new Dictionary<int, string>()
        {
        { 1, "In Progress"},
        { 2, "Achieved"}
        };
        private Dictionary<int, string> priorityTypesForm = new Dictionary<int, string>()
        {
        { 1, "High "},
        { 2, "Medium "},
        { 3, "Low "}
        };
         public void SelectTaskType()
        {
            ClickTaskTypeMenu();
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(generalTaskType))).Click();
        }
         
         
         */
    }
}
