using FDProductManagement.Service.ViewModels;
using Flunt.Notifications;
using System;
using System.Collections.Generic;

namespace FDProductManagement.Service.Contracts
{
    public interface IProductService : IDisposable
    {
        Tuple<ProductViewModel, IReadOnlyCollection<Notification>> Add(ProductViewModel viewModel);
        Tuple<ProductViewModel, IReadOnlyCollection<Notification>> Update(ProductViewModel viewModel);
        IEnumerable<ProductViewModel> GetAll();
        IEnumerable<ProductViewModel> GetAllByIdBrand(Guid id);
        ProductViewModel GetById(Guid id);
        IReadOnlyCollection<Notification> Remove(Guid id);
        IReadOnlyCollection<Notification> GetNotifications();
    }
}
