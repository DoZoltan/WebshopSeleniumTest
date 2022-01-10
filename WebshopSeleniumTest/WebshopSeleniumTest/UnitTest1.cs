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
            // Hozzk l�tre a sz�ks�ges driver-t, itt adjuk meg, h milyen b�ng�sz�t akarunk haszn�lni
            Driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            //Adjuk meg a website c�m�t, amit meg akarunk nyitni a kiv�lasztott b�ng�sz�vel
            Driver.Navigate().GoToUrl("https://www.gamestar.hu/");

            Assert.Pass();
        }
    }
}