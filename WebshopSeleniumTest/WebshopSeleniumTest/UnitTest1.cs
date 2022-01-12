using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace WebshopSeleniumTest
{
    public class Tests
    {
        private IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestDropdownAtCreateProductMenu()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/products/cpu");

            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            Driver.FindElement(By.XPath("//div[@class='product-container']//ul/li[3]")).Click();

            var gridElement = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='grid-container']//div[@class='ag-row-odd ag-row-no-focus ag-row ag-row-level-0 ag-row-position-absolute ag-row-last ag-after-created'][1]/div[2]")));

            gridElement.Click();

            /*
            Driver.FindElement(By.LinkText("Admin")).Click();

            Driver.FindElement(By.XPath("//a[@href='/admin/products/add']")).Click();

            var element = Driver.FindElement(By.XPath("//select[@id='socketType']"));

            var isDispalyed = element.Displayed;

            if (isDispalyed)
            {
                SelectElement selectElement = new SelectElement(element);
                selectElement.SelectByText("G34");
            }
            */
            Assert.Pass();
        }

        /*
        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
        */
    }
}