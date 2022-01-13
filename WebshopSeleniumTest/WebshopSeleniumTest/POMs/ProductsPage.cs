using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopSeleniumTest.POMs
{
    //kell egy basepage, ami tartalmaz minden közös dolgot
    internal class ProductsPage
    {
        private IWebDriver _driver;
        //private WebDriverWait wait;

        public string PageUrl { get; } = "http://localhost:4200/products/cpu";
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/products/cpu']")]
        public IWebElement CpuButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@href='/products/ram']")]
        public IWebElement RamButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/products/motherboard']")]
        public IWebElement MotherboardButton { get; set; }

        [FindsBy(How = How.Id, Using = "searchByName")]
        public IWebElement ByNameRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "searchByBrand")]
        public IWebElement ByBrandRadioButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "search-input")]
        public IWebElement SearchInputField { get; set; }

        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public void CpuButtonClick()
        {
            CpuButton.Click();
        }

        public void RamButtonClick()
        {
            RamButton.Click();
        }

        public void MotherboardButtonClick()
        {
            MotherboardButton.Click();
        }

        public void SearchByName(string productName)
        {
            ByNameRadioButton.Click();
            SearchInputField.SendKeys(productName);
        }

        public void SearchByBrand(string brand)
        {
            ByBrandRadioButton.Click();
            SearchInputField.SendKeys(brand);
        }

        public void ProductClickOnGridByRowNumber(int rowNumber)
        {
            _driver.FindElement(By.XPath($"//ag-grid-angular[@class='ag-theme-balham ag-grid']//div[@class='ag-center-cols-container']/div[{rowNumber}]")).Click();
        }

        public void ProductClickOnGridByProductName(string productName)
        {
            _driver.FindElement(By.XPath($"//div[text()='{productName}']")).Click();
        }
    }
}
