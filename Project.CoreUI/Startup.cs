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
            //Bunlar manuel extension yapt���m�z da kullanaca��m�z y�ntemin i�indeki metotlar� tetiklemek i�indir.
            // services.AddRepAndManServices();//Extension metodumuz ile servisi kulland�k
            //services.AddDbContextService();Burada da BLL kullanarak DbContext'i kullanabilmek i�indir
            //services.AddIdentityService();





            //Normal (N-Layered olmayan normal projelerde)Dependency Injection Core'da �u �ekilde kurulur
            //Core'un otomatik olarak hangi Interface'i nas�l alg�layaca��n� belirten bir mimamrisi vard�r .Bu sistem sizin �zellikle bir nesne g�ndermenize gerek yoktur bu otomatik yap�l�r.Ancak hangi �nterface'in olaca��n� belirtmelisiniz.
            //services.AddTransient<IProductRepository>().AsProductRepository();
            //Yukar�da demek istedi�imiz �ey proje bir yerde IProductRepository g�rd���nde ona nesne olarak ne g�ndermeli onu s�ylemektedir.Dikkat ederseniz burada  instance alma i�lemini bile biz yapm�yoruz.
            //Burada instance alma i�lemi Dependency Injection'�n Core 'da otomatik olarak entegre edilmesiyle ger�ekle�tiriliyor.AddSingleton ilgili nesne i�in bir Singleton g�revi g�r�rken AddTransied bir HttpRequest'i i�in sadece bir nesne alma g�revi g�r�rken AddScoped her class tetiklendi�inde bir nesne yaratan bir Dependency Injectin i�lemi yapar..
            //E�er katmanl� bir yap� kullan�yorsak bu AddTransied olay�n� kendi mimarimize g�re �ekillendirmek zorunday�z.Bunun iki y�ntemi vard�r ya Autofac k�t�phanesini kullanarak Injection Extensionyapmak(Yani Injection'� geni�letmek)veya kendi Extension metodunuzu static s�n�fta yaratarak bu Injection Extension'i manuel yapmak.
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
