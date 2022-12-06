﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Core;
using ETrade.Entities.Concrete;

namespace ETrade.Repository.Abstract
{
    public interface IUserRep:IBaseRepository<User>
    {
        User CreateUser(User user);
        User Login(string Mail, string Password);
    }
}
