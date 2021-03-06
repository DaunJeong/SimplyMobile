﻿using SQLite.Net;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyMobile.Data
{
    public class SQLiteAsync : SQLiteConnectionWithLock, ICrudProvider
    {
        public SQLiteAsync(ISQLitePlatform platform, SQLiteConnectionString connection)
            : base(platform, connection)
        {

        }

        public int Create<T>(T obj) where T : new()
        {
            this.CreateTable<T>();
            return this.Insert(obj);
        }

        public T Read<T>(object primaryKey) where T : new()
        {
            return base.Find<T>(primaryKey);
        }
    }
}
