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
    public class DeleteInvoiceByIdHandler : IRequestHandler<DeleteInvoiceById, Invoice>
    {
        private readonly IInvoiceRepository repository;
        public DeleteInvoiceByIdHandler(IInvoiceRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Invoice> Handle(DeleteInvoiceById request, CancellationToken cancellationToken)
        {
            return await repository.DeleteAsync(new Invoice()
            {
                Id = request.Id,
            });
        }
    }
}
