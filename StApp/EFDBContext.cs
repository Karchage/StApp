using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StApp.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StApp
{
    public class EFDBContext : DbContext
    {
        public DbSet<Directory> Directory { get; set; }
        public DbSet<Material> Materials { get; set; }
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options){ }
    }
    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Persist Security Info=false; User ID='sa';Password='sa';Database=StApp;Trusted_Connection=False;MultipleActiveResultSets=true");

            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
