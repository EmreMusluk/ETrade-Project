using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Entities.Abstract;

namespace ETrade.Entities.Concrete
{
    public class BasketMaster : IBaseTable
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Completed { get; set; }
        public int EntityId { get; set; }
        [ForeignKey("EntityId")]
        public User User { get; set; }
        public ICollection<BasketDetail> BasketDetail { get; set; }
    }
}
