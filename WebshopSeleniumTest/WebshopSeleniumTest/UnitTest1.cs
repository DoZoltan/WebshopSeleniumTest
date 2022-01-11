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

            // V�lasszuk ki a fejl�c men�b�l az Admin lehet�s�get, majd kattintsunk r�
            Driver.FindElement(By.XPath("//a[@href='/admin']")).Click();

            //A bal men�s�vb�l az Add new product lehet�s�get
            Driver.FindElement(By.XPath("//a[@href='/admin/products/add']")).Click();

            // Majd v�lasszuk ki a dropdown input-ot
            var element = Driver.FindElement(By.XPath("//select[@id='socketType']"));

            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText("G34");

            Assert.Pass();
        }
    }
}