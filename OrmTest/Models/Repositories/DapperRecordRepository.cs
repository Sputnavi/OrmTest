using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace OrmTest.Models.Repositories
{
    class DapperRecordRepository : IRepository
    {
        private readonly string ConnectionString = "Server=.\\SQLEXPRESS;Database=OrmTest;Trusted_Connection=True;";

        public IEnumerable<Record> GetRecords()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Record>("SELECT * FROM RECORD");
            }
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
