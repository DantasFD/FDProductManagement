using FDProductManagement.Service.Contracts;
using FDProductManagement.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FDProductManagement.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        [Route("Product")]
        public IEnumerable<ProductViewModel> Get()
        {
            return _ProductService.GetAll();
        }

        [HttpGet]
        [Route("Product/{id:guid}")]
        public ProductViewModel GetById(Guid id)
        {
            return _ProductService.GetById(id);
        }

        [HttpPost]
        [Route("Product")]
        public IActionResult Post([FromBody] ProductViewModel ProductViewModel)
        {
            var result = _ProductService.Add(ProductViewModel);
            SetNotifications(result.Item2);
            return Response(result.Item1);
        }

        [HttpPut]
        [Route("Product")]
        public IActionResult Put([FromBody] ProductViewModel ProductViewModel)
        {
            var result = _ProductService.Update(ProductViewModel);
            SetNotifications(result.Item2);
            return Response(result.Item1);
        }

        [HttpDelete]
        [Route("Product/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var result = _ProductService.Remove(id);
            SetNotifications(result);
            return Response();
        }
    }
}
