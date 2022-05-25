using Application.Features.Customers.Commands.CreateCustomers;
using Application.Features.Customers.Commands.DeleteCustomers;
using Application.Features.Customers.Commands.UpdateCommands;
using Application.Features.Customers.Queries.GetCustomersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Endpoint to query the customers by their first name
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        [HttpGet("{sender}", Name = "GetCustomers")]
        [ProducesResponseType(typeof(IEnumerable<CustomersDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomersDto>>> GetCustomersByFirstName(string firstName)
        {
            var query = new GetCustomersListQuery(firstName);
            var transactions = await _mediator.Send(query);

            return Ok(transactions);
        }

        /// <summary>
        /// Endpoint to create a customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateCustomer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Endpoint to update a customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {
            var result = await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Endpoint to delete a customer by their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> DeleteCustomer([FromBody] Guid id)
        {
            var command = new DeleteCustomerCommand() { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
