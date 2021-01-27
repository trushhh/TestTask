using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestTask.Core.Services;

namespace TestTask.Droid
{
    public class AndroidSqliteConnectionService : ISqliteConnectionService
    {
        private const string FileName = "database.sqlite3";
        private SQLiteAsyncConnection _connection;
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            if (_connection == null)
            {
                var databaseFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var databaseFilePath = Path.Combine(databaseFolder, FileName);
                _connection = new SQLiteAsyncConnection(databaseFilePath);
            }
            return _connection;
        }
    }
}