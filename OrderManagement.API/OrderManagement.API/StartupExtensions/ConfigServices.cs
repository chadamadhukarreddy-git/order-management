using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Repositories.Contracts;
using OrderManagement.Repositories;
using OrderManagement.BusinessContracts;
using OrderManagement.Services;

namespace OrderManagement.API.StartupExtensions
{
    public class ConfigServices
    {
        public static void Register(IServiceCollection services)
        {
            // Add Automapper
            services.AddAutoMapper(typeof(Startup));

            // Add Services
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IAppCacheService, AppCacheService>();

            //Add Repositories
            services.AddScoped<IOrderUnitOfWork, OrderUnitOfWork>();
            
        }
    }
}
