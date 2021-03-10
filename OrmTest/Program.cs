using System;
using System.Diagnostics;
using OrmTest.Controllers;

namespace OrmTest
{
    class Program
    {
        static void Main()
        {
            var controller = new RecordController();
            Stopwatch sw = new Stopwatch();
            
            sw.Start();
            var records = controller.GetRecords();
            //foreach (Record record in records)
            //{
            //    Console.WriteLine(record);
            //}
            sw.Stop();
            
            Console.WriteLine($"Time: {sw.Elapsed}");
        }
    }
}
