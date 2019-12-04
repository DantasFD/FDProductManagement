using FDProductManagement.Domain.Core.Settings;
using FDProductManagement.Domain.Entities;
using FDProductManagement.Infra.Data.Mappings;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FDProductManagement.Infra.Data.Context
{
    public class FDProductManagementContext : DbContext
    {
        public FDProductManagementContext(DbContextOptions<FDProductManagementContext> options)
            : base(options) { }
        public FDProductManagementContext() { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new BrandMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SettingsConfiguration.SqlServerConnection);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
