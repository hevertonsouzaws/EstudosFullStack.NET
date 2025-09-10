using DashboardWS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DashboardWS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
