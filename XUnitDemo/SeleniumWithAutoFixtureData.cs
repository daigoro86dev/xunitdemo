using AutoFixture;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using XUnitDemo.XUnitExtension;

namespace XUnitDemo
{
    public class SeleniumWithAutoFixtureData : IClassFixture<WebDriverFixture>
    {
        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public SeleniumWithAutoFixtureData(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestAltQueryFillDataWithAutoFixture()
        {
            var driver = webDriverFixture.ChromeDriver;
            var queryString = new Fixture().Create<string>();

            driver.Navigate().GoToUrl("https://duckduckgo.com/");
            driver.FindElementById("search_form_input_homepage").SendKeys(queryString);
            driver.FindElementById("search_button_homepage").Click();

            testOutputHelper.WriteLine($"Query with query string {queryString}");
        }

        [Fact]
        public void TestAltQueryFillDataWithType()
        {
            var driver = webDriverFixture.ChromeDriver;

            var fixture = new Fixture();
            var queryString = fixture.Build<QueryModel>().Create();

            driver.Navigate().GoToUrl("https://duckduckgo.com/");
            driver.FindElementById("search_form_input_homepage").SendKeys(queryString.SearchQuery);
            driver.FindElementById("search_button_homepage").Click();

            testOutputHelper.WriteLine($"Query with query string {queryString.SearchQuery}");
        }

        [Theory, AutoData]
        public void TestAltQueryFillDataWithAutoData(QueryModel queryModel)
        {
            var driver = webDriverFixture.ChromeDriver;

            driver.Navigate().GoToUrl("https://duckduckgo.com/");
            driver.FindElementById("search_form_input_homepage").SendKeys(queryModel.SearchQuery);
            driver.FindElementById("search_button_homepage").Click();

            testOutputHelper.WriteLine($"Query with query string {queryModel.SearchQuery}");
        }

        [Theory, QueryModelAttribute]
        public void TestAltQueryFillDataWithCustomAttribute(QueryModel queryModel)
        {
            var driver = webDriverFixture.ChromeDriver;

            driver.Navigate().GoToUrl("https://duckduckgo.com/");
            driver.FindElementById("search_form_input_homepage").SendKeys(queryModel.SearchQuery);
            driver.FindElementById("search_button_homepage").Click();

            testOutputHelper.WriteLine($"Query with query string {queryModel.SearchQuery} from custom attribute");
        }
    }
}
