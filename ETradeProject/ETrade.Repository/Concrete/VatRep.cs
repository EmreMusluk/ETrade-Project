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
    public class VatRep<T> : BaseRepository<Vat>, IVatRep where T : class
    {
        public VatRep(ETradeContext db) : base(db)
        {
        }
    }
}
