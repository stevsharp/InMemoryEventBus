using InMemoryEventBus.Notification;

using MediatR;

namespace InMemoryEventBus.Handler
{
    public class CustomerCreatedNotificationHandler : INotificationHandler<CustomerCreatedNotification>
    {
        public async Task Handle(CustomerCreatedNotification notification, CancellationToken cancellationToken)
        {
            // Simulate some externall Call

            await Task.Delay(1000);
        }
    }
}
