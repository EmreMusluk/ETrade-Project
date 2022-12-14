using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace ETrade.Core
{
    public interface IBaseRepository<T> where T : class
    {
        public T Get(Expression<Func<T, bool>> filter);
        public List<T> List();
        public T Find(int Id);
        public bool Update(T entity);
        public bool Delete(int Id);
        public bool Add(T entity);
        public DbSet<T> Set();

    }
}
