using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.CoreInterfaces;
using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.DALModel
{
    //AppUser Identity'den miras alarak bu sınıfın özelliklerini içine almak istiorda artık nerede IdentityUser kullanacak isek oraya AppUser classını yazmalıyız
    public class AppUser : IdentityUser, IEntity
    {
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DataStatus? Status { get; set; }
    }
}
