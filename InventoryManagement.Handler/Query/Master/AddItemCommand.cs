using InventoryManagement.Data.Master;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Handler.Query.Master
{
    public class AddItemCommand : IRequest<Items>
    {
        public Items Items { get; set; }
    }
}
