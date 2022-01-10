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

            // V�lasszunk ki egy elemet a website-r�l
            // a webes alakalmaz�sunkat, amit tesztelni szeretn�nk �rdemes �gy elk�sz�teni, hogy minden html tag-nak van ID-ja,
            // mert az alapj�n a legegyszer�bb kiv�lasztani az elemet, amivel csin�lni szeretn�nk valamit

            // mivel az input mez�nknek (m�g) nincs ID-ja ez�rt a class neve alapj�n v�lasztom ki 
            // a SendKeys-ben adjuk meg, hogy mi legyen a mez�be �rva
            Driver.FindElement(By.ClassName("search-input")).SendKeys("2");

            //ag-row-last

            Assert.Pass();
        }
    }
}