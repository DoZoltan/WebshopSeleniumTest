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

            // Ha nincs azonos�t�ja az elem�nknek / tag-�nk nek akkor az el�r�si �tvonal�t kell megadni
            // --> a nav-link text-white class n�vvel el�tott div tag-en bel�li label, aminek az innertext-je Brand
            // a Click()-el pedig r�kattintunk a kiv�lasztott elemre
            Driver.FindElement(By.XPath("//div[@class='nav-link text-white']//label[text()='Brand']")).Click();

            // majd �rd be ezt az inputba
            Driver.FindElement(By.ClassName("search-input")).SendKeys("Asus");

            Assert.Pass();
        }
    }
}