using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace CourseSeleniumTests
{
    internal class RegisterFormTests : BaseTests
    {
        protected override string Url => @"file:///C:/Learning/VisualStudioProjects/SeleniumTests-master/SeleniumTests/Htmls/Register/register.html";

        [Test]
        public void GoogleSearchTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"https://www.google.com/");
            driver.Manage().Window.Minimize();

            IWebElement searchElement = driver.FindElement(By.Name("q"));
            searchElement.SendKeys("Selenium Wikipedia");

            IWebElement searchButton = driver.FindElement(By.Name("btnK"));
            searchButton.Click();

            IWebElement firstResult = driver.FindElement(By.CssSelector("h3"));
            firstResult.Click();

            Assert.That(firstResult, Is.EqualTo("Selenium - Wikipedia"));


        }
    }
}
