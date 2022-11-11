using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IManager<T>where T:BaseEntity
    {
        string Add(T item);//IRepositoryde de Add vardı aradaki fark orada veri tabanında herşeyi ekler ama burada soru sosrar ve ona göre işlem yapar
       List<T> GetAll();
    }
}
