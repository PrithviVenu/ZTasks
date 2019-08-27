using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using ZTasks.Models;

namespace ZTasks.Data
{
    class DatabaseAccessContext
    {
        public static SQLiteAsyncConnection Connection;
        public DatabaseAccessContext()
        {

            if (DatabaseAccessContext.Connection == null)
            {

                Debug.WriteLine("Connecting To Database");

                ConnectToDB();
            }
        }

        private bool ConnectToDB()
        {
            var filename = "ZTasks.db";
            var dbPath = ApplicationData.Current.LocalFolder.Path;

            Connection = new SQLiteAsyncConnection(Path.Combine(dbPath, filename));
            InitializeDBWithTables();

            return true;
        }
        private void InitializeDBWithTables()
        {
            Connection.CreateTableAsync<ZTask>();
        }

    }
}
