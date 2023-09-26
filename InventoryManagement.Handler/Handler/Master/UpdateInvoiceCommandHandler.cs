using InventoryManagement.Data.Master;
using InventoryManagement.Data.Repository.Master;
using InventoryManagement.Handler.Query.Master;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagement.Handler.Handler.Master
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, Invoice>
    {
        private readonly IInvoiceRepository invoiceRepository;
        public UpdateInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }
        public async Task<Invoice> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            return await invoiceRepository.UpdateInvoiceAsync(request.Item);
        }
    }
}
