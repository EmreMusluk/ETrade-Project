using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Repository.Abstract;

namespace ETrade.Uow
{
    public interface IUow
    {
        IBasketDetailRep _basketDetailRep { get; }
        IBasketMasterRep _basketMasterRep { get; }
        ICategoryRep _categoryRep { get; }
        ICityRep _cityRep { get; }
        ICountyRep _countyRep { get; }
        IProductRep _productRep { get; }
        IUnitRep _unitRep { get; }
        IUserRep _userRep { get; }
        IVatRep _vatRep { get; }

        void Commit();

    }
}
