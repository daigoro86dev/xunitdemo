using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace XUnitDemo
{
    //[Collection("Sequence Collection")]
    public class SeleniumWithContext : IClassFixture<WebDriverFixture>
    {
        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public SeleniumWithContext(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestAltQueryFillData(string queryString)
        {
            var driver = webDriverFixture.ChromeDriver;
            driver.Navigate().GoToUrl("https://duckduckgo.com/");
            driver.FindElementById("search_form_input_homepage").SendKeys(queryString);
            driver.FindElementById("search_button_homepage").Click();

            testOutputHelper.WriteLine($"Test Completed with {queryString} query");
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { "Duck"},
            new object[] { "Cat"},
            new object[] { "Bird"}
        };
    }
}
