using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Axe;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FreeTube.UITests
{
    public class Tests
    {
        private static readonly string BaseUrl = "https://marmadilemanteater.github.io/freetube/#";
        private static readonly string ChannelUrl = $"{BaseUrl}/channel/UCyWDmyZRjrGHeKF-ofFsT5Q";
        private static readonly string TrendingUrl = $"{BaseUrl}/trending";
        private static readonly string SettingsUrl = $"{BaseUrl}/settings";
        private static readonly string WatchUrl = $"{BaseUrl}//watch/7IKab3HcfFk";

        IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new();
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--headless");
            driver = new ChromeDriver(options);
            AssertionOptions.FormattingOptions.MaxDepth = 15;
            AssertionOptions.FormattingOptions.MaxLines = 500;
        }

        [Test]
        public void TestMainPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
 
            Thread.Sleep(2500); // todo: replace with driver wait
            AxeBuilder axeBuilder = new(driver);
            AxeResult axeResult = axeBuilder.Analyze();

            axeResult.Violations.Should().BeEmpty();

        }

        [Test]
        public void TestChannel()
        {
            driver.Navigate().GoToUrl(ChannelUrl);

            Thread.Sleep(2500); // todo: replace with driver wait

            AxeBuilder axeBuilder = new(driver);
            AxeResult axeResult = axeBuilder.Analyze();

            axeResult.Violations.Should().BeEmpty();
        }

        [Test]
        public void TestTrending()
        {
            driver.Navigate().GoToUrl(TrendingUrl);

            Thread.Sleep(2500); // todo: replace with driver wait

            AxeBuilder axeBuilder = new(driver);
            AxeResult axeResult = axeBuilder.Analyze();

            axeResult.Violations.Should().BeEmpty();
        }

        [Test]
        public void TestSettings()
        {
            driver.Navigate().GoToUrl(SettingsUrl);

            Thread.Sleep(2500); // todo: replace with driver wait

            AxeBuilder axeBuilder = new(driver);
            AxeResult axeResult = axeBuilder.Analyze();

            axeResult.Violations.Should().BeEmpty();
        }

        [Test]
        public void TestWatch()
        {
            driver.Navigate().GoToUrl(WatchUrl);

            Thread.Sleep(2500); // todo: replace with driver wait

            AxeBuilder axeBuilder = new(driver);
            AxeResult axeResult = axeBuilder.Analyze();

            axeResult.Violations.Should().BeEmpty();
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}