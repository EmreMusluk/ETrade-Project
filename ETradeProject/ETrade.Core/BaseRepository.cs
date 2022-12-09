using ETrade.Dal;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETrade.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        ETradeContext _db;
        public BaseRepository(ETradeContext db)
        {
            _db = db;
        }
        public bool Add(T entity)
        {
            try
            {
                Set().Add(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                Set().Remove(Find(Id));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T Find(int Id)
        {
            return Set().Find(Id);
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            return Set().FirstOrDefault(filter);
        }

        public List<T> List()
        {
            return Set().ToList();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T entity)
        {
            try
            {
               Set().Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}