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
    public class DeleteItemByIdHandler : IRequestHandler<DeleteItemById, Items>
    {
        private readonly IItemRepository repository;
        public DeleteItemByIdHandler(IItemRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Items> Handle(DeleteItemById request, CancellationToken cancellationToken)
        {
            return await repository.DeleteAsync(new Items()
            {
                Id = request.Id,
            });
        }
    }
}
