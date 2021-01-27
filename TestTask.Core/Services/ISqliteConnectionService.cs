using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask.Core.Services
{
    public interface ISqliteConnectionService
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
