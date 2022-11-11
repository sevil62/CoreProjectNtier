using Microsoft.AspNetCore.Identity;
using Project.DAL.DALModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface ILoginManager
    {
        Task<bool> SignInUser(AppUser item, bool remember);
    }
}
