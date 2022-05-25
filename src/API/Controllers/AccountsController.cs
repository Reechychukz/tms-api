using Application.Features.Accounts.Commands.CreateAccount;
using Application.Features.Accounts.Commands.DeleteAccount;
using Application.Features.Accounts.Commands.UpdateAccount;
using Application.Features.Accounts.Queries.GetAccountsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/customers/customer-id/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Endpoint to query the accounts by the customer's id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{fisrtName}", Name = "GetAccounts")]
        [ProducesResponseType(typeof(IEnumerable<AccountsDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AccountsDto>>> GetAccountsByCustomerId(Guid customerId)
        {
            var query = new GetAccountsListQuery(customerId);
            var accounts = await _mediator.Send(query);

            return Ok(accounts);
        }

        /// <summary>
        /// Endpoint to create an Account
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateAccount")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAccount([FromBody] CreateAccountCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Endpoint to Update an Account
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateAccount([FromBody] UpdateAccountCommand command)
        {
            var result = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> DeleteAccount([FromBody] Guid id)
        {
            var command = new DeleteAccountCommand() { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
