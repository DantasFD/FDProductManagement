using FDProductManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FDProductManagement.Infra.Data.Mappings
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");
            builder.HasKey(p => p.Id);
            builder
                .Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder
                .Ignore(p => p.Notifications);
            builder
                .Ignore(p => p.Invalid);
            builder
                .Ignore(p => p.Valid);
        }
    }
}
