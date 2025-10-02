using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Core.IRpositries;
using Ordering.Infrastructure.AsyncRepositry;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositry;

namespace Ordering.Infrastructure.Extensions
{
    public static class InfraServices
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("OrderingConnectionString"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure())
                );
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositryBase<>));
            services.AddScoped<IOrderRepository, OrderRepositry>();

            return services;
        }
    }

}
