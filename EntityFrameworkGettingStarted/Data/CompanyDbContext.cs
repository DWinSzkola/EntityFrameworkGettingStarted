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
                entity.HasOne(d => d.Location).WithMany(l => l.Employess).HasForeignKey(d => d.LocationID);
            });
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey((e) => e.DeptID);
                entity.ToTable("DEPT");
                entity.HasOne(d => d.Manager).WithMany(e => e.ManagerDepts).HasForeignKey(d => d.ManagerID);
            });
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey((e) => e.LocationID);
                entity.ToTable("LOCATION");
            });
            
        }

        public virtual DbSet<Employee> EMP { get; set; }
        public virtual DbSet<Department> DEPT { get; set; }
        public virtual DbSet<Location> LOCATION { get; set; }

    }
}
