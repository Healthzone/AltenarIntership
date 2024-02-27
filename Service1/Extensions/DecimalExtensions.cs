namespace Service1.Extensions;
static internal class DecimalExtensions
{
    /// <summary xml:lang = "en">
    /// Round float value to x fractional digits
    /// </summary>
    /// <param name="fl"></param>
    /// <param name="digits">Number of fractional digits</param>
    /// <returns></returns>
    public static decimal Round(this decimal fl, int digits) => Math.Round(fl, digits, MidpointRounding.AwayFromZero);

}
