using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
        public void PracticeTest()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/products/cpu");

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            var adminButton = Driver.FindElement(By.LinkText("Admin"));

            Actions actions = new Actions(Driver);

            actions.KeyDown(Keys.LeftControl).Click(adminButton).KeyUp(Keys.LeftControl);

            IAction multiple = actions.Build();

            multiple.Perform();

            string newTabUrl = "http://localhost:4200/admin";

            bool isSuccessful = true;

            if (Driver.WindowHandles.Count != 2)
            {
                isSuccessful = false;
            }

            if (isSuccessful)
            {
                Driver.SwitchTo().Window(Driver.WindowHandles[1]);

                //Nyisd meg az admin felületet
                //Driver.FindElement(By.LinkText("Admin")).Click();

                //Nyisd meg a termék frissítés felületet
                Driver.FindElement(By.XPath("//a[@href='/admin/products/update']")).Click();

                //A termék frissítésnél üsd be a keresõ mezõbe, hogy ram
                Driver.FindElement(By.ClassName("search-input")).SendKeys("ram");
            }

            //Az elsõ találatra kattints rá a grid-en
            //Driver.FindElement(By.XPath("//div[@class='ag-row-even ag-row-no-focus ag-row ag-row-level-0 ag-row-position-absolute ag-row-first ag-after-created']/div[1]")).Click();

            //Kattints rá a törlés gombra
            //Driver.FindElement(By.XPath("//button[text()='Delete']")).Click();

            //Válts át a felugró megerõsítõ ablakra és fogadd el
            //Driver.SwitchTo().Alert().Accept();

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