using WEBPROJECT2.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace WEBPROJECT2.Models
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly DBContextWB _dbContext;
        internal DbSet<T> set;
        public Repository(DBContextWB dbContext)
        {
            _dbContext = dbContext;
            this.set = _dbContext.Set<T>();
        }
        public void Addition(T entity){
            set.Add(entity);
            _dbContext.SaveChanges();
        }
        public T Get(Expression<Func<T , bool>> filter){
            IQueryable<T> query = set;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
        public IEnumerable<T> GetAll(){
            IQueryable<T> query = set;
            return query.ToList();
        }
    }
}