using Project.DAL.Context;
using Project.DAL.Repository.Abstracts;
using Project.ENTITIES.CoreInterfaces;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repository.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity,IEntity
    {
        MyContext _db;
        public BaseRepository(MyContext db)
        {
            _db= db;
        }
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            _db.SaveChanges();
        }

        public List<T> GetAll()
        {
           return _db.Set<T>().ToList();
        }
    }
}
