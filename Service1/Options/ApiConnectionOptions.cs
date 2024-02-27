namespace Service1.Options;
sealed internal class ApiConnectionOptions
{
    public const string CONNECTION_STRING = "ConnectionStrings";

    public string MinimalApiStr { get; set; } = string.Empty;
}
