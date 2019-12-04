using FDProductManagement.Service.Contracts;
using FDProductManagement.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FDProductManagement.API.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;

        public BrandController(IProductService productService, IBrandService brandService)
        {
            _productService = productService;
            _brandService = brandService;
        }


        [HttpGet]
        [Route("brand")]
        public IEnumerable<BrandViewModel> Get()
        {
            return _brandService.GetAll();
        }

        [HttpGet]
        [Route("brand/{id:guid}/Product")]
        public IEnumerable<ProductViewModel> GetByIdBrand(Guid id)
        {
            return _productService.GetAllByIdBrand(id);
        }

        [HttpGet]
        [Route("brand/{id:guid}")]
        public BrandViewModel GetById(Guid id)
        {
            return _brandService.GetById(id);
        }

        [HttpPost]
        [Route("brand")]
        public IActionResult Post([FromBody] BrandViewModel brandViewModel)
        {
            var result = _brandService.Add(brandViewModel);
            SetNotifications(result.Item2);
            return Response(result.Item1);
        }

        [HttpPut]
        [Route("brand")]
        public IActionResult Put([FromBody] BrandViewModel brandViewModel)
        {
            var result = _brandService.Update(brandViewModel);
            SetNotifications(result.Item2);
            return Response(result.Item1);
        }

        [HttpDelete]
        [Route("brand/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var result = _brandService.Remove(id);
            SetNotifications(result);
            return Response();
        }
    }
}
