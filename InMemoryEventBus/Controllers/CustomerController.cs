using InMemoryEventBus.Command;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace InMemoryEventBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IMediator  _mediator;

        public CustomerController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand createCustomer , CancellationToken cancellationToken)
        {
            var response = await  _mediator.Send(createCustomer, cancellationToken);

            return Ok(response);
        }

    }
}
