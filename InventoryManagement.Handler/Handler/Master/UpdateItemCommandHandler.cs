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
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Items>
    {

        private readonly IItemRepository itemRepository;
        public UpdateItemCommandHandler(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task<Items> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            return await itemRepository.UpdateItemsAysnc(request.Items);
        }
    }
}
