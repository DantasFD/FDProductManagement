using FDProductManagement.Domain.Core.Contracts;
using FDProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FDProductManagement.Domain.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllByIdBrand(Guid id);
    }
}
