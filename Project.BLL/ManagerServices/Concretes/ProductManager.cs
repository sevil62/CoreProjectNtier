using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repository.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class ProductManager:BaseManager<Product>,IProductManager
    {
        public ProductManager(IRepository<Product>prp):base(prp)
        {

        }
        public override string Add(Product item)
        {
            if (item.ProductName==null || item.ProductName.Trim()=="")
            {
                return "Ekleme başarısız..Isim hatası var";
            }
            _irp.Add(item);
            return "Ekleme başarılı";
        }
    }
}
