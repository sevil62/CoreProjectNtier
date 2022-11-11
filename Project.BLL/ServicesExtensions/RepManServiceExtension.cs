using Microsoft.Extensions.DependencyInjection;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
using Project.DAL.Repository.Abstracts;
using Project.DAL.Repository.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServicesExtensions
{
    //Bu servis ayarlaması DI Autofac kütüphanesi olmadan yazılmasını sağlamak içindir.
    public static class RepManServiceExtension
    {
        public static IServiceCollection AddRepAndManServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductManager,ProductManager>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<ICategoryManager,CategoryManager>();


            


            return services;
        }
    }
}
