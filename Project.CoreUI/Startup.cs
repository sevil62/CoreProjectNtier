using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.BLL.ServicesExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.CoreUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //Bunlar manuel extension yaptýðýmýz da kullanacaðýmýz yöntemin içindeki metotlarý tetiklemek içindir.
            // services.AddRepAndManServices();//Extension metodumuz ile servisi kullandýk
            //services.AddDbContextService();Burada da BLL kullanarak DbContext'i kullanabilmek içindir
            //services.AddIdentityService();





            //Normal (N-Layered olmayan normal projelerde)Dependency Injection Core'da þu þekilde kurulur
            //Core'un otomatik olarak hangi Interface'i nasýl algýlayacaðýný belirten bir mimamrisi vardýr .Bu sistem sizin özellikle bir nesne göndermenize gerek yoktur bu otomatik yapýlýr.Ancak hangi Ýnterface'in olacaðýný belirtmelisiniz.
            //services.AddTransient<IProductRepository>().AsProductRepository();
            //Yukarýda demek istediðimiz þey proje bir yerde IProductRepository gördüðünde ona nesne olarak ne göndermeli onu söylemektedir.Dikkat ederseniz burada  instance alma iþlemini bile biz yapmýyoruz.
            //Burada instance alma iþlemi Dependency Injection'ýn Core 'da otomatik olarak entegre edilmesiyle gerçekleþtiriliyor.AddSingleton ilgili nesne için bir Singleton görevi görürken AddTransied bir HttpRequest'i için sadece bir nesne alma görevi görürken AddScoped her class tetiklendiðinde bir nesne yaratan bir Dependency Injectin iþlemi yapar..
            //Eðer katmanlý bir yapý kullanýyorsak bu AddTransied olayýný kendi mimarimize göre þekillendirmek zorundayýz.Bunun iki yöntemi vardýr ya Autofac kütüphanesini kullanarak Injection Extensionyapmak(Yani Injection'ý geniþletmek)veya kendi Extension metodunuzu static sýnýfta yaratarak bu Injection Extension'i manuel yapmak.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Category}/{action=CategoryList}/{id?}");
            });
        }
    }
}
