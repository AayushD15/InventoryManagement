using BackendData.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();
        Task<ListQueryResult<TEntity>> GetByQuery(ListQuery<TEntity> query);
        TEntity GetById(int id);
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);

    }
}
