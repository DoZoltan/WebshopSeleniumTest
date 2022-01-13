using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using WebshopSeleniumTest.POMs;

namespace Tesets.WebshopSeleniumTest
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
        public void PracticeTest()
        {
            //Driver.Navigate().GoToUrl("http://localhost:4200/products/cpu");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var productsPage = new ProductsPage(Driver);

            productsPage.OpenPage();

            //productsPage.MotherboardButtonClick();

            //productsPage.ProductClickOnGridByProductName("Test Motherboard 1");

            //productsPage.ProductClickOnGridByRowNumber(2);

            //productsPage.SearchByBrand("Asus");

            productsPage.SearchByName("moth");

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