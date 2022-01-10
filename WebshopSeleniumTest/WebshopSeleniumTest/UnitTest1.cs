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
            // Hozzk létre a szükséges driver-t, itt adjuk meg, h milyen böngészõt akarunk használni
            Driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            //Adjuk meg a website címét, amit meg akarunk nyitni a kiválasztott böngészõvel
            Driver.Navigate().GoToUrl("https://www.gamestar.hu/");

            Assert.Pass();
        }
    }
}