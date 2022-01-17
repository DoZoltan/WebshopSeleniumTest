using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebshopSeleniumTest.POMs
{
    internal class BasePage
    {
        protected readonly IWebDriver _driver;

        public string PageUrl { get; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/products/cpu']")] //később lesz "fő" products route: /products
        public IWebElement ProductsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/admin']")]
        public IWebElement AdminButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/login']")]
        public IWebElement LoginButton { get; set; }

        //[FindsBy(How = How.XPath, Using = "//a[@href='/logout']")] <-- még nem létezik
        //public IWebElement LogoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/registration']")]
        public IWebElement RegistrationButton { get; set; }

        public BasePage(IWebDriver driver, string pageUrl)
        {
            _driver = driver;
            PageUrl = pageUrl;
            // Ha jól értem, akkor a FindsBy attributumok miatt van rá szükség
            PageFactory.InitElements(driver, this);
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }

        public string GetPageUrl()
        {
            return _driver.Url;
        }
    }
}
