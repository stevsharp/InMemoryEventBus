using MediatR;

using System.Threading.Channels;

namespace InMemoryEventBus.MessageQueue
{
    public class InMemoryMessageQueue
    {
        private readonly Channel<INotification> _channel;

        public InMemoryMessageQueue()
        {
            UnboundedChannelOptions options = new()
            {
                SingleReader = true,
                SingleWriter = false,
            };

            _channel = Channel.CreateUnbounded<INotification>(options);
        }

        public ChannelReader<INotification> Reader => _channel.Reader;

        public ChannelWriter<INotification> Writer => _channel.Writer;


    }
}
