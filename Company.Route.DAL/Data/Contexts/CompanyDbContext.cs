using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Company.Route.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Route.DAL.Data.Contexts
{
    internal class CompanyDbContext : DbContext

    {
        public CompanyDbContext() :base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=Company.Route; TrustedConnection=True ; TrustServerCertificate= True; ");
        }

        public DbSet<Department> Departemnts { get; set; }
    }
}
