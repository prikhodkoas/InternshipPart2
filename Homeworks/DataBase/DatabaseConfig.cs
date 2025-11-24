using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal static class DatabaseConfig
    {
        internal const string DataBaseConnectionStringInterMech = @"Server=IM1834\SQLEXPRESS;Database=FileStorageDb;Trusted_Connection=True;TrustServerCertificate=True;";

        internal const string DataBaseConnectionStringHome = @"Server=localhost;Database=master;Trusted_Connection=True;";
    }
}
