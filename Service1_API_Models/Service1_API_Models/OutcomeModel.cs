namespace Service1_API_Models;

/// <summary xml:lang = "en">
/// Presents the outcome of market
/// </summary>
public sealed class OutcomeModel
{
    public OutcomeModel(string outcomeName, decimal price)
    {
        OutcomeName = outcomeName ?? throw new ArgumentException(null, nameof(outcomeName));
        Price = price;
    }
    /// <summary xml:lang = "en">
    /// Outcome name field
    /// </summary>
    public string? OutcomeName { get; set; }

    /// <summary xml:lang = "en">
    /// Price of outcome
    /// </summary>
    public decimal Price { get; set; }
}
