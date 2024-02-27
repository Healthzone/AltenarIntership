using Service1_API_Models;

namespace Service1.Data;
internal interface IMarketData
{
    public MarketEventModel GetData(string eventName);
}
