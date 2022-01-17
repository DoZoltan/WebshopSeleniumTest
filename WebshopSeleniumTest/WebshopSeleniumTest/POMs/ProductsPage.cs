using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace WebshopSeleniumTest.POMs
{
    internal class ProductsPage : BasePage
    {        
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

        public ProductsPage(IWebDriver driver) : base(driver, "http://localhost:4200/products/cpu")
        {
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

        // Valamiért nem csak a pontos találatokat kapom meg így
        // Miközben manuálisan tesztelve ctrl+v -vel beillesztve ugyan azt a szöveget, mint itt
        // megkapom a helyes találatot
        //public void SearchByName(string productName)
        //{
        //    ByNameRadioButton.Click();
        //    SearchInputField.SendKeys(productName);
        //}

        //public void SearchByBrand(string brand)
        //{
        //    ByBrandRadioButton.Click();
        //    SearchInputField.SendKeys(brand);
        //}

        public void SearchByNameSimulateHumanTyping(string productName)
        {
            ByNameRadioButton.Click();

            foreach (var letter in productName)
            {
                Thread.Sleep(350);
                SearchInputField.SendKeys(letter.ToString());
            }
        }

        public void SearchByBrandSimulateHumanTyping(string brand)
        {
            ByBrandRadioButton.Click();

            foreach (var letter in brand)
            {
                Thread.Sleep(350);
                SearchInputField.SendKeys(letter.ToString());
            }
        }

        public int GetNumberOfGridRows()
        {
            var gridElements = _driver.FindElements(By.XPath($"//ag-grid-angular[@class='ag-theme-balham ag-grid']//div[@class='ag-center-cols-container']/div"));
            
            if (gridElements != null)
            {
                return gridElements.Count;
            }

            return 0;
        }

        public void ProductClickOnGridByRowNumber(int rowNumber)
        {
            _driver.FindElement(By.XPath($"//ag-grid-angular[@class='ag-theme-balham ag-grid']//div[@class='ag-center-cols-container']/div[{rowNumber}]")).Click();
        }

        public void ProductClickOnGridByProductName(string productName)
        {
            _driver.FindElement(By.XPath($"//div[text()='{productName}']")).Click();
        }

        public string GetProductNameByGridRowNumber(int rowNumber)
        {
            var gridElement = _driver.FindElement(By.XPath($"//ag-grid-angular[@class='ag-theme-balham ag-grid']//div[@class='ag-center-cols-container']/div[{rowNumber}]/div[1]"));

            if (gridElement != null)
            {
                return gridElement.Text;
            }

            return string.Empty;
        }

        public string GetProductBrandByGridRowNumber(int rowNumber)
        {
            var gridElement = _driver.FindElement(By.XPath($"//ag-grid-angular[@class='ag-theme-balham ag-grid']//div[@class='ag-center-cols-container']/div[{rowNumber}]/div[2]"));

            if (gridElement != null)
            {
                return gridElement.Text;
            }

            return string.Empty;
        }

        public void ClearSearchInputField()
        {
            SearchInputField.Clear();
        }
    }
}
