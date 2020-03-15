using StoreBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBook.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
