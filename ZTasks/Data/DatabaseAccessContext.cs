using SQLite;
using System.Diagnostics;
using System.IO;
using Windows.Storage;
using ZTasks.Models;

namespace ZTasks.Data
{
    class DatabaseAccessContext
    {
        public static SQLiteAsyncConnection Connection;
        private static DatabaseAccessContext instance = null;
        private static readonly object lockobj = new object();

        private DatabaseAccessContext()
        {
            ConnectToDB();
        }
        public static DatabaseAccessContext GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockobj)
                    {
                        if (instance == null)
                            instance = new DatabaseAccessContext();
                    }
                }
                return instance;
            }
        }

        private void ConnectToDB()
        {
            if (Connection != null)
            {
                return;
            }
            Debug.WriteLine("Connecting To Database");

            var filename = "ZTasks.db";
            var dbPath = ApplicationData.Current.LocalFolder.Path;

            Connection = new SQLiteAsyncConnection(Path.Combine(dbPath, filename));
            InitializeDBWithTables();

        }
        private void InitializeDBWithTables()
        {
            //Connection.CreateTableAsync<ZTask>();
            Connection.CreateTableAsync<User>();
            Connection.CreateTableAsync<TaskAssignment>();
            Connection.CreateTableAsync<TaskDetail>();

        }

    }
}
