using FluentAssertions;
using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;

namespace XUnitDemo
{
    [Collection("Sequence Collection")]
    public class SecondSeleniumTest : IClassFixture<WebDriverFixture>
    {

        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;
        public SecondSeleniumTest(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData("Elephant")]
        [InlineData("Crocodile")]
        [InlineData("Otter")]
        public void TestOriginalQueryFillData(string queryString)
        {
            var driver = webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("https://duckduckgo.com/");
            driver.FindElementById("search_form_input_homepage").SendKeys(queryString);
            driver.FindElementById("search_button_homepage").Click();

            testOutputHelper.WriteLine($"Test Completed with {queryString} query");
        }

        [Theory]
        [InlineData("Elephant")]
        [InlineData("Crocodile")]
        [InlineData("Otter")]
        public void TestQueryFillData(string queryString)
        {
            var driver = webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("https://duckduckgo.com/");
            driver.FindElementById("search_form_input_homepage").SendKeys(queryString);
            driver.FindElementById("search_button_homepage").Click();

            testOutputHelper.WriteLine($"Test Completed with {queryString} query");
        }

        [Fact]
        public void TestAssertThrows()
        {
            var driver = webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("https://duckduckgo.com/");

            var exception = Assert.Throws<NoSuchElementException>(() => driver.FindElementById("search_button_homepage_not_found").Click());

            // Assert.Contains("no such element", exception.Message);

            exception.Message.Should().Contain("no such element");

            testOutputHelper.WriteLine("Element was not fond");
        }

    }
}
