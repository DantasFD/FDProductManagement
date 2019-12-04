using FDProductManagement.Domain.Core.Commands;
using FDProductManagement.Domain.Core.Contracts;
using FDProductManagement.Infra.Data.Context;

namespace FDProductManagement.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private FDProductManagementContext _context;

        public UnitOfWork(FDProductManagementContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAfftected = _context.SaveChanges();
            return new CommandResponse(rowsAfftected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
