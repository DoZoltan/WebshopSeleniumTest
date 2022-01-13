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
        public void TestDropdownAtCreateProductMenu()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/products/cpu");

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //V�lazd ki az elemet, amire gomb kombin�ci�val akarsz kattintani
            var adminButton = Driver.FindElement(By.LinkText("Admin"));

            //Hozz l�tre egy actions-�t
            Actions actions = new Actions(Driver);

            //Add meg a gomb kombin�ci�kat �s a kiv�lasztott elemet
            actions.KeyDown(Keys.LeftControl).Click(adminButton);
            
            //�p�tsd fel a kombin�ci�t
            IAction multiple = actions.Build();
            
            //Hajtsd v�gre a m�veletet
            multiple.Perform();

            //Nyisd meg az admin fel�letet
            //Driver.FindElement(By.LinkText("Admin"));

            //Nyisd meg a term�k friss�t�s fel�letet
            //Driver.FindElement(By.XPath("//a[@href='/admin/products/update']")).Click();

            //A term�k friss�t�sn�l �sd be a keres� mez�be, hogy ram
            //Driver.FindElement(By.ClassName("search-input")).SendKeys("ram");

            //Az els� tal�latra kattints r� a grid-en
            //Driver.FindElement(By.XPath("//div[@class='ag-row-even ag-row-no-focus ag-row ag-row-level-0 ag-row-position-absolute ag-row-first ag-after-created']/div[1]")).Click();

            //Kattints r� a t�rl�s gombra
            //Driver.FindElement(By.XPath("//button[text()='Delete']")).Click();

            //V�lts �t a felugr� meger�s�t� ablakra �s fogadd el
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