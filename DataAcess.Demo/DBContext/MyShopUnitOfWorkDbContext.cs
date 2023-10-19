using DataAcess.Demo.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.DBContext
{
    public class MyShopUnitOfWorkDbContext : IdentityDbContext<IdentityUser>
    {
        public MyShopUnitOfWorkDbContext(DbContextOptions<MyShopUnitOfWorkDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder) { base.OnModelCreating(builder); }
        public DbSet<Product>? sanpham { get; set; }
        public DbSet<Account>? user { get; set; }
        public DbSet<Function> function { get; set; }
        public DbSet<UserFuntion> userfunction { get; set; }
    }
}
