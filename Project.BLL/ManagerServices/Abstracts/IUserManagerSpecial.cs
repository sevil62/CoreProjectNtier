using Microsoft.AspNetCore.Identity;
using Project.DAL.DALModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    //Identity kullanıyorsanız sizi Async metotlarla çalışm durumu bırakır.
    //Identity aslında bir API'dır.
    public interface IUserManagerSpecial
    {
        //Normal bir metodumuz async çalışmak istiyorsa başına task almak zorundadır.
        //Eğer kendimize has bir User'ımız yoksa IdentityUser üzerinden bu işlemi yaparız.
        Task<bool> AddUser(AppUser item);

    }
}
