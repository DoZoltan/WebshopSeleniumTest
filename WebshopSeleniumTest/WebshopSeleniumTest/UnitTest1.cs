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

            // Válasszuk ki a fejléc menübõl az Admin lehetõséget, majd kattintsunk rá
            Driver.FindElement(By.XPath("//a[@href='/admin']")).Click();

            //A bal menüsávból az Add new product lehetõséget
            Driver.FindElement(By.XPath("//a[@href='/admin/products/add']")).Click();

            // Majd válasszuk ki a dropdown input-ot
            var element = Driver.FindElement(By.XPath("//select[@id='socketType']"));

            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText("G34");

            Assert.Pass();
        }
    }
}