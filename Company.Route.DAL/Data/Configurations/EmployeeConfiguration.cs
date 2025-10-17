using Company.Route.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.DAL.Data.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>

    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Salary).HasColumnType("decimal(12,2)");
            builder.HasOne(E => E.Department).WithMany(D=> D.Employees).HasForeignKey(E  => E.DepartmentId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
