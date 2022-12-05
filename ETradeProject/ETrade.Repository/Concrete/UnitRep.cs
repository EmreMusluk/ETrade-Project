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
    public class UnitRep<T> : BaseRepository<Unit>, IUnitRep where T : class
    {
        public UnitRep(ETradeContext db) : base(db)
        {
        }
    }
}
