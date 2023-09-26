using BackendData.Domain.Commons;
using InventoryManagement.Data.Master;
using InventoryManagement.Data.Sql;
using InventoryManagement.Data.Sql.DbEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Data.Repository.Master
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private InventoryManagementDbContext dbContext;
        public InvoiceRepository(InventoryManagementDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<Invoice> AddAsync(Invoice entity)
        {
            try
            {
                dbContext.Database.OpenConnection();
                var dbItem = new InvoiceDb();
                ConverToDb(entity, dbItem);
                dbContext.Invoice.Add(dbItem);
                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    try
                    {
                        dbContext.Database.CloseConnection();
                    }
                    catch { }
                }
                return ConvertFromDb(dbItem);

            }catch(Exception e)
            {
                throw e;
            }
        }

        private Invoice ConvertFromDb(InvoiceDb dbItem)
        {
            if (dbItem == null) return new Invoice();
            var invoice = new Invoice();
            invoice.Id = dbItem.Id;
            invoice.SubTotal = dbItem.SubTotal;
            invoice.Taxes = dbItem.Taxes;
            invoice.Total = dbItem.Total;
            invoice.Discount = dbItem.Discount;
            invoice.Items = ConvertItemsFromDb(dbItem.Items);
            invoice.IsDeleted = dbItem.IsDeleted;

            return invoice;

        }

        private void ConverToDb(Invoice entity, InvoiceDb dbItem)
        {
            if (entity == null) return;
            dbItem.SubTotal = CalculateSubTotal(entity.Items);
            dbItem.Taxes = CalculateTax(dbItem.SubTotal);
            dbItem.Discount = entity.Discount;
            dbItem.Total = dbItem.SubTotal + dbItem.Taxes - dbItem.Discount;
            dbItem.Items = ConvertItemsToDb(entity, entity.Items);
            dbItem.IsDeleted = entity.IsDeleted;
        }

        private decimal? CalculateTax(decimal subTotal)
        {
            decimal tax = 0;
            if(subTotal > 0)
            {
                tax += subTotal * 4 / 100;
            }
            return tax;
        }

        private decimal CalculateSubTotal(List<InvoiceItem> items)
        {
            decimal total = 0;
            items.ForEach(item =>
            {
                var dbItem = dbContext.Items.FirstOrDefault(it => it.Id == item.ItemId);
                if (dbItem == null)
                {
                    total = 0;
                }
                else
                {
                    total += (decimal)(dbItem.ItemPrice * item.Quantity);
                }
            });
            return total;
        }

        private ICollection<InvoiceItemDb> ConvertItemsToDb(Invoice entity, List<InvoiceItem> items)
        {
            var list = new List<InvoiceItemDb>();
            items.ForEach(async item =>
            {
                var dbItem = dbContext.Items.FirstOrDefault(it => it.Id == item.ItemId);
                if(dbItem.ItemStock > item.Quantity)
                {
                    var db = new InvoiceItemDb()
                    {
                        ItemId = item.ItemId,
                        Quantity = item.Quantity
                    };
                    dbItem.ItemStock = (dbItem.ItemStock - item.Quantity);
                    dbContext.Items.Update(dbItem);
                    try
                    {
                        await dbContext.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        try { dbContext.Database.CloseConnection(); } catch { }
                    }

                    list.Add(db);
                }
            });
            return list;
        }
        private List<InvoiceItem> ConvertItemsFromDb(ICollection<InvoiceItemDb> items)
        {
            var list = new List<InvoiceItem>();
            
            foreach (var item in items)
            {
                var invoiceItem = new InvoiceItem();
                invoiceItem.Id = item.Id;
                invoiceItem.InvoiceId = item.InvoiceId; 
                invoiceItem.ItemId = item.ItemId;
                invoiceItem.Quantity = item.Quantity;

                list.Add(invoiceItem);
            }

            return list;
        }

        public async Task<Invoice> DeleteAsync(Invoice entity)
        {

            var dbItem = dbContext.Invoice.FirstOrDefault(it => it.Id == entity.Id);
            if (dbItem == null) return entity;
            dbItem.IsDeleted = true;
            dbContext.Invoice.Update(dbItem);
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    dbContext.Database.CloseConnection();
                }
                catch { }
            }
            return entity;
        }

        public IQueryable<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public Invoice GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ListQueryResult<Invoice>> GetByQuery(ListQuery<Invoice> query)
        {
            throw new NotImplementedException();
        }

        public async Task<Invoice> UpdateInvoiceAsync(Invoice entity)
        {
            var dbItem = dbContext.Invoice.Include(it => it.Items).FirstOrDefault(it => it.Id == entity.Id);
            dbItem.Items.Clear();
            if (dbItem == null) return entity;
            ConverToDb(entity, dbItem);
            dbContext.Invoice.Update(dbItem);
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    dbContext.Database.CloseConnection();
                }
                catch { }
            }
            return ConvertFromDb(dbItem);
        }
    }
}
