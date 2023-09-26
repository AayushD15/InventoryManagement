using InventoryManagement.Data.Master;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Handler.Query.Master
{
    public class AddInvoiceCommand : IRequest<Invoice>
    {
        public Invoice Invoice { get; set; }
    }
}
