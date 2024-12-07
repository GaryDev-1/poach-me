using Polly.Extensions.Http;
using Polly;
using Microsoft.Extensions.Logging;

namespace WildlifePoaching.API.Services.Policies
{
    public static class PollyPolicies
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(ILogger logger)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .Or<TimeoutException>()
                .WaitAndRetryAsync(
                    3,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (result, timeSpan, retryCount, context) =>
                    {
                        logger.LogWarning(
                            result.Exception,
                            "Retry {RetryCount} after {Seconds} seconds",
                            retryCount,
                            timeSpan.TotalSeconds);
                    });
        }

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(ILogger logger)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .AdvancedCircuitBreakerAsync(
                    failureThreshold: 0.5,
                    samplingDuration: TimeSpan.FromSeconds(30),
                    minimumThroughput: 10,
                    durationOfBreak: TimeSpan.FromSeconds(30),
                    onBreak: (exception, ts) =>
                    {
                        var seconds = ts.TotalSeconds;
                        logger.LogError(
                            exception.Exception,
                            "Circuit breaker opened for {0} seconds",
                            seconds);
                    },
                    onReset: () =>
                    {
                        logger.LogInformation("Circuit breaker reset");
                    },
                    onHalfOpen: () =>
                    {
                        logger.LogInformation("Circuit breaker is half-open");
                    });
        }

        public static IAsyncPolicy<HttpResponseMessage> GetTimeoutPolicy()
        {
            return Policy.TimeoutAsync<HttpResponseMessage>(10);
        }

        public static IAsyncPolicy<HttpResponseMessage> GetCombinedPolicy(ILogger logger)
        {
            return Policy.WrapAsync(
                GetRetryPolicy(logger),
                GetCircuitBreakerPolicy(logger),
                GetTimeoutPolicy());
        }
    }
}
