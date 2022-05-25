using Application.Features.Transactions.Commands.DeleteTransaction;
using Application.Features.Transactions.Commands.InitiateTransaction;
using Application.Features.Transactions.Commands.UpdateTransaction;
using Application.Features.Transactions.Queries;
using Application.Features.Transactions.Queries.GetTransactionsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Endpoint to get a list of trasactions by the sender
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        [HttpGet("{sender}", Name = "GetTransaction")]
        [ProducesResponseType(typeof(IEnumerable<TransactionsDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TransactionsDto>>> GetTransactionsBySender(string sender)
        {
            var query = new GetTransactionsListQuery(sender);
            var transactions = await _mediator.Send(query);

            return Ok(transactions);
        }

        /// <summary>
        /// Endpoint to create a tranaction
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateTransaction")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTransaction([FromBody] CreateTransactionCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Endpoint to update a transaction
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateTransaction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateTransaction([FromBody] UpdateTransactionCommand command)
        {
            var result = await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Endpoint to delete a transaction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteTransaction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> DeleteTransaction([FromBody] Guid id)
        {
            var command = new DeleteTransactionCommand() { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
