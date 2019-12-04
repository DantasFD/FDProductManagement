using FDProductManagement.Domain.Contracts;
using FDProductManagement.Domain.Entities;
using FDProductManagement.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FDProductManagement.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(FDProductManagementContext context) : base(context)
        {
        }
        public IEnumerable<Product> GetAllByIdBrand(Guid id)
        {
            return DbSet.AsNoTracking().Where(x => x.BrandId == id).ToList();
        }
    }
}
