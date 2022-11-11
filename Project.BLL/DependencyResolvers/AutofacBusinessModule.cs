using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concretes;
using Project.DAL.Context;
using Project.DAL.DALModel;
using Project.DAL.Repository.Abstracts;
using Project.DAL.Repository.Concretes;


namespace Project.BLL.DependencyResolvers
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
            builder.RegisterGeneric(typeof(BaseManager<>)).As(typeof(IManager<>));
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductManager>().As<IProductManager>();
            builder.RegisterType<CategoryManager>().As<ICategoryManager>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<UserManagerSpecial>().As<IUserManagerSpecial>();
            builder.RegisterType<LoginManager>().As<ILoginManager>();

            IServiceCollection ni = new ServiceCollection();
            ni.AddIdentity<AppUser, IdentityRole>(x => { x.Password.RequireDigit = false; x.Password.RequireLowercase = false; x.Password.RequireNonAlphanumeric = false; x.Password.RequiredLength = 5; }).AddEntityFrameworkStores<MyContext>();
            //Bu nokta da kesinlikle builder Populate metodu ile Identity eklenmiş olan ServiceCollection nesnesini almak zorundadır.Yoksa Identity tablolarınızı açsa bile onun işlemlerini kullanamazsınız.Yani DI Identiy için çalışmaz .Sadece tablolar açılmış olur.

            builder.Populate(ni);
            builder.Register(c =>
            {
                IConfiguration config = c.Resolve<IConfiguration>();
                DbContextOptionsBuilder<MyContext> opt = new DbContextOptionsBuilder<MyContext>();
                opt.UseSqlServer(config.GetSection("ConnectionStrings:MyConnection").Value).UseLazyLoadingProxies();
                return new MyContext(opt.Options)
                ;
            }).AsSelf().InstancePerLifetimeScope();


        }
    }
}
