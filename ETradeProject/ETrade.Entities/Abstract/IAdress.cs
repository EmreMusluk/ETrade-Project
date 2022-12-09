using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Abstract
{
    public interface IAdress
    {
        public string? Street { get; set; }
        public string? Avenue { get; set; }
        public string? No { get; set; }
        public int? CountyId { get; set; }
    }
}
