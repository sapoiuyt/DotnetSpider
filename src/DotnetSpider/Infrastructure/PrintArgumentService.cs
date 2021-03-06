using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DotnetSpider.Infrastructure
{
    public class PrintArgumentService : IHostedService
    {
        private readonly SpiderOptions _options;
        private readonly ILogger<PrintArgumentService> _logger;

        public PrintArgumentService(IOptions<SpiderOptions> options, ILogger<PrintArgumentService> logger)
        {
            _logger = logger;
            _options = options.Value;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var properties = typeof(SpiderOptions).GetProperties();
            _logger.LogInformation("========================================================================================================");
            foreach (var property in properties)
            {
                _logger.LogInformation($"{property.Name}: {property.GetValue(_options)}");
            }
            _logger.LogInformation("========================================================================================================");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
