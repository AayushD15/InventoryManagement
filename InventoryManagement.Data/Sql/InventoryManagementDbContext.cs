using InventoryManagement.Data.Sql.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InventoryManagement.Data.Sql
{
    public class InventoryManagementDbContext : DbContext
    {
        public class MyLoggerProvider : ILoggerProvider
        {
            public ILogger CreateLogger(string categoryName)
            {
                return new MyLogger();
            }

            public void Dispose()
            { }

            private class MyLogger : ILogger
            {
                public bool IsEnabled(LogLevel logLevel)
                {
                    return true;
                }

                public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
                {
                    try
                    {
                        File.AppendAllText(@"D:\temp\log.txt", formatter(state, exception));
                        Console.WriteLine(formatter(state, exception));
                    }
                    catch (Exception ex)
                    {
                    }
                }

                public IDisposable BeginScope<TState>(TState state)
                {
                    return null;
                }
            }
        }
        private static readonly LoggerFactory loggerFactory = new LoggerFactory(new[]
        {
            new  MyLoggerProvider()
        });
        public InventoryManagementDbContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
        public InventoryManagementDbContext(DbContextOptions<InventoryManagementDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
        public DbSet<ItemsDb> Items { get; set; }
        public DbSet<InvoiceDb> Invoice { get; set; }
        public DbSet<InvoiceItemDb> InvoiceItem { get; set; }
    }
}
