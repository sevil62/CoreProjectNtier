using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DAL.DALModel;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    //Eğer kurmak istediğiniz veritabanı yapısında Idenetity kullanırsanız DbContext'ten miras alamamalısınız.Çünkü Identity kendi tablolarını tamamen hazıR bir yapı sunar ve bu hazır yapıyı DbContext sağlayamaz.Miras alacağınız sınıf IdentityDbContext olmalıdır.
    public class MyContext:IdentityDbContext
    {
        public MyContext(DbContextOptions<MyContext>options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
