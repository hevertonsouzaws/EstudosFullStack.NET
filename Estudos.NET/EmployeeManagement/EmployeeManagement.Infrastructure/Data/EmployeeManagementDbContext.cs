using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EmployeeManagement.Infrastructure.Data;

public class EmployeeManagementDbContext : DbContext
{
    public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica o mapeamento da Entidade Employee
        modelBuilder.ApplyConfiguration(new EmployeeMap());

        base.OnModelCreating(modelBuilder);
    }
}