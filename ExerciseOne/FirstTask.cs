using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace ExerciseOne
{
    public class FirstTask
    {
        public IWebDriver driver;

        private readonly string URL = @"https://www.selenium.dev/documentation/en/getting_started/";
        private readonly string GRID = @"//a[@href='https://www.selenium.dev/documentation/en/grid/']";
        private readonly string COMPONENTS = @"//a[@href='https://www.selenium.dev/documentation/en/grid/grid_3/components_of_a_grid/']";
        private readonly string GIT_LINK = "top-github-link-text";


        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }



        [Test]
        public void CheckLinks()
        {
            driver.Navigate().GoToUrl(URL);
            this.driver.FindElement(By.XPath(GRID)).Click();
            Assert.AreEqual("Grid :: Documentation for Selenium", driver.Title);
            this.driver.FindElement(By.XPath(COMPONENTS)).Click();
            Assert.AreEqual("Components :: Documentation for Selenium", driver.Title);
            this.driver.FindElement(By.Id(GIT_LINK)).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            Assert.AreEqual("Sign in to GitHub · GitHub", driver.Title);
            //Assert.AreEqual("Editing seleniumhq.github.io/components_of_a_grid.en.md at dev · SeleniumHQ/seleniumhq.github.io", driver.Title);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Quit();
        }

    }
}