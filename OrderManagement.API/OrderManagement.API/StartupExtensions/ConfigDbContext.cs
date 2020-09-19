using OrderManagement.DBEntities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Constants;

namespace OrderManagement.API.StartupExtensions
{
    public class ConfigDbContext
    {
        public static void Register(IConfiguration configuration, IServiceCollection services)
        {
            //Add Db Context
            services.AddDbContext<OrderManagementDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(DbConstants.CONNECTION_STRING_NAME)));
        }
    }
}
