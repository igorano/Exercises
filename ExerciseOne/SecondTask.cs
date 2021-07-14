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
        private readonly string url = @"https://login.bluehost.com/hosting/webmail";
        private readonly string submit = @"//input[@type='submit']";
        private readonly string error = @"//span[@class='error']";
        private readonly string Email_Is_Required = @"//span[@class='error'][1]";
        private readonly string Password_Is_Required = @"//span[@class='error'][2]";
        private readonly string Error_Message = "Invalid login attempt. That account doesn't seem to be available.";

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
            this.driver.Navigate().GoToUrl(url);
            this.driver.FindElement(By.Id("email")).SendKeys("Ivan");
            this.driver.FindElement(By.Id("password")).SendKeys("Ivan");
            this.driver.FindElement(By.XPath(submit)).Click();
            Assert.AreEqual(Error_Message, driver.FindElement(By.XPath(error)).Text);
        }

        [Test]
        public void LoginWithoutEnteringValues()
        {
            this.driver.Navigate().GoToUrl(url);
            this.driver.FindElement(By.XPath(submit)).Click();
            Assert.AreEqual("Email is required.", driver.FindElement(By.XPath(Email_Is_Required)).Text);
            Assert.AreEqual("Password is required.", driver.FindElement(By.XPath(Password_Is_Required)).Text);
        }


        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
            driver.Quit();
        }
    }
}