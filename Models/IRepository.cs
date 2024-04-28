using System.Linq.Expressions;
namespace WEBPROJECT2.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);

        void Addition(T entity);
    }
}