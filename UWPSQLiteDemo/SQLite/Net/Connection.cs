using System;
using UWPSQLiteDemo;

namespace SQLite.Net
{
    internal class Connection
    {
        public static implicit operator Connection(SQLiteConnection v)
        {
            throw new NotImplementedException();
        }

        internal void CreateTable<T>()
        {
            throw new NotImplementedException();
        }

        internal object Table<T>()
        {
            throw new NotImplementedException();
        }

        internal object Insert(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}