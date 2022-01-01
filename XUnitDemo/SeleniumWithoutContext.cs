using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;
using Xunit.Abstractions;

namespace XUnitDemo
{
    public class SeleniumWithoutContext
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly ChromeDriver _chromeDriver;

        public SeleniumWithoutContext(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            var driver = new DriverManager().SetUpDriver(new ChromeConfig());
            _chromeDriver = new ChromeDriver();
        }


        [Fact]
        public void Test1()
        {
            _testOutputHelper.WriteLine("First Test");
            _chromeDriver.Navigate().GoToUrl("https://duckduckgo.com/");
            _chromeDriver.Quit();
            _chromeDriver.Dispose();
        }
    }
}