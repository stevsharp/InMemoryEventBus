using MediatR;

namespace InMemoryEventBus.MessageQueue;

    public interface IEventDispatcher
    {
        Task Publish<T>(T @event, CancellationToken token = default) where T : INotification;
    }

