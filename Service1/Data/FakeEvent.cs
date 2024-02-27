using System.Text;

using Bogus;
using Service1_API_Models;

namespace Service1.Data;
sealed internal class FakeEvent : IEventData
{
    private const string TENNIS_SPORT_NAME = "Tennis";

    /// <summary xml:lang = "en">
    /// Get Event Model with fake data
    /// </summary>
    /// <returns></returns>
    public EventModel GetData()
    {
        var fakeEvents = new Faker<EventModel>()
            .StrictMode(false)
            .RuleFor(o => o.SportName, f => f.PickRandom(FakeDataSetHelper.SportsName))
            .RuleFor(o => o.EventDate, f => f.Date.Soon(2))
            .RuleFor(o => o.CategoryName, (f, e) => f.PickRandom(FakeDataSetHelper.GetCategoriesName(e.SportName ?? "")))
            .RuleFor(o => o.ChampionshipName, (f, e) => f.PickRandom(FakeDataSetHelper.GetChampionships(e.SportName ?? "", e.CategoryName ?? "")))
            .RuleFor(o => o.EventName, (f, e) =>
            {
                if (e.SportName == TENNIS_SPORT_NAME)
                {
                    return new StringBuilder()
                    .Append(f.Name.LastName())
                    .Append(' ')
                    .Append(f.Name.FirstName())
                    .Append(" vs. ")
                    .Append(f.Name.LastName())
                    .Append(' ')
                    .Append(f.Name.FirstName())
                    .ToString();
                }
                var teams = f.PickRandom(FakeDataSetHelper.GetTeams(e.SportName ?? "", e.ChampionshipName ?? ""), 2)?.ToArray() ?? new string[] { "Team1", "Team2"};

                return new StringBuilder()
                    .Append(teams[0])
                    .Append(" vs. ")
                    .Append(teams[1])
                    .ToString();

            });
        return fakeEvents.Generate();
    }
}
