using FDProductManagement.Domain.Core.Contracts;
using FDProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FDProductManagement.Domain.Contracts
{
    public interface IBrandRepository : IRepository<Brand>
    {
        IEnumerable<Brand> Find(Expression<Func<Brand, bool>> predicate);
    }
}
