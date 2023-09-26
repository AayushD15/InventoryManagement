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
        [HttpPost("UpdateStock")]
        public async Task<ActionResult<UpdateStock>> UpdateStock([FromBody] UpdateStock record)
        {
            var command = new UpdateStockCommand()
            {
                Record = record
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int Id)
        {
            var result = await _mediator.Send(new DeleteItemById
            {
                Id = Id,
            });

            return Ok(result);

        }
        [Route("/api/item/")]
        [HttpPut]
        public async Task<IActionResult> UpdateItems([FromBody] Items record)
        {
            var result = await _mediator.Send(new UpdateItemCommand() { Items = record });
            return Ok(result);
        }


    }
}
