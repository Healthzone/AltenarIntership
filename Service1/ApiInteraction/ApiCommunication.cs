using Flurl;
using Flurl.Http;

using Microsoft.Extensions.Options;

using Service1.Options;

namespace Service1.ApiInteraction;

/// <summary xml:lang = "en">
/// Implementation communication between Service1 and Minimal API via FlurlHttp
/// </summary>
sealed internal class ApiCommunication
{
    private readonly ApiConnectionOptions _apiConnectionOptions;

    public ApiCommunication(IOptions<ApiConnectionOptions> options)
    {
        _apiConnectionOptions = options.Value;
    }

    /// <summary xml:lang = "en">
    /// Send POST HTTP request to API
    /// </summary>
    /// <param name="apiEndpoint">API endpoint</param>
    /// <param name="data">Object which will be serialized as JSON</param>
    /// <returns>Response object</returns>
    public async Task<IFlurlResponse> SendObjectPostToApiAsync(string apiEndpoint, object data)
    {
        if (string.IsNullOrWhiteSpace(apiEndpoint))
        {
            throw new ArgumentException("ApiEndpoint is null or empty", nameof(apiEndpoint));
        }
        if( data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }
        try
        {
            return await _apiConnectionOptions.MinimalApiStr
                .AppendPathSegment(apiEndpoint)
                .PostJsonAsync(data);
        }
        catch
        {
            throw;
        }
    }
}
