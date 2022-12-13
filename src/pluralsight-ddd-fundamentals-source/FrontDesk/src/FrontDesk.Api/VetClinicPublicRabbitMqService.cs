namespace FrontDesk.Api
{
    public class VetClinicPublicRabbitMqService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
