using EntityFrameworkGettingStarted.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkGettingStarted.Data
{
    class CompanyDbContext : DbContext
    {
        private readonly string _connectionString;
        public CompanyDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey((e) => e.EmpID);
                entity.ToTable("EMP");
                entity.HasOne(d => d.Dept).WithMany(d=>d.Emps).HasForeignKey(d=>d.DeptID);
            });
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey((e) => e.DeptID);
                entity.ToTable("DEPT");
                entity.HasOne(d => d.Manager).WithMany(e => e.ManagerDepts).HasForeignKey(d => d.ManagerID);
            });
        }

        public virtual DbSet<Employee> EMP { get; set; }
        public virtual DbSet<Department> DEPT { get; set; }

    }
}
