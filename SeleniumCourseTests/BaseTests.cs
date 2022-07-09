using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCourseTests
{
    public abstract class BaseTests
    {
        protected abstract string Url { get; }

        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            Driver = new ChromeDriver(chromeOptions);
            Driver.Navigate().GoToUrl(Url);
        }

        [TearDown]
        [Order(2)]
        public void Quit()
        {
            Driver.Quit();
        }
    }
}