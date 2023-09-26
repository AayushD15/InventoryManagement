using InventoryManagement.Data.Master;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Data.Repository.Master
{
    public interface IItemRepository : IRepository<Items>
    {

        Task<UpdateStock> UpdateStockAsync(UpdateStock entity);
        Task<Items> UpdateItemsAysnc(Items entity);
    }
}
