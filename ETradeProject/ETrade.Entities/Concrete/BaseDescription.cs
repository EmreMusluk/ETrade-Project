using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Entities.Abstract;

namespace ETrade.Entities.Concrete
{
    public class BaseDescription : IBaseDescription,IBaseTable
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
       
    }
}
