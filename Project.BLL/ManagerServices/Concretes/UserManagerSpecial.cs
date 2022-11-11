using Microsoft.AspNetCore.Identity;
using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.DALModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class UserManagerSpecial : IUserManagerSpecial
    {
        UserManager<AppUser> _umanager;
        SignInManager<AppUser> _smanager;
        public UserManagerSpecial(UserManager<AppUser> umanager,SignInManager<AppUser> smanager)
        {
            _umanager = umanager;
            _smanager = smanager;

        }
        public async Task<bool> AddUser(AppUser item)
        {
            //Saadece Asenkron yaratılmış metotlara await diyebilirsiniz.
            //UserManager CreateAsync metodu ilgili kullanıcıyı eklemenizi sağlayan metotdur.CreateAsync metodu size bir task result döndürür(yani ilgili görev başarılı oldu mu olmadı mı)
            IdentityResult result= await _umanager.CreateAsync(item,item.PasswordHash);
            if (result.Succeeded)
            {
                //SignInAsyn metodu kişinin login olmasını sağlayan bir SignInManager metodudur.Kendisi iki tane argüman alır ve kim login olmuş ve login durumu Session Cookie mi (yani browser kapandığında kapanacak mı)yoksa Persisten Cookie mi(yani browser kapandığın da kalacak mı)
                await _smanager.SignInAsync(item, isPersistent: false);
                return true;
            }
            return false;
        }
    }
}
