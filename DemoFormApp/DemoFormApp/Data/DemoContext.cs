using DemoFormApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFormApp.Data
{
    class DemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:mes-db-server.database.windows.net,1433;Initial Catalog=jiangjunlong;Persist Security Info=False;User ID=mesadmin;Password=Pass123$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<Department> Departments { get; set; }
    }
}
