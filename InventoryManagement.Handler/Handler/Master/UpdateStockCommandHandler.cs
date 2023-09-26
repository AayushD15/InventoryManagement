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
    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, UpdateStock>
    {
        private readonly IItemRepository repository;
        public UpdateStockCommandHandler(IItemRepository repository)
        {
            this.repository = repository;
        }
        public async Task<UpdateStock> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            return await repository.UpdateStockAsync(request.Record);
        }
    }
}
