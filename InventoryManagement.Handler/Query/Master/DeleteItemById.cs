using InventoryManagement.Data.Master;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Handler.Query.Master
{
    public class DeleteItemById : IRequest<Items>
    {
        public int Id { get; set; }
    }
}
