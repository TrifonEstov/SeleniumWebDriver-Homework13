using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverWebElement
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(@"C:\Users\trifo\source\repos\WebDriverWebElement\RegisterForm\register.html");
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}