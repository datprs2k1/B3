using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Company.Data
{
    public partial class CompanyEntities : DbContext
    {
        public CompanyEntities()
            : base("name=Company")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasOptional(e => e.Department1)
                .WithMany(e => e.Departments1)
                .HasForeignKey(e => e.parent);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.department_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Salary>()
                .Property(e => e.coefficient)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Salary>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Salary)
                .HasForeignKey(e => e.salary_id)
                .WillCascadeOnDelete(false);
        }
    }
}
