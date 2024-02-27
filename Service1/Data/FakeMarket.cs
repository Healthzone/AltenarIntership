using Bogus;

using Service1.Extensions;

using Service1_API_Models;

namespace Service1.Data;
sealed internal class FakeMarket : IMarketData
{
    /// <summary xml:lang = "en">
    /// Get Market model with fake data
    /// </summary>
    /// <param name="eventName">Specific event name</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public MarketEventModel GetData(string eventName)
    {
        if (string.IsNullOrWhiteSpace(eventName))
        {
            throw new ArgumentException($"{eventName} is null or empty", nameof(eventName));
        }
        var fakeMarket = new Faker<MarketEventModel>()
            .CustomInstantiator(f => new MarketEventModel(eventName))
            .RuleFor(u => u.Markets, f => GenerateMarketList());

        return fakeMarket.Generate();

    }

    /// <summary xml:lang = "en">
    /// Get List of fake Market entities
    /// </summary>
    /// <returns></returns>
    private static List<MarketModel> GenerateMarketList()
    {
        var faker = new Faker("en");
        return new List<MarketModel>()
        {
            new MarketModel("1x2",
            new List<OutcomeModel>{
                new OutcomeModel("1",  faker.Random.Decimal(1, 1.8m).Round(2)),
                new OutcomeModel("X", faker.Random.Decimal(1, 1.5m).Round(2)),
                new OutcomeModel("2", faker.Random.Decimal(1, 1.4m).Round(2))
            }),
            new MarketModel("Double Chance",
            new List<OutcomeModel>{
                new OutcomeModel("1X", faker.Random.Decimal(1, 1.4m).Round(2)),
                new OutcomeModel("12", faker.Random.Decimal(1, 1.5m).Round(2)),
                new OutcomeModel("X2", faker.Random.Decimal(1, 1.8m).Round(2))
            })
        };
    }
}
