using AutoMapper;
using FDProductManagement.Domain.Contracts;
using FDProductManagement.Domain.Core.Commands;
using FDProductManagement.Domain.Core.Contracts;
using FDProductManagement.Domain.Entities;
using FDProductManagement.Service.Contracts;
using FDProductManagement.Service.ViewModels;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FDProductManagement.Service.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _ProductRepository;
        private readonly IBrandService _brandService;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IMapper mapper, IProductRepository ProductRepository, IBrandService brandService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _ProductRepository = ProductRepository;
            _brandService = brandService;
            _unitOfWork = unitOfWork;
        }

        public Tuple<ProductViewModel, IReadOnlyCollection<Notification>> Add(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);
            if (entity.Valid)
            {
                var brand = _brandService.GetById(entity.BrandId);
                if (brand != null)
                {
                    _ProductRepository.Add(entity);
                    CommandResponse commandResponse = _unitOfWork.Commit();
                    if (!commandResponse.Success)
                    {
                        entity.AddNotification("", "Erro ao salvar");
                    }
                }
                else
                    entity.AddNotification("Brand", "Marca nao cadastrada");
            }

            AddNotifications(entity.Notifications);

            return new Tuple<ProductViewModel, IReadOnlyCollection<Notification>>(_mapper.Map<ProductViewModel>(entity), entity.Notifications);
        }

        public Tuple<ProductViewModel, IReadOnlyCollection<Notification>> Update(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);
            if (entity.Valid)
            {
                var brand = _brandService.GetById(entity.BrandId);
                if (brand != null)
                {
                    Product entityDb = _ProductRepository.GetById(entity.Id);
                    if (entityDb != null)
                        _ProductRepository.Update(entity);

                    CommandResponse commandResponse = _unitOfWork.Commit();
                    if (!commandResponse.Success)
                    {
                        entity.AddNotification("", "Erro ao salvar");
                    }
                }
                else
                    entity.AddNotification("Brand", "Marca nao cadastrada");
            }

            AddNotifications(entity.Notifications);
            return new Tuple<ProductViewModel, IReadOnlyCollection<Notification>>(_mapper.Map<ProductViewModel>(entity), entity.Notifications);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_ProductRepository.GetAll());
        }

        public IEnumerable<ProductViewModel> GetAllByIdBrand(Guid id)
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_ProductRepository.GetAllByIdBrand(id));
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_ProductRepository.GetById(id));
        }

        public IReadOnlyCollection<Notification> Remove(Guid id)
        {
            _ProductRepository.Remove(id);
            CommandResponse commandResponse = _unitOfWork.Commit();
            if (!commandResponse.Success)
            {
                AddNotification(new Notification("", "Erro ao excluir"));
            }

            return GetNotifications();
        }

        public void Dispose()
        {
            _ProductRepository.Dispose();
        }
    }
}
