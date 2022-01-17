using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using WebshopSeleniumTest.POMs;

namespace Tesets.WebshopSeleniumTest
{
    public class ProductsPageTests
    {
        private IWebDriver Driver;
        private ProductsPage Page;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Page = new ProductsPage(Driver);
        }

        [Test]
        public void TestSearchByProductName()
        {
            string searchText = "Test CPU 1";

            Page.OpenPage();

            Page.SearchByNameSimulateHumanTyping(searchText);

            Assert.AreEqual(searchText, Page.GetProductNameByGridRowNumber(1));
        }

        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(1500);
            Driver.Quit();
        }
    }
}