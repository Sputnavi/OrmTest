using System;
using System.Collections.Generic;
using System.Linq;
using OrmTest.Models.Repositories;

namespace OrmTest.Controllers
{
    class RecordController : IDisposable
    {
        IRepository repository;

        public RecordController()
        {
            repository = new EFRecordRepository();
        }

        public List<Record> GetRecords()
        {
            return repository.GetRecords().ToList();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
