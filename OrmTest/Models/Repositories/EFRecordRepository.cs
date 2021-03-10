using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmTest.Models.Repositories
{
    class EFRecordRepository : IRepository
    {
        private OrmTestContext _db;

        public EFRecordRepository()
        {
            _db = new OrmTestContext();
        }

        public IEnumerable<Record> GetRecords()
        {
            return _db.Records;
        }

        
        
        
        
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
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
