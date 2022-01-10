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

            // Ha nincs azonosítója az elemönknek / tag-ünk nek akkor az elérési útvonalát kell megadni
            // --> a nav-link text-white class névvel elátott div tag-en belüli label, aminek az innertext-je Brand
            // a Click()-el pedig rákattintunk a kiválasztott elemre
            Driver.FindElement(By.XPath("//div[@class='nav-link text-white']//label[text()='Brand']")).Click();

            // majd írd be ezt az inputba
            Driver.FindElement(By.ClassName("search-input")).SendKeys("Asus");

            Assert.Pass();
        }
    }
}