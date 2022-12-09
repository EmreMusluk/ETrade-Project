using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Entities.Abstract;

namespace ETrade.Entities.Concrete
{
    public class BaseEntities : IBaseTable, IAdress
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? Avenue { get; set; }
        public string? No { get; set; }
        public int? CountyId { get; set; }
    }
}
