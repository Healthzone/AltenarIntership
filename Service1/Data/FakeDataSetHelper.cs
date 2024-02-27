using System.Security.Cryptography.X509Certificates;

namespace Service1.Data;

/// <summary xml:lang = "en">
/// Fake dataset helper for Bogus
/// </summary>
sealed internal class FakeDataSetHelper
{
    public static string[] SportsName { get; } = new[] { "Soccer", "Tennis", "Hockey", "Cybersport" };

    #region Category Name
    private static string[] SoccerCategoryName { get; } = new[] { "Russia", "England", "Portugal" };
    private static string[] TennisCategoryName { get; } = new[] { "ATP", "WTA" };
    private static string[] HockeyCategoryName { get; } = new[] { "Russia", "USA", "Finland" };
    private static string[] CybersportCategoryName { get; } = new[] { "Dota 2", "Counter-Strike", "League of Legend" };
    #endregion

    #region Soccer Championships
    private static string[] SoccerRussiaChampionships { get; } = new[] { "Russian Premier League", "Russian First League", };
    private static string[] SoccerEnglandChampionships { get; } = new[] { "England Premier League", "EFL Championship" };
    private static string[] SoccerPortugalChampionships { get; } = new[] { "Portugal Premier League", "Portugal Second League" };
    #endregion

    #region Tennis Championships
    private static string[] TennisATPChampionships { get; } = new[] { "Vienna, Austria", "Paris, France" };
    private static string[] TennisWTAChampionships { get; } = new[] { "Zhuhai, China", "Tampico, Mexico" };
    #endregion

    #region Hockey Championships
    private static string[] HockeyRussiaChampionships { get; } = new[] { "KHL", "VHL" };
    private static string[] HockeyUSAChampionships { get; } = new[] { "NHL", "AHL" };
    private static string[] HockeyFinlandChampionships { get; } = new[] { "SM-liiga", "Mestis" };
    #endregion

    #region Cybersport Championships
    private static string[] CybersportDotaChampionships { get; } = new[] { "The International" };
    private static string[] CybersportCSChampionships { get; } = new[] { "RB Cup", "ESL Impact League Europe Division", "Thunderpick World Championship" };
    private static string[] CybersportLOLChampionships { get; } = new[] { "Coupe de France", "Iberian Cup", "World Championship" };
    #endregion

    #region Soccer Teams
    private static string[] SoccerRussianTeams { get; } = new[] { "Zenit", "Akhmat", "Spartak Moskva", "CSKA Moscow", "Rubin", "Krasnodar", "Dinamo" };
    private static string[] SoccerEnglandTeams { get; } = new[] { "Wolverhampton", "Newcastle United", "Liverpool", "Manchester United", "Manchester City" };
    private static string[] SoccerPortugalTeams { get; } = new[] { "S.L. Benfica", "Casa Pia", "Rio Ave" };
    #endregion

    #region Hockey Teams
    private static string[] HockeyRussianTeams { get; } = new[] { "Avangard", "Dinamo Minsk", "Traktor", "Severstal", "Sochi" };
    private static string[] HockeyUSATeams { get; } = new[] { "Toronto", "Detroit", "Boston", "Washington Capitals", "San Jose Sharks" };
    private static string[] HockeyFinlandTeams { get; } = new[] { "Kalpa", "Tappara", "Jukurit", "Pelicans", "Lukko" };
    #endregion

    #region Cybersport Teams
    private static string[] CybersportDotaTeams { get; } = new[] { "Team Liquid", "Gaimin Gladiators", "Team Spirit", "BB Team", "Fnatic", "Virtus.Pro" };
    private static string[] CybersportCSTeams { get; } = new[] { "Team Liquid", "OG", "Team Spirit", "Astralis", "Fnatic", "Virtus.Pro" };
    private static string[] CybersportLOLTeams { get; } = new[] { "Rise", "G2 Esports", "Giants", "Rebels", "Fnatic", "Team Go" };
    #endregion

    /// <summary xml:lang = "en">
    /// Get the array of categories for specific SportName
    /// </summary>
    /// <param name="sportName">Sportname string</param>
    /// <returns>Categories array of specific sport</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string[] GetCategoriesName(string sportName)
    {
        if (string.IsNullOrWhiteSpace(sportName))
        {
            throw new ArgumentException("SportName is null or empty", nameof(sportName));
        }

        return sportName switch
        {
            "Soccer" => SoccerCategoryName,
            "Tennis" => TennisCategoryName,
            "Hockey" => HockeyCategoryName,
            "Cybersport" => CybersportCategoryName,
            _ => throw new ArgumentException($"{sportName} doesn't exist in DataSet", nameof(sportName)),
        };
    }

    /// <summary xml:lang = "en">
    /// Get array of championships for specific Sportname and CaregoryName
    /// </summary>
    /// <param name="sportName">SportName string</param>
    /// <param name="categoryName">CategoryName string</param>
    /// <returns>Championships array of specific sport and category</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string[] GetChampionships(string sportName, string categoryName)
    {
        if (string.IsNullOrWhiteSpace(sportName))
        {
            throw new ArgumentException("SportName is null or empty", nameof(sportName));
        }
        if (string.IsNullOrWhiteSpace(categoryName))
        {
            throw new ArgumentException("CategoryName is null or empty", nameof(categoryName));
        }
        return sportName switch
        {
            "Soccer" => GetSoccerChampionships(categoryName),
            "Tennis" => GetTennisChampionships(categoryName),
            "Hockey" => GetHockeyChampionships(categoryName),
            "Cybersport" => GetCybersportChampionships(categoryName),
            _ => throw new ArgumentException($"{sportName} doesn't exist in DataSet", nameof(sportName)),
        };
    }

    /// <summary xml:lang = "en">
    /// Get array of teams for specific SportName and ChampionshipName
    /// </summary>
    /// <param name="sportName">SportName string</param>
    /// <param name="championshipName">CategoryName string</param>
    /// <returns>Teams array of specific sport and championship</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string[] GetTeams(string sportName, string championshipName)
    {
        if (string.IsNullOrWhiteSpace(sportName))
        {
            throw new ArgumentException("SportName is null or empty", nameof(sportName));
        }
        if (string.IsNullOrWhiteSpace(championshipName))
        {
            throw new ArgumentException("Championship is null or empty", nameof(championshipName));
        }

        return sportName switch
        {
            "Soccer" => GetSoccerTeams(championshipName),
            "Hockey" => GetHockeyTeams(championshipName),
            "Cybersport" => GetCybersportTeams(championshipName),
            _ => throw new ArgumentException($"{sportName} doesn't exist in DataSet", nameof(sportName)),
        };
    }

    #region Methods of getting specific teams
    /// <summary xml:lang = "en">
    /// Get soccer teams
    /// </summary>
    /// <param name="championshipName">Specific championship</param>
    /// <returns>Array of soccer teams</returns>
    /// <exception cref="ArgumentException"></exception>
    private static string[] GetSoccerTeams(string championshipName)
    {
        return championshipName switch
        {
            "Russian Premier League" or "Russian First League" => SoccerRussianTeams,
            "England Premier League" or "EFL Championship" => SoccerEnglandTeams,
            "Portugal Premier League" or "Portugal Second League" => SoccerPortugalTeams,
            _ => throw new ArgumentException($"{championshipName} doesn't exist in DataSet", nameof(championshipName)),
        };
    }

    /// <summary xml:lang = "en">
    /// Get hockey teams
    /// </summary>
    /// <param name="championshipName">Specific championship</param>
    /// <returns>Array of hockey teams</returns>
    /// <exception cref="ArgumentException"></exception>
    private static string[] GetHockeyTeams(string championshipName)
    {
        return championshipName switch
        {
            "KHL" or "VHL" => HockeyRussianTeams,
            "NHL" or "AHL" => HockeyUSATeams,
            "SM-liiga" or "Mestis" => HockeyFinlandTeams,
            _ => throw new ArgumentException($"{championshipName} doesn't exist in DataSet", nameof(championshipName)),
        };
    }

    /// <summary xml:lang = "en">
    /// Get cybersport teams
    /// </summary>
    /// <param name="championshipName"></param>
    /// <returns>Array of cyberport teams</returns>
    /// <exception cref="ArgumentException"></exception>
    private static string[] GetCybersportTeams(string championshipName)
    {
        return championshipName switch
        {
            "The International" => CybersportDotaTeams,
            "RB Cup" or "ESL Impact League Europe Division" or "Thunderpick World Championship" => CybersportCSTeams,
            "Coupe de France" or "Iberian Cup" or "World Championship" => CybersportLOLTeams,
            _ => throw new ArgumentException($"{championshipName} doesn't exist in DataSet", nameof(championshipName)),
        };
    }

    #endregion

    #region Methods of getting specific championships
    /// <summary xml:lang = "en">
    /// Get soccer championships
    /// </summary>
    /// <param name="categoryName">Specific category of soccer</param>
    /// <returns>Array of soccer championships</returns>
    /// <exception cref="ArgumentException"></exception>
    private static string[] GetSoccerChampionships(string categoryName)
    {
        return categoryName switch
        {
            "Russia" => SoccerRussiaChampionships,
            "England" => SoccerEnglandChampionships,
            "Portugal" => SoccerPortugalChampionships,
            _ => throw new ArgumentException($"{categoryName} doesn't exist in DataSet", nameof(categoryName)),
        };
    }
    /// <summary xml:lang = "en">
    /// Get hockey championships
    /// </summary>
    /// <param name="categoryName">Specific category of hockey</param>
    /// <returns>Array of soccer championships</returns>
    /// <exception cref="ArgumentException"></exception>
    private static string[] GetHockeyChampionships(string categoryName)
    {
        return categoryName switch
        {
            "Russia" => HockeyRussiaChampionships,
            "USA" => HockeyUSAChampionships,
            "Finland" => HockeyFinlandChampionships,
            _ => throw new ArgumentException($"{categoryName} doesn't exist in DataSet", nameof(categoryName)),
        };
    }
    /// <summary xml:lang = "en">
    /// Get tennis championships
    /// </summary>
    /// <param name="categoryName">Specific category of tennis</param>
    /// <returns>Array of tennis championships</returns>
    /// <exception cref="ArgumentException"></exception>
    private static string[] GetTennisChampionships(string categoryName)
    {
        return categoryName switch
        {
            "ATP" => TennisATPChampionships,
            "WTA" => TennisWTAChampionships,
            _ => throw new ArgumentException($"{categoryName} doesn't exist in DataSet", nameof(categoryName)),
        };
    }
    /// <summary xml:lang = "en">
    /// Get cybersport championships
    /// </summary>
    /// <param name="categoryName">Speific category of cybersport</param>
    /// <returns>Array of cybersport championships</returns>
    /// <exception cref="ArgumentException"></exception>
    private static string[] GetCybersportChampionships(string categoryName)
    {
        return categoryName switch
        {
            "Dota 2" => CybersportDotaChampionships,
            "Counter-Strike" => CybersportCSChampionships,
            "League of Legend" => CybersportLOLChampionships,
            _ => throw new ArgumentException($"{categoryName} doesn't exist in DataSet", nameof(categoryName)),
        };
    }
    #endregion
}
