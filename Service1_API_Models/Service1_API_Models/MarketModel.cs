namespace Service1_API_Models;

/// <summary xml:lang = "en">
/// Market entity
/// </summary>
public sealed class MarketModel
{
    public MarketModel(string marketName, List<OutcomeModel> outcomes)
    {
        MarketName = marketName ?? throw new ArgumentException(null, nameof(marketName));;
        Outcomes = outcomes ?? throw new ArgumentException(null, nameof(outcomes));
    }
    /// <summary xml:lang = "en">
    /// Market name
    /// </summary>
    public string? MarketName { get; set; }

    /// <summary xml:lang = "en">
    /// List of outcomes
    /// </summary>
    public IEnumerable<OutcomeModel>? Outcomes { get; set; }
}
