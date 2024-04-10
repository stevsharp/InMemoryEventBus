using InMemoryEventBus.Command;
using InMemoryEventBus.MessageQueue;
using InMemoryEventBus.Model;
using InMemoryEventBus.Notification;

using MediatR;

namespace InMemoryEventBus.Handler;

    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand,Guid>
    {
        protected readonly IEventDispatcher _eventDispatcher;

        public CreateCustomerHandler(IEventDispatcher eventDispatcher)
        {
            _eventDispatcher = eventDispatcher;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.name, request.lastName);
            
            await _eventDispatcher.Publish(new CustomerCreatedNotification(customer.Id), cancellationToken);

            return customer.Id;
        }
    }

