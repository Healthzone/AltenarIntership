namespace Service1_API_Models;

/// <summary xml:lang = "en">
/// Root Event model
/// </summary>
public sealed class EventModel
{
    /// <summary xml:lang = "en">
    /// Unique key of Sport entity
    /// </summary>
    public long? SportId { get; set; }

    /// <summary xml:lang = "en">
    /// Sport name
    /// </summary>
    public string? SportName { get; set; }

    /// <summary xml:lang = "en">
    /// Unique key of Category entity
    /// </summary>
    public long? CategoryId { get; set; }

    /// <summary xml:lang = "en">
    /// Category name
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary xml:lang = "en">
    /// Unique key of Championship entity
    /// </summary>
    public long? ChampionshipId { get; set; }

    /// <summary xml:lang = "en">
    /// Championship name
    /// </summary>
    public string? ChampionshipName { get; set; }

    /// <summary xml:lang = "en">
    /// Event name
    /// </summary>
    public string? EventName { get; set; }

    /// <summary xml:lang = "en">
    /// Date and time of the Event
    /// </summary>
    public DateTime? EventDate { get; set; }

    /// <summary xml:lang = "en">
    /// Date and time of the last Event update
    /// </summary>
    public DateTime? LastUpdate { get; set; }
}
