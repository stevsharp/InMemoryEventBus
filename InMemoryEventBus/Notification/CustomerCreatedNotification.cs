using MediatR;

namespace InMemoryEventBus.Notification
{
    public class CustomerCreatedNotification : INotification
    {
        public CustomerCreatedNotification(Guid customerId) => CustomerId = customerId;

        public Guid CustomerId { get; }
    }
}
