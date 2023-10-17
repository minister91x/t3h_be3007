using DataAcess.Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.DBContext
{
    public class MyShopUnitOfWorkDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MyShopUnitOfWorkDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder) { base.OnModelCreating(builder); }
        public DbSet<Product>? sanpham { get; set; }
        public DbSet<Account>? user { get; set; }
        public DbSet<Function> function { get; set; }
        public DbSet<UserFuntion> userfunction { get; set; }
    }
}
