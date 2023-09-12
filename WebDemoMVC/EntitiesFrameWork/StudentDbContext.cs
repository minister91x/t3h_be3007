using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebDemoMVC.EntitiesFrameWork.Entites;
using WebDemoMVC.Migrations;

namespace WebDemoMVC.EntitiesFrameWork
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("ManagerProduct")
        {
          // Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentDbContext, Configuration>());
        }

        //public DbSet<Student> student { get; set; }
        public DbSet<Grade> grade { get; set; }
        public DbSet<Category> categorie { get; set; }
    }
}