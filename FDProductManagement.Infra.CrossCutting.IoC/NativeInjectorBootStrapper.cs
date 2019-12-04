using AutoMapper;
using FDProductManagement.Domain.Contracts;
using FDProductManagement.Domain.Core.Contracts;
using FDProductManagement.Infra.Data.Context;
using FDProductManagement.Infra.Data.Repositories;
using FDProductManagement.Infra.Data.UoW;
using FDProductManagement.Service.Contracts;
using FDProductManagement.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FDProductManagement.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {


            //Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();

            //Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<FDProductManagementContext>();


        }
    }
}
