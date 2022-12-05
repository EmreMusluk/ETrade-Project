using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class Unit:BaseDescription
    {
        public ICollection<Product>Product { get; set; }
        public ICollection<BasketDetail>BasketDetail { get; set; }
    }
}
