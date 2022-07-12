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

        protected IWebElement FirstName
        {
            get
            {
                return Driver.FindElement(By.Id("fname"));
            }
        }

        protected IWebElement LastName
        {
            get
            {
                return Driver.FindElement(By.Id("lname"));
            }
        }

        protected IWebElement GenderMaleRadioButton
        {
            get
            {
                return Driver.FindElement(By.Id("male"));
            }
        }

        protected IWebElement GenderFemaleRadioButton
        {
            get
            {
                return Driver.FindElement(By.Id("female"));
            }
        }

        protected IWebElement HtmlCheckBoxLabel
        {
            get
            {
                return Driver.FindElement(By.CssSelector("label[for='html']"));
            }
        }

        protected IWebElement HtmlCheckBoxInput
        {
            get
            {
                return Driver.FindElement(By.CssSelector("input[id='html']"));
            }
        }

        protected IWebElement CssCheckBoxLabel
        {
            get
            {
                return Driver.FindElement(By.CssSelector("label[for='css']"));
            }
        }

        protected IWebElement CssCheckBoxInput
        {
            get
            {
                return Driver.FindElement(By.CssSelector("input[id='css']"));
            }
        }

        protected IWebElement CsCheckBoxLabel
        {
            get
            {
                return Driver.FindElement(By.CssSelector("label[for='cs']"));
            }
        }

        protected IWebElement CsCheckBoxInput
        {
            get
            {
                return Driver.FindElement(By.CssSelector("input[id='cs']"));
            }
        }

        protected IWebElement JsCheckBoxLabel
        {
            get
            {
                return Driver.FindElement(By.CssSelector("label[for='js']"));
            }
        }

        protected IWebElement JsCheckBoxInput
        {
            get
            {
                return Driver.FindElement(By.CssSelector("input[id='js']"));
            }
        }

        protected IWebElement ClearButton
        {
            get
            {
                return Driver.FindElement(By.Id("clear"));
            }
        }

        protected IWebElement RegisterButton
        {
            get
            {
                return Driver.FindElement(By.CssSelector("button[onclick='submitData()']"));
            }
        }

        private void EnterPersonData()
        {
            FirstName.SendKeys("Niki");
            LastName.SendKeys("G");
            GenderMaleRadioButton.Click();
            HtmlCheckBoxLabel.Click();
            CssCheckBoxLabel.Click();
            CsCheckBoxLabel.Click();
            JsCheckBoxLabel.Click();
        }

        [Test]
        public void ResetButtonTest()
        {
            EnterPersonData();

            Assert.That(FirstName.GetAttribute("value"), Is.EqualTo("Niki"));
            Assert.That(LastName.GetAttribute("value"), Is.EqualTo("G"));
            Assert.IsTrue(GenderMaleRadioButton.Selected);
            Assert.IsTrue(HtmlCheckBoxInput.Selected);
            Assert.IsTrue(CsCheckBoxInput.Selected);
            Assert.IsTrue(JsCheckBoxInput.Selected);
            Assert.IsTrue(CssCheckBoxInput.Selected);

            ClearButton.Click();

            Assert.That(FirstName.GetAttribute("value"), Is.EqualTo(""));
            Assert.That(LastName.GetAttribute("value"), Is.EqualTo(""));
            Assert.IsTrue(GenderMaleRadioButton.Selected);
            Assert.IsFalse(HtmlCheckBoxInput.Selected);
            Assert.IsFalse(CsCheckBoxInput.Selected);
            Assert.IsFalse(JsCheckBoxInput.Selected);
            Assert.IsFalse(CssCheckBoxInput.Selected);
        }

        [Test]
        public void RefreshPageTest()
        {
            EnterPersonData();

            Assert.That(FirstName.GetAttribute("value"), Is.EqualTo("Niki"));
            Assert.That(LastName.GetAttribute("value"), Is.EqualTo("G"));
            Assert.IsTrue(GenderMaleRadioButton.Selected);
            Assert.IsTrue(HtmlCheckBoxInput.Selected);
            Assert.IsTrue(CsCheckBoxInput.Selected);
            Assert.IsTrue(JsCheckBoxInput.Selected);
            Assert.IsTrue(CssCheckBoxInput.Selected);

            Driver.Navigate().Refresh();

            Assert.That(FirstName.GetAttribute("value"), Is.EqualTo(""));
            Assert.That(LastName.GetAttribute("value"), Is.EqualTo(""));
            Assert.IsTrue(GenderMaleRadioButton.Selected);
            Assert.IsFalse(HtmlCheckBoxInput.Selected);
            Assert.IsFalse(CsCheckBoxInput.Selected);
            Assert.IsFalse(JsCheckBoxInput.Selected);
            Assert.IsFalse(CssCheckBoxInput.Selected);
        }

        [Test]
        public void DisabledButtonsTest()
        {
            EnterPersonData();
            Assert.IsTrue(RegisterButton.Enabled);
            Assert.IsTrue(ClearButton.Enabled);

            FirstName.Clear();
            Assert.IsFalse(RegisterButton.Enabled);
            Assert.IsTrue(ClearButton.Enabled);

            LastName.Clear();
            Assert.IsFalse(RegisterButton.Enabled);
            Assert.IsFalse(ClearButton.Enabled);
        }

        [Test]
        public void DashedJobAreaTest()
        {
            IWebElement jobAreaDiv = Driver.FindElement(By.CssSelector("div[style='border-block:dashed;']"));

            Assert.That(jobAreaDiv.GetAttribute("style"), Is.EqualTo("border-block:dashed;"));
        }

        [Test]
        public void MaleRadioButtonLocationTest()
        {
            IWebElement maleRadioButton = Driver.FindElement(RelativeBy.WithLocator(By.Id("male")).LeftOf(GenderFemaleRadioButton));

            Assert.IsTrue(maleRadioButton.Selected);
        }

        [Test]
        public void NumberOfElementsWithSubmitDataAttributeTest()
        {
            IWebElement body = Driver.FindElement(By.TagName("body"));

            var elements = body.FindElements(By.CssSelector("button[onclick = 'submitData()']"));

            Assert.That(elements.Count, Is.EqualTo(2));
            Assert.That(elements[0].Displayed, Is.False);
            Assert.That(elements[1].Displayed, Is.True);
        }
    }
}

