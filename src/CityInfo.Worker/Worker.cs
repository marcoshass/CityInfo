using CityInfo.Core.Aggregates;
using CityInfo.Core.SharedKernel.Repositories;
using CityInfo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IServiceProvider Services { get; }

        public Worker(ILogger<Worker> logger,
            IServiceProvider services)
        {
            _logger = logger;
            Services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                using (var scope = Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var customersInOutbox = await dbContext.Outboxes
                        .Where(x => x.aggregate_type == "Customer")
                        .ToListAsync();
                    foreach (var customer in customersInOutbox)
                    {
                        _logger.LogInformation($"Message to send => Customer: {customer.payload}");
                    }
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}