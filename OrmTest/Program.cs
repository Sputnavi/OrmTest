using System;
using System.Data;
using System.Diagnostics;
using OrmTest.Controllers;
using OrmTest.Models.Repositories;

/*
 * TODO: check how to free memory for ado
 */

namespace OrmTest
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                RecordController controller = null;
                Console.WriteLine("Choose ORM:");
                Console.WriteLine("1.ADO.NET");
                Console.WriteLine("2.Entity Framework");
                Console.WriteLine("0.Exit");
                Console.Write("> ");
                switch (Console.ReadLine())
                {
                    case "1":
                        controller = new RecordController(new AdoRecordRepository());
                        break;
                    case "2":
                        controller = new RecordController(new EFRecordRepository());
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
                Test(controller); 
            }
        }

        static void Test(RecordController controller)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var records = controller.GetRecords();
            //foreach (Record record in records)
            //{
            //    Console.WriteLine(record);
            //}
            sw.Stop();
            Console.WriteLine($"\nTime spent to load records: {sw.Elapsed}\n");
        }
    }
}
