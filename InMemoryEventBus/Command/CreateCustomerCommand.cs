using MediatR;

namespace InMemoryEventBus.Command
{
    public record CreateCustomerCommand(string name , string lastName) : IRequest<Guid>;
}
