using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumCourseTests;

namespace CourseSeleniumTests
{
    internal class RegisterFormTests : BaseTests
    {
        protected override string Url => @"file:///C:/Learning/VisualStudioProjects/SeleniumCourseTests/SeleniumCourseTests/RegisterForm/register.html";

        private void EnterPersonalData()
        {
            IWebElement firstName = Driver.FindElement(By.Id("fname"));
            firstName.SendKeys("Anna");

            IWebElement lastName = Driver.FindElement(By.Id("lname"));
            lastName.SendKeys("Smith");

            IWebElement genderFemale = Driver.FindElement(By.Id("female"));
            genderFemale.Click();
        }

        [Test]
        public void EnterDataWithTechnologiesTest()
        {
            EnterPersonalData();

            IWebElement htmlCheckBoxLabel = Driver.FindElement(By.CssSelector("label[for='html']"));
            htmlCheckBoxLabel.Click();

            IWebElement cssCheckBoxLabel = Driver.FindElement(By.CssSelector("label[for='css']"));
            cssCheckBoxLabel.Click();

            IWebElement jsCheckBoxLabel = Driver.FindElement(By.CssSelector("label[for='js']"));
            jsCheckBoxLabel.Click();

            IWebElement registerButton = Driver.FindElement(By.Id("submit"));
            registerButton.Click();

            Driver.SwitchTo().Alert().Accept();

            IWebElement body = Driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("Name: Anna Smith, Gender:Female"));
            Assert.IsTrue(body.Text.Contains("Favourite technologies: HTML,CSS,JavaScript"));
        }

        [Test]
        public void EnterDataWithoutTechnologiesTest()
        {
            EnterPersonalData();

            IWebElement registerButton = Driver.FindElement(By.Id("submit"));
            registerButton.Click();

            Driver.SwitchTo().Alert().Accept();

            IWebElement body = Driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("Name: Anna Smith, Gender:Female"));
            Assert.IsTrue(body.Text.Contains("No favourite technologies"));
        }
    }
}
