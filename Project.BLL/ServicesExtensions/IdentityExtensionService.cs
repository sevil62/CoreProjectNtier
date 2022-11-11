using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServicesExtensions
{
    //Identity kullanıyorsanız (hazır Identity (User,Role,Authorize) sınıflarının şifremi unuttum işlemlerinin login register gibi bütün işlemlerin hazır olduğu kütüphane)
    public static class IdentityExtensionService
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(x => { x.Password.RequireDigit = false; x.Password.RequireLowercase = false; x.Password.RequireNonAlphanumeric = false; x.Password.RequiredLength = 5; }).AddEntityFrameworkStores<MyContext>();
            return services;
        }
    }
}
