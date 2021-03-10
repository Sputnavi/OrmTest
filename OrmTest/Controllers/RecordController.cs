using System;
using System.Collections.Generic;
using System.Linq;
using OrmTest.Models.Repositories;

namespace OrmTest.Controllers
{
    class RecordController
    {
        private IRepository _repository;

        public RecordController(IRepository repository)
        {
            _repository = repository;
        }

        public List<Record> GetRecords()
        {
            return _repository.GetRecords().ToList();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
