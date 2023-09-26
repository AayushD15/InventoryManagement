using InventoryManagement.Data.Master;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Handler.Query.Master
{
    public class UpdateStockCommand : IRequest<UpdateStock>
    {
        public UpdateStock Record { get; set; }
    }
}
