using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TweetCake.DAL.Entities;

namespace TweetCake.DAL
{
    public class Repository<T> : IRepository<T> where T :class,IBaseEntity
    {
        private TweetCakeDbContext _dbContext;
        private DbSet<T> _table;
        public Repository(TweetCakeDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public void AddRange(IEnumerable<T> entity)
        {
            _table.AddRange(entity);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            entity.IsDeleted = true;
            Update(entity);
            return true;
        }

        public IQueryable<T> GetAll()
        {
            return _table.Where(x => x.IsDeleted == false);
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public T Insert(T entity)
        {
            _table.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;

        }
    }
}
