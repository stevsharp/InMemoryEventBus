using MediatR;
using InMemoryEventBus.MessageQueue;

namespace InMemoryEventBus;

    public class EventDispatcher : IEventDispatcher
    {
        protected readonly InMemoryMessageQueue _inMemoryMessageQueue;
        public EventDispatcher(InMemoryMessageQueue inMemoryMessageQueue)
        {
            _inMemoryMessageQueue = inMemoryMessageQueue;
        }
        public async Task Publish<T>(T @event, CancellationToken token = default) where T : INotification
        {
            await _inMemoryMessageQueue.Writer.WriteAsync(@event, token);
        }
    }
