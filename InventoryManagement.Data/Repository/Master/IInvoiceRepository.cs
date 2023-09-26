using InventoryManagement.Data.Master;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Data.Repository.Master
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {

        Task<Invoice> UpdateInvoiceAsync(Invoice entity);
    }
}
