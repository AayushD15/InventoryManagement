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
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, Items>
    {

        private readonly IItemRepository itemRepository;
        public AddItemCommandHandler(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task<Items> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            return await itemRepository.AddAsync(request.Items);
        }
    }
}
