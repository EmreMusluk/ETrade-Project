using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ETrade.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ETrade.Dal
{
    public class ETradeContext :DbContext
    {
        public ETradeContext(DbContextOptions<ETradeContext> db): base(db)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketDetail>()
                .HasKey(basket => new { basket.Id, basket.ProductId });
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vat> Vats { get; set; }
        public DbSet<BasketDetail> BasketDetail { get; set; }
        public DbSet<BasketMaster> BasketMasters { get; set; }
    }
}
