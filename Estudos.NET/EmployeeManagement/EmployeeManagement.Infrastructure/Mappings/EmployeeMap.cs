using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Mappings;

public class EmployeeMap : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        // Chave primária
        builder.HasKey(f => f.Id);

        // Propriedade simples
        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(200);

        // Mapeamento do Value Object Email (Owned Entity Type)
        // Mapeia o Value Object para colunas na tabela Employees.
        builder.OwnsOne(f => f.Email, email =>
        {
            email.Property(e => e.Address)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(256);

            // Garantir que o email seja único no SQL Server
            email.HasIndex(e => e.Address).IsUnique();
        });

        // Mapeamento do Value Object ProfilePictureUrl
        builder.OwnsOne(f => f.ProfilePicture, picture =>
        {
            picture.Property(i => i.Url)
                .HasColumnName("ProfilePictureUrl")
                .IsRequired()
                .HasMaxLength(500);
        });

        // Configuração de backing fields ou acesso privado pode ser adicionada aqui
        // se a Entidade Employee tivesse setters privados para que o EF Core pudesse hidratá-la.
    }
}