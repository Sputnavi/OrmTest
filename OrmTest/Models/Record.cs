using System;
using System.Collections.Generic;

#nullable disable

namespace OrmTest
{
    public partial class Record
    {
        public int RecordId { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{nameof(RecordId)}: {RecordId}, {nameof(Date)}: {Date}, {nameof(Name)}: {Name}, {nameof(City)}: {City}, {nameof(Country)}: {Country}";
        }
    }
}
