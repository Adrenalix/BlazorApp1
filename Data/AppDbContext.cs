using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorApp1.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"DataSource = AppDb.db");
        }
    }
}
