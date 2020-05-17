using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeUI
{
    public class Program
    {
        private static DatabaseContext _databaseContext = new DatabaseContext();
        static void Main(string[] args)
        {
            //InsertSamurai();
            //InsertMultipleSamurais();
            //InsertMulipleDifferentObjects();
            //UpdateSimpleObject();
            DoMultipleDBOperations();

            Console.ReadLine();
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai()
            {
                Name = "Arun"
            };

            //using (var context = new DatabaseContext())
            //{
            //    //*** either of the below add methods can be used
            //    //context.Add(samurai);
            //    context.Samurais.Add(samurai);
            //    context.SaveChanges();
            //}

            _databaseContext.Samurais.Add(samurai);
            _databaseContext.SaveChanges();
        }

        private static void InsertMultipleSamurais()
        {
            var samurai1 = new Samurai()
            {
                Name = "S1"
            };
            var samurai2 = new Samurai()
            {
                Name = "S2"
            };
            //using (var context = new DatabaseContext())
            //{
            //    //*** either of the below add methods can be used
            //    //context.Add(samurai);
            //    context.Samurais.AddRange(samurai1, samurai2);
            //    context.SaveChanges();
            //}
            _databaseContext.Samurais.AddRange(samurai1, samurai2);
            _databaseContext.SaveChanges();

            var samurai3 = new Samurai()
            {
                Name = "S3"
            };
            var samurai4 = new Samurai()
            {
                Name = "S4"
            };
            var sam = new List<Samurai>();
            sam.Add(samurai3);
            sam.Add(samurai4);
            //using (var context = new DatabaseContext())
            //{
            //    context.Samurais.AddRange(sam);
            //    context.SaveChanges();
            //}
            _databaseContext.Samurais.AddRange(sam);
            _databaseContext.SaveChanges();

        }


        private static void InsertMulipleDifferentObjects()
        {
            var samurai = new Samurai()
            {
                Name = "S5"
            };
            var battle = new Battle()
            {
                Name = "First Battle",
                StartDate = DateTime.Now.AddYears(-100),
                EndDate = DateTime.Now.AddYears(-99)
            };

            //using (var context = new DatabaseContext())
            //{
            //    context.AddRange(samurai, battle);
            //    context.SaveChanges();
            //}
            _databaseContext.AddRange(samurai, battle);
            _databaseContext.SaveChanges();
        }

        private static void UpdateSimpleObject()
        {
            var sam = _databaseContext.Samurais.FirstOrDefault(s => s.Name == "S5");
            if (sam == null)
                throw new Exception("Samurai not found");

            sam.Name = "S55";

            _databaseContext.Update(sam);
            _databaseContext.SaveChanges();
        }

        private static void DoMultipleDBOperations()
        {
            var sam = _databaseContext.Samurais.FirstOrDefault(s => s.Id == 1);
            if (sam == null)
                throw new Exception("Samurai not found");

            sam.Name += " Upd";

            var samurai = new Samurai()
            {
                Name = "New Sam"
            };

            _databaseContext.Samurais.Add(samurai);
            _databaseContext.SaveChanges();
        }

        private static void InsertRelatedObjects()
        {
            var samurai = new Samurai()
            {
                Name = "Arun",
                Quotes = new List<Quote>()
                {
                    new Quote{ Text = "I will be back"},
                    new Quote {Text = "It's done"}
                }
            };

            _databaseContext.Samurais.Add(samurai);
            _databaseContext.SaveChanges();
        }
    }
}
