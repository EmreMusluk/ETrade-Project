using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Core;
using ETrade.Dal;
using ETrade.Entities.Concrete;
using ETrade.Repository.Abstract;

namespace ETrade.Repository.Concrete
{
    public class ProductRep<T> : BaseRepository<Product>, IProductRep where T : class
    {
        public ProductRep(ETradeContext db) : base(db)
        {
        }
    }
}
