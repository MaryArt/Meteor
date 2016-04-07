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
            var day = context.Days.Add(new Day() { Date = DateTime.UtcNow, Expedition = expedition });
            var group = context.Groups.Add(new Group() { Name = "first" });
            var interval = context.Intervals.Add(new Interval()
            {
                Number = 1,
                Day = day,
                Group = group,
                TimeBegin = DateTime.UtcNow,
                TimeEnd = DateTime.UtcNow,
                Clouds = 10,
                Moon = 0.25,
                RadiantHeight = 75,
            });

            var meteor = context.Meteors.Add(new Meteor()
            {
                Number = 1,
                Time = DateTime.UtcNow,
                Length = 15,
                Duration = 1.2,
                Speed = 5,
                Color = 3,
                Contour = 5,
                Zenit = 35,
                P = 10,
                PPrime = 4,
                Notes = "вспышка",
                Source = "Лира",
                Trace = 0.5,

                Interval = interval
            });

            var person = context.People.Add(new Person() { Name = "Иван", Surname = "Иванов", MiddleName = "Иванович"});
            var group_person = context.Group_Person.Add(new Group_Person() { Group = group, Person = person, Role = "Наблюдатель"});
            var state = context.States.Add(new State()
            {
                Person = person,
                Interval = interval,
                StartLimitMagnitude = 5.5,
                StartMood = 5,
                Direction = 6,
                Center = "Лебедь",
                EndLimitMagnitude = 6.4,
                EndMood = 4
            });

            var magnitude = context.Magnitudes.Add(new Magnitude()
            {
                MagnitudeValue = 2.3,
                Person = person,
                Meteor = meteor
            });

            var coord = context.EquatorialCoordinates.Add(new EquatorialCoordinate() { Meteor = meteor, Declension = 55, HourAngle=113.68 });

            

            base.Seed(context);
        }
    }
}
