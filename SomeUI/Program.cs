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
        static void Main(string[] args)
        {
            InsertSamurai();
            InsertMultipleSamurais();
            InsertMulipleDifferentObjects();
            Console.ReadLine();
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai()
            {
                Name = "Arun"
            };

            using (var context = new DatabaseContext())
            {
                //*** either of the below add methods can be used
                //context.Add(samurai);
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
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
            using (var context = new DatabaseContext())
            {
                //*** either of the below add methods can be used
                //context.Add(samurai);
                context.Samurais.AddRange(samurai1, samurai2);
                context.SaveChanges();
            }


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
            using (var context = new DatabaseContext())
            {
                context.Samurais.AddRange(sam);
                context.SaveChanges();
            }


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

            using (var context = new DatabaseContext())
            {
                context.AddRange(samurai, battle);
                context.SaveChanges();
            }
        }
    }
}
