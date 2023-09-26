using InventoryManagement.Data.Master;
using InventoryManagement.Handler.Query.Master;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers.Operations
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : BaseAPIController
    {

        private readonly IMediator _mediator;
        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Items>> AddItems([FromBody] Items record)
        {
            var command = new AddItemCommand()
            {
                Items = record
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
