using Microsoft.Extensions.Logging;

namespace Example.Application.Common
{
    public abstract class BaseService<T>
    {
        public readonly ILogger<T> _logger;

        public BaseService(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void RegisterLog(string status, string method)
        {
            _logger.LogInformation($"{ string.Empty.PadLeft(10,'#') } { DateTimeOffset.Now } {status} : { method } { string.Empty.PadRight(10,'#') }");
        }
    }
}
