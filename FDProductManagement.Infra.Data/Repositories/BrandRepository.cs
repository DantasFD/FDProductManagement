using FDProductManagement.Domain.Contracts;
using FDProductManagement.Domain.Entities;
using FDProductManagement.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FDProductManagement.Infra.Data.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(FDProductManagementContext context) : base(context)
        {
        }

        public IEnumerable<Brand> Find(Expression<Func<Brand, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }
    }
}
