using InventoryManagement.Data.Master;
using InventoryManagement.Handler.Query.Master;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers.Operations
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : BaseAPIController
    {

        private readonly IMediator _mediator;
        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> AddInvoice([FromBody] Invoice record)
        {
            try
            {
                var command = new AddInvoiceCommand()
                {
                    Invoice = record
                };
                var result = await _mediator.Send(command);
                return Ok(result);

            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int Id)
        {
            var result = await _mediator.Send(new DeleteInvoiceById
            {
                Id = Id,
            });
            return Ok(result);
        }
        [Route("/api/invoice/")]
        [HttpPut]
        public async Task<IActionResult> UpdateItems([FromBody] Invoice record)
        {
            var result = await _mediator.Send(new UpdateInvoiceCommand() { Item = record });
            return Ok(result);
        }
    }
}
