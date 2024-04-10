
using InMemoryEventBus.MessageQueue;

using MediatR;

namespace InMemoryEventBus.HostedService
{
    public class ApplicationBackgroundService : BackgroundService
    {
        private readonly ILogger<ApplicationBackgroundService> _logger;

        private readonly InMemoryMessageQueue _inMemoryMessageQueue;

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ApplicationBackgroundService
            (ILogger<ApplicationBackgroundService> logger,
            InMemoryMessageQueue inMemoryMessageQueue,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;

            _inMemoryMessageQueue = inMemoryMessageQueue;

            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach(INotification notification in _inMemoryMessageQueue.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    using IServiceScope scope = _serviceScopeFactory.CreateScope();

                    IPublisher publisher  = scope.ServiceProvider.GetRequiredService<IPublisher>();

                    if (publisher is not null)
                    {
                        await publisher.Publish(notification,stoppingToken);
                    }

                }
                catch (Exception ex)
                {

                    _logger.LogError(ex, "_inMemoryMessageQueue");
                }
            }
        }
    }
}
