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
    internal class Audits : Tabs
    {

        public Audits(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }
        //Basical Elements
        private IWebElement saveButton => _driver.FindElement(By.XPath("//span[text()='Save']"));
        private IWebElement yesButton => _driver.FindElement(By.XPath("//span[@class='mat-button-wrapper' and text() ='Yes']"));
        private IWebElement noButton => _driver.FindElement(By.XPath("//span[@class='mat-button-wrapper' and text() ='No']"));
        private IWebElement cancelButton => _driver.FindElement(By.XPath("//button/span[@class= 'mat-button-wrapper' and text()='Cancel']"));
        private IWebElement tabName => _driver.FindElement(By.XPath("//*[@class ='block-title']"));

        //General add button for any of the tabs
        private IWebElement addButton => _driver.FindElement(By.XPath("//span[@class='icon-btn-label' and contains(text(),'Add')]"));
        //General search field visible for any of the tabs
        private IWebElement searchField => _driver.FindElement(By.XPath("//input[@placeholder = 'Search']"));

        //Field of search with dropdown list, used in SearchFromDropDownFor method
        private IWebElement searchDropdown => _driver.FindElement(By.XPath("//input[@placeholder = 'Search' and @aria-label ='dropdown search']"));

        //Field of title with appliable to some of the "Add" Audits forms
        private IWebElement titleField => _driver.FindElement(By.XPath("//input[@placeholder = 'Enter your title']"));
        //Field of description with appliable to some of the "Add" Audits forms
        private IWebElement descriptionField => _driver.FindElement(By.XPath("//textarea[@placeholder = 'Description']"));
        //Unique Fields for Add Question form
        private IWebElement questionField => _driver.FindElement(By.XPath("//textarea[@placeholder = 'Question']"));
        //Fields of template "Please Insert Answer Choice", which is an optional part of "Add Qustion" form.
        private IWebElement choiceField => _driver.FindElement(By.XPath("//input[@placeholder = 'Choice']"));
        private IWebElement scoreField => _driver.FindElement(By.XPath("//input[@placeholder = 'Score']"));
        //Fields For Editing and Deleting
        private IWebElement auditTypeDropdownField => _driver.FindElement(By.XPath("//mat-select[contains(@formcontrolname,'auditType')]"));
        private IWebElement sectionDropdownField => _driver.FindElement(By.XPath("//mat-select[@formcontrolname='sections']"));
        private IWebElement successfullMesageElement => _driver.FindElement(successfullMesage);

        private By successfullMesage = By.XPath("//span[contains(text(),'successfully')]");
        //Asserts
        public void AssertEnterEdit()
        {
            Thread.Sleep(500);
            bool feedBack = _driver.FindElement(By.XPath("(//*[contains(text(),'Edit')])[2]")).Text.Contains("Edit");
            Assert.IsTrue(feedBack);
        }
        public void AssertSortApplied()
        {
            Thread.Sleep(500);

        }
        public void AssertChoisesEnables()
        {

            bool feedBack = _driver.FindElement(By.XPath("//label[contains(text(), 'Please Insert')]")).Text.Contains("Choices");
            if (feedBack == false)
            {
                Assert.Fail("Choises template is not enabled");
            }
        }
        public void AssertSuccessfullMessage()
        {
            Assert.IsTrue(successfullMesageElement.Text.Contains("successfully"));
            
        }
        //Unused parametrized strings(No clue)
        string firstRecordInTheList = "((//mat-cell/span[text()='{0}:']/../span[text()='{1}'])/../../*/div[contains(@class ,'block-icons')]/i[{2}])[1]";
        //string editIcon = "(//div[contains(@class ,'block-icons')]/i{0})";
        //string deleteIcon = "(//div[contains(@class ,'block-icons')]/i{0})";

        public void SearchFor(string text)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(searchField)).Click();
            FillSearchField(text);

        }
        public void Edit(string text)
        {
            SearchFor(text);
            switch (tabName.Text)
            {
                case " Audit - Sections ":
                    {
                        SortRowsBy("Created At");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Section Title", text, "1"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Section Title:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[1])[1]")).Click();
                        AssertEnterEdit();
                        FillSectionForm(titleField.Text, auditTypeDropdownField.Text, forDeletePrefix);
                        break;
                    }
                case " Audit - Recommendations ":
                    {
                        SortRowsBy("Created At");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Recommendation", text, "1"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Recommendation:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[1])[1]")).Click();
                        AssertEnterEdit();
                        FillRecommendationForm(forDeletePrefix);
                        break;
                    }
                case " Audit - Risks ":
                    {
                        SortRowsBy("Created At");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Risk", text, "1"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Risk:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[1])[1]")).Click();
                        AssertEnterEdit();
                        FillRiskForm(forDeletePrefix);
                        break;
                    }
                case " Audit - Questions ":
                    {
                        SortRowsBy("Question Title");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Question Title", text, "2"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Question Title:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[2])[1]")).Click();
                        AssertEnterEdit();
                        FillQuestionForm(auditTypeDropdownField.Text, sectionDropdownField.Text, forDeletePrefix, "Input");
                        break;
                    }
                case " Audit - Templates ":
                    {
                        SortRowsBy("Template Title");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Template Title", text, "3"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Template Title:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[3])[1]")).Click();
                        AssertEnterEdit();
                        break;
                    }
                case " Audit Types ":
                    {
                        SortRowsBy("Created At");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Name", text, "1"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Name:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[1])[1]")).Click();
                        AssertEnterEdit();
                        FillAuditTypeForm(forDeletePrefix, descriptionField.Text);
                        break;
                    }
                default:
                    Assert.Fail("Incorrect tab. Current tab is " + tabName.Text + ".");
                    break;
            }
            AssertSuccessfullMessage();

        }
        public void Delete(string text)
        {

            switch (tabName.Text)
            {
                case " Audit - Sections ":
                    {
                        SortRowsBy("Created At");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Section Title", text, "2"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Section Title:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[2])[1]")).Click();
                        break;
                    }
                case " Audit - Recommendations ":
                    {
                        SortRowsBy("Created At");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Recommendation", text, "2"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Recommendation:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[2])[1]")).Click();
                        break;
                    }
                case " Audit - Risks ":
                    {
                        SortRowsBy("Created At");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Risk", text, "2"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Risk:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[2])[1]")).Click();
                        break;
                    }
                case " Audit - Questions ":
                    {
                        SortRowsBy("Question Title");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Question Title", text, "3"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Question Title:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[3])[1]")).Click();
                        break;
                    }
                case " Audit - Templates ":
                    {
                        SortRowsBy("Template Title");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Template Title", text, "4"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Template Title:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[4])[1]")).Click();

                        break;
                    }
                case " Audit Types ":
                    {
                        SortRowsBy("Created At");
                        _driver.FindElement(By.XPath(string.Format(firstRecordInTheList, "Name", text, "2"))).Click();
                        //_driver.FindElement(By.XPath("((//mat-cell/span[text()='Name:']/../span[text()='" + text + "'])/../../*/div[contains(@class ,'block-icons')]/i[2])[1]")).Click();
                        break;
                    }
                default:
                    {
                        Assert.Fail("Incorrect tab. Current tab is " + tabName.Text + ".");
                        break;
                    }
            }
            _wait.Until(ExpectedConditions.ElementToBeClickable(yesButton)).Click();
            AssertSuccessfullMessage();
        }

        private string radioButtonString = "(//mat-radio-group[@formcontrolname='questionTypeId' and @role ='radiogroup'])";
        private string radioButtonText = "//mat-label[text()=' {0} ']";
        public void ClickSave()
        {
            Thread.Sleep(1000);
            _wait.Until(ExpectedConditions.ElementToBeClickable(saveButton)).Click();
        }
        public void ClickCancel()
        {
            Thread.Sleep(1000);
            _wait.Until(ExpectedConditions.ElementToBeClickable(saveButton)).Click();
        }
        public void AddSection(string title, string auditType, string description)
        {
            Assert.That(addButton.Text, Is.EqualTo("Add Section"));
            addButton.Click();
            FillSectionForm(title, auditType, description);
        }
        private void FillSectionForm(string title, string auditType, string description)
        {
            FillTitle(title);
            SearchFromDropDownFor("Audit type", auditType);
            FillDescription(description);
            _wait.Until(ExpectedConditions.ElementToBeClickable(saveButton));
            ClickSave();
        }
        public void AddRecommendation(string title)
        {
            Assert.That(addButton.Text, Is.EqualTo("Add Recommendation"));
            addButton.Click();
            FillRecommendationForm(title);
        }
        private void FillRecommendationForm(string title)
        {
            FillTitle(title);
            ClickSave();
        }

        public void AddRisk(string title)
        {
            Assert.That(addButton.Text, Is.EqualTo("Add Risk"));
            addButton.Click();
            FillRiskForm(title);
        }
        private void FillRiskForm(string title)
        {
            FillTitle(title);
            ClickSave();
        }

        public void AddQuestion(string auditType, string section, string Question, string buttonName)
        {
            Assert.That(addButton.Text, Is.EqualTo("Add Question"));
            addButton.Click();
            FillQuestionForm(auditType, section, Question, buttonName);
        }

        private void FillQuestionForm(string auditType, string section, string Question, string buttonName)
        {
            SearchFromDropDownFor("Audit type", auditType);
            SearchFromDropDownFor("Section", section);
            FillQuestion(Question);
            selectRadioButton(buttonName);
            ClickSave();
        }

        private void FillInsertAnswerChoices(string choice, int score)
        {
            AssertChoisesEnables();
            WriteText(choiceField, choice);
            WriteText(scoreField, score.ToString());
        }
        private void FillQuestionForm(string auditType, string section, string Question, string buttonName, string choice, int score)
        {
            SearchFromDropDownFor("Audit type", auditType);
            SearchFromDropDownFor("Section", section);
            FillQuestion(Question);
            selectRadioButton(buttonName);
            FillInsertAnswerChoices(choice, score);
            ClickSave();
        }
        public void AddTemplate()
        {
            Assert.That(addButton.Text, Is.EqualTo("Add Template"));
            addButton.Click();
        }
        public void AddAuditType(string title, string description)
        {
            Assert.That(addButton.Text, Is.EqualTo("Add Audit Type"));
            addButton.Click();
            FillAuditTypeForm(title, description);
        }
        private void FillAuditTypeForm(string title, string description)
        {
            FillTitle(title);
            FillDescription(description);
            _wait.Until(ExpectedConditions.ElementToBeClickable(saveButton));
            ClickSave();
        }
        public void FillTitle(string text)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(titleField));
            WriteText(titleField, text);
        }
        public void FillDescription(string text)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(descriptionField));
            WriteText(descriptionField, text);
        }
        public void FillQuestion(string text)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(questionField));
            WriteText(questionField, text);
        }
        public void FillSearchField(string text)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(searchField));
            WriteText(searchField, text);
        }
        public void selectRadioButton(string text)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(radioButtonString + string.Format(radioButtonText, text)))).Click();
        }
        public void SearchFromDropDownFor(string type, string text)

        {
            switch (type)
            {
                case "Audit type":
                    {
                        Thread.Sleep(500);
                        _wait.Until(ExpectedConditions.ElementToBeClickable(auditTypeDropdownField)).Click();
                        break;
                    }
                case "Section":
                    {
                        Thread.Sleep(500);
                        _wait.Until(ExpectedConditions.ElementToBeClickable(sectionDropdownField)).Click();
                        break;
                    }
                default:
                    Assert.Fail("Need to specify dropdown field to put the value in.");
                    break;
            }
            WriteText(searchDropdown, text);
            _wait.Until(ExpectedConditions.ElementToBeClickable(_driver.FindElement(By.XPath(string.Format("//span[@class='mat-option-text' and text()=' {0} ']", text))))).Click();
        }

    }
}
