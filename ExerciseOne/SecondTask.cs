using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace ExerciseTwo {
    public class SecondTask
    {
        public IWebDriver driver;
        private readonly string URL = @"https://login.bluehost.com/hosting/webmail";
        private readonly string SUBMIT = @"//input[@type='submit']";
        private readonly string ERROR = @"//span[@class='error']";
        private readonly string EMAIL_IS_REQUIRED = @"//span[@class='error'][1]";
        private readonly string PASSWORD_IS_REQUIRED = @"//span[@class='error'][2]";
        private readonly string ERROR_MESSAGE = "Invalid login attempt. That account doesn't seem to be available.";

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [Test]
        public void RejectedLogin()
        {
            this.driver.Navigate().GoToUrl(URL);
            this.driver.FindElement(By.Id("email")).SendKeys("Ivan");
            this.driver.FindElement(By.Id("password")).SendKeys("Ivan");
            this.driver.FindElement(By.XPath(SUBMIT)).Click();
            Assert.AreEqual(ERROR_MESSAGE, driver.FindElement(By.XPath(ERROR)).Text);
        }

        [Test]
        public void LoginWithoutEnteringValues()
        {
            this.driver.Navigate().GoToUrl(URL);
            this.driver.FindElement(By.XPath(SUBMIT)).Click();
            Assert.AreEqual("Email is required.", driver.FindElement(By.XPath(EMAIL_IS_REQUIRED)).Text);
            Assert.AreEqual("Password is required.", driver.FindElement(By.XPath(PASSWORD_IS_REQUIRED)).Text);
        }


        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Quit();
        }
    }
}