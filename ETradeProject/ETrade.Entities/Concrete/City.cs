﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class City:BaseDescription
    {
        public ICollection<County> Counties { get; set; }
    }
}
