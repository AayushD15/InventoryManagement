using System;
using BackendData.Domain.Commons;
using InventoryManagement.Data.Master;
using InventoryManagement.Data.Sql;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Data.Sql.DbEntity;

namespace InventoryManagement.Data.Repository.Master
{
    public class ItemRepository : IItemRepository
    {
        private readonly InventoryManagementDbContext _dbContext;
        public ItemRepository(InventoryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Items> AddAsync(Items entity)
        {
            _dbContext.Database.OpenConnection();
            var dbItem = new ItemsDb();
            ConverToDb(entity, dbItem);
            _dbContext.Items.Add(dbItem);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    _dbContext.Database.CloseConnection();
                }
                catch { }
            }
            return ConvertFromDb(dbItem);
        }

        private Items ConvertFromDb(ItemsDb dbItem)
        {
            if (dbItem == null) { return new Items(); }
            var result = new Items()
            {
                Id = dbItem.Id
            };
            result.ItemName = dbItem.ItemName;
            result.ItemStock = dbItem.ItemStock;
            result.ItemPrice = dbItem.ItemPrice;
            result.IsDeleted = dbItem.IsDeleted;
            return result;
        }

        private void ConverToDb(Items record, ItemsDb dbItem)
        {
            if (record == null) return;
            dbItem.ItemName = record.ItemName;
            dbItem.ItemPrice = record.ItemPrice;
            dbItem.ItemStock = record.ItemStock;
            dbItem.IsDeleted = record.IsDeleted;
        }

        public async Task<Items> DeleteAsync(Items entity)
        {
            var dbItem = _dbContext.Items.FirstOrDefault(it => it.Id == entity.Id);
            if (dbItem == null) return entity;
            dbItem.IsDeleted = true;
            _dbContext.Items.Update(dbItem);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    _dbContext.Database.CloseConnection();
                }
                catch { }
            }
            return entity;
        }

        public IQueryable<Items> GetAll()
        {
            throw new NotImplementedException();
        }

        public Items GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ListQueryResult<Items>> GetByQuery(ListQuery<Items> query)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateStock> UpdateStockAsync(UpdateStock entity)
        {

            var dbItem = _dbContext.Items.FirstOrDefault(it => it.Id == entity.ItemId);
            if (dbItem == null) return entity;
            dbItem.ItemStock += entity.ItemStock;
            _dbContext.Items.Update(dbItem);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    _dbContext.Database.CloseConnection();
                }
                catch { }
            }
            return entity;


        }

        public async Task<Items> UpdateItemsAysnc(Items entity)
        {
            var dbItem = _dbContext.Items.FirstOrDefault(it => it.Id == entity.Id);
            if (dbItem == null) return entity;
            dbItem.ItemName = entity.ItemName;
            dbItem.ItemPrice = entity.ItemPrice;
            dbItem.ItemStock = entity.ItemStock;
            dbItem.IsDeleted = entity.IsDeleted;
            _dbContext.Items.Update(dbItem);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    _dbContext.Database.CloseConnection();
                }
                catch { }
            }
            return entity;
        }
    }
}
