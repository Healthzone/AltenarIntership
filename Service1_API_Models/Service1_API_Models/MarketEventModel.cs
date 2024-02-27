namespace Service1_API_Models;

/// <summary xml:lang = "en">
/// Root Market model
/// </summary>
public sealed class MarketEventModel
{
    public MarketEventModel(string eventName)
    {
        EventName = eventName ?? throw new ArgumentException(null, nameof(eventName));
        Markets = new List<MarketModel>();
    }
    /// <summary xml:lang = "en">
    /// Event name
    /// </summary>
    public string? EventName { get; set; }

    /// <summary xml:lang = "en">
    /// List of markets
    /// </summary>
    public IEnumerable<MarketModel>? Markets { get; set; }
}
