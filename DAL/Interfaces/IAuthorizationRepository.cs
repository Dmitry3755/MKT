﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuthorizationRepository
    {
       void AddAccount(Users users);
        List<Users> GetList();
       void Save();
    }
}
