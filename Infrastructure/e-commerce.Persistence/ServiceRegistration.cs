using e_commerce.Application.Repositories;
using e_commerce.Persistence.Context;
using e_commerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<dbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<IProductReadDal, EfProductReadDal>();
            services.AddScoped<IProductWriteDal, EfProductWriteDal>();
                     
            services.AddScoped<ICustomerReadDal, EfCustomerReadDal>();
            services.AddScoped<ICustomerWriteDal, EfCustomerWriteDal>();
                     
            services.AddScoped<IOrderReadDal, EfOrderReadDal>();
            services.AddScoped<IOrderWriteDal, EfOrderWriteDal>();
        }
    }
}
