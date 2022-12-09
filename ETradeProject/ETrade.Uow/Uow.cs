using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Dal;
using ETrade.Repository.Abstract;
using ETrade.Repository.Concrete;

namespace ETrade.Uow
{
    public class Uow : IUow
    {
        ETradeContext _db;
        public Uow(ETradeContext db,IBasketDetailRep basketDetailRep,IBasketMasterRep basketMasterRep,ICategoryRep categoryRep,ICityRep cityRep,ICountyRep countyRep,IProductRep productRep,IUnitRep unitRep,IUserRep userRep,IVatRep vatRep)
        {
            _db = db;
            _basketDetailRep = basketDetailRep;
            _basketMasterRep = basketMasterRep;
            _categoryRep = categoryRep;
            _cityRep = cityRep;
            _countyRep = countyRep;
            _productRep = productRep;
            _unitRep = unitRep;
            _vatRep = vatRep;
            _userRep = userRep;
        }
        public IBasketDetailRep _basketDetailRep { get; private set; }

        public IBasketMasterRep _basketMasterRep { get; private set; }

        public ICategoryRep _categoryRep { get; private set; }

        public ICityRep _cityRep { get; private set; }

        public ICountyRep _countyRep { get; private set; }

        public IProductRep _productRep { get; private set; }

        public IUnitRep _unitRep { get; private set; }

        public IUserRep _userRep { get; private set; }

        public IVatRep _vatRep { get; private set; }

        public bool Commit()
        {
            return _db.SaveChanges() > 0;
        }

    }
}
