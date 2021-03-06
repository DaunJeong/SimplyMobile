﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyMobile.Data
{
    public interface ICrudProvider
    {
        int Create<T>(T obj) where T : new();
        T Read<T>(object primaryKey) where T : new();
        int Update(object obj);
        int Delete<T>(object primaryKey);
        int Delete(object objectToDelete);
    }
}
