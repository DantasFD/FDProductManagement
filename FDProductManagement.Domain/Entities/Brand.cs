using FDProductManagement.Domain.Core.Entities;
using Flunt.Validations;
using System.Collections.Generic;

namespace FDProductManagement.Domain.Entities
{
    public class Brand : Entity<Brand>
    {
        public Brand(string name)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(name, "Name", "Brand name is required")
                .HasMinLen(name, 3, "Name", "Brand name must have at least 3 characters")
                .HasMaxLen(name, 100, "Name", "Brand name must have at maximum 100 characters")
            );

            Name = name;
        }

        //EF Construtor
        protected Brand() { }

        public string Name { get; private set; }

        //Prop navegação EF
        public ICollection<Product> Products { get; set; }
    }
}
