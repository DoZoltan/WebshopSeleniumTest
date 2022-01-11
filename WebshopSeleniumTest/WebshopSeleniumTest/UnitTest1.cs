using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebshopSeleniumTest
{
    public class Tests
    {
        private IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/products/cpu");
            Driver.Manage().Window.FullScreen();

            //Driver.FindElement(By.XPath("//a[@href='/admin']")).Click();
            Driver.FindElement(By.LinkText("Admin")).Click();

            Driver.FindElement(By.XPath("//a[@href='/admin/products/add']")).Click();

            var element = Driver.FindElement(By.XPath("//select[@id='socketType']"));

            var isDispalyed = element.Displayed;

            if (isDispalyed)
            {
                SelectElement selectElement = new SelectElement(element);
                selectElement.SelectByText("G34");
            }

            Assert.That(element.Displayed, Is.True);
        }
    }
}