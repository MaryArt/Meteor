using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace Dal
{
    public class MyContext:DbContext
    {
        public DbSet<Meteor> Meteors { get; set; }
        public DbSet<Interval> Intervals { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Expedition> Expeditions { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Group_Person> Group_Person { get; set; }

        public DbSet<State> States { get; set; }
        public DbSet<Magnitude> Magnitudes { get; set; }
        public DbSet<EquatorialCoordinate> EquatorialCoordinates { get; set; }

        static MyContext()
        {
            Database.SetInitializer<MyContext>(new DbInitializer());
            using (MyContext db = new MyContext())
                db.Database.Initialize(false);
        }
    }
    class DbInitializer : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            var expedition = context.Expeditions.Add(new Expedition() { Name = "Персеиды", Mission = "ММП", Latitude = 46.67 });
            var day = context.Days.Add(new Day() { Date = DateTime.Now, Expedition = expedition });
            //var inter = context.Intervals.Add(new Interval()
            //{
            //    Number = 1,
            //    Day = day
            //});
            //var interval = context.Intervals.Add(new Interval());

            context.Meteors.Add(new Meteor()
            {
                Number = 1,
                Time = DateTime.Now,
                P = 10
                //Interval = interval
            });

            

            base.Seed(context);
        }
    }
}
