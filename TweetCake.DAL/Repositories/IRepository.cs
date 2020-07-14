using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TweetCake.DAL
{
    public interface IRepository<T> where T :IBaseEntity
    {
        T Insert(T entity);
        T Update(T entity);
        bool Delete(int id);
        IQueryable<T> GetAll();
        T GetById(int id);
        void AddRange(IEnumerable<T> entity);
    }
}
