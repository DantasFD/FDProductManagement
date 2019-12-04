using FDProductManagement.Domain.Core.Entities;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FDProductManagement.Domain.Entities
{
    public class Product : Entity<Product>
    {
        public Product(string name, string description, Brand brand)
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(name, "Name", "Product name is required")
               .HasMinLen(name, 3, "Name", "Product name must have at least 3 characters")
               .HasMaxLen(name, 100, "Name", "Product name must have at maximum 100 characters")
               .IsNotNullOrEmpty(description, "Description", "Product description is required")
               .HasMinLen(description, 3, "Description", "Product name must have at least 3 characters")
               .HasMaxLen(description, 500, "Description", "Product name must have at maximum 500 characters")
               .IsNotNull(brand, "Brand", "Product must have a Brand")
               );

            Name = name;
            Description = description;
            Brand = brand;
        }

        //EF Constructor
        protected Product() { }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Guid BrandId { get; private set; }
        public DateTime FabricationDate { get; private set; }
        public DateTime WarrantyExpireDate { get; private set; }

        //Navigation Properties
        public virtual Brand Brand { get; private set; }
    }
}
