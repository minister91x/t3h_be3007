using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebDemoMVC.EntitiesFrameWork.Entites;

namespace WebDemoMVC.EntitiesFrameWork
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("ManagerProduct")
        {

        }

        public DbSet<Student> student { get; set; }
    }
}