using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace OrmTest.Models.Repositories
{
    class AdoRecordRepository : IRepository
    {
        private readonly string ConnectionString = "Server=.\\SQLEXPRESS;Database=OrmTest;Trusted_Connection=True;";
        DataSet dataSet;

        public AdoRecordRepository()
        {
            dataSet = new DataSet();
        }

        public IEnumerable<Record> GetRecords()
        {
            string sql = "SELECT * FROM Record";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dataSet);
                return dataSet.Tables[0].AsEnumerable()
                    .Select(dataRow => new Record
                    {
                        RecordId = dataRow.Field<int>(0),
                        Date = dataRow.Field<string>(1),
                        Name = dataRow.Field<string>(2),
                        City = dataRow.Field<string>(3),
                        Country = dataRow.Field<string>(4),
                    });
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataSet.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
