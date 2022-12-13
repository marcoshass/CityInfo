namespace FrontDesk.Api
{
    public class ClinicManagementRabbitMqService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
