using Flurl.Http;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Service1.ApiInteraction;
using Service1.Data;

namespace Service1;
sealed internal class ServiceWorker : BackgroundService
{
    private readonly IEventData _eventData;
    private readonly IMarketData _marketData;
    private readonly ILogger<ServiceWorker> _logger;
    private readonly ApiCommunication _apiCommunication;

    public ServiceWorker(IEventData eventData,
        IMarketData marketData,
        ILogger<ServiceWorker> logger,
        ApiCommunication apiCommunication)
    {
        _eventData = eventData;
        _marketData = marketData;
        _logger = logger;
        _apiCommunication = apiCommunication;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);

                var eventData = _eventData.GetData();
                _logger.LogInformation("Generated event: {Data}", eventData.CategoryName + ", " + eventData.ChampionshipName + ", " + eventData.EventName);

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);

                var marketData = _marketData.GetData(eventData.EventName!);
                _logger.LogInformation("Generated markets for {EventName}",
                    eventData.EventName);

                _logger.LogInformation("Sending Event Data...");
                var eventRequset = await _apiCommunication.SendObjectPostToApiAsync("/api/Auth/check", eventData);
                if(eventRequset.StatusCode == 200)
                {
                    _logger.LogInformation("Event Data successfully sended");
                    _logger.LogInformation("Sending Markets Data for {EventName}...", eventData.EventName);

                    var result = await _apiCommunication.SendObjectPostToApiAsync("/api/Auth/check", marketData);
                    if(result.StatusCode == 200)
                    {
                        _logger.LogInformation("Market Data successfully sended");
                    }
                }
            }
        }
        catch (FlurlHttpException ex)
        {
            _logger.LogError("Critical error after HTTP request: {Message}", ex.Message);
        }
        catch (TaskCanceledException)
        {
            // When the stopping token is canceled, for example, a call made from services.msc,
            // we shouldn't exit with a non-zero exit code. In other words, this is expected...
        }
        catch (Exception ex)
        {
            _logger.LogError("Critical error: {Message}", ex.Message);

            // Terminates this process and returns an exit code to the operating system.
            // This is required to avoid the 'BackgroundServiceExceptionBehavior', which
            // performs one of two scenarios:
            // 1. When set to "Ignore": will do nothing at all, errors cause zombie services.
            // 2. When set to "StopHost": will cleanly stop the host, and log errors.
            //
            // In order for the Windows Service Management system to leverage configured
            // recovery options, we need to terminate the process with a non-zero exit code.
            Environment.Exit(1);
        }
    }
}