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
    public class UserRep<T> : BaseRepository<User>, IUserRep where T : class
    {
        public UserRep(ETradeContext db) : base(db)
        {
        }
    }
}
