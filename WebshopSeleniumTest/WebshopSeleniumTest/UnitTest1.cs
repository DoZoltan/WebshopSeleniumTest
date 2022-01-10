using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

            // Válasszunk ki egy elemet a website-ról
            // a webes alakalmazásunkat, amit tesztelni szeretnénk érdemes úgy elkészíteni, hogy minden html tag-nak van ID-ja,
            // mert az alapján a legegyszerûbb kiválasztani az elemet, amivel csinálni szeretnénk valamit

            // mivel az input mezõnknek (még) nincs ID-ja ezért a class neve alapján választom ki 
            // a SendKeys-ben adjuk meg, hogy mi legyen a mezõbe írva
            Driver.FindElement(By.ClassName("search-input")).SendKeys("2");

            //ag-row-last

            Assert.Pass();
        }
    }
}