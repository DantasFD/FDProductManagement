using FDProductManagement.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FDProductManagement.Domain.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
