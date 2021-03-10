using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmTest.Models.Repositories
{
    interface IRepository : IDisposable
    {
        IEnumerable<Record> GetRecords();
    }
}
