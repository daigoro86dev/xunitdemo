using AutoFixture;
using AutoFixture.Xunit2;

namespace XUnitDemo.XUnitExtension
{
    internal class QueryModelAttribute : AutoDataAttribute
    {
        public QueryModelAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customize<QueryModel>(x => x.With(x => x.SearchQuery, Faker.Lorem.Sentence));

            return fixture;
        })
        {
        }
    }
}
