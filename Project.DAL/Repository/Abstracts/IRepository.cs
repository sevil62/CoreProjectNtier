using Project.ENTITIES.CoreInterfaces;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repository.Abstracts
{
    public interface  IRepository<T>where T : BaseEntity
    {
        List<T> GetAll();
        void Add(T item);
    }
}
