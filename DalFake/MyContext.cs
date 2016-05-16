using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DalFake
{
    public class MyContext
    {
        public List<Meteor> Meteors { get; set; }
        public List<Interval> Intervals { get; set; }
        public List<Day> Days { get; set; }
        public List<Expedition> Expeditions { get; set; }

        public List<Group> Groups { get; set; }
        public List<Person> People { get; set; }
        public List<Group_Person> Group_Person { get; set; }

        public List<State> States { get; set; }
        public List<Magnitude> Magnitudes { get; set; }
        public List<EquatorialCoordinate> EquatorialCoordinates { get; set; }
        

        public MyContext() 
        {
            Meteors = new List<Meteor>(3);
            Intervals = new List<Interval>();
            Days = new List<Day>();
            Expeditions = new List<Expedition>();
            Groups = new List<Group>();
            People = new List<Person>();
            Group_Person = new List<Model.Group_Person>();
            States = new List<State>();
            Magnitudes = new List<Magnitude>();
            EquatorialCoordinates = new List<EquatorialCoordinate>(); 

            this.Expeditions.Add(new Expedition() { Name = "Персеиды", Mission = "ММП", Latitude = 46.67 });
            this.Expeditions.Add(new Expedition() { Name = "Ореониды", Mission = "ММП", Latitude = 46.67 });
            this.Days.Add(new Day() { Date = DateTime.UtcNow, Expedition = Expeditions.First() });
            this.Groups.Add(new Group() { Name = "first" });
            this.Intervals.Add(new Interval()
            {
                Number = 1,
                Day = Days.First(),
                Group = Groups.First(),
                TimeBegin = DateTime.UtcNow,
                TimeEnd = DateTime.UtcNow,
                Clouds = 10,
                Moon = 0.25,
                RadiantHeight = 75,
            });

            this.Meteors.Add(new Meteor()
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
                TraceLength = 5,
                TraceDuration = 0.5,
                TraceContour = 5,

                Interval = Intervals.First()
            });

            this.People.Add(new Person() { Name = "Иван", Surname = "Иванов", MiddleName = "Иванович" });
            this.Group_Person.Add(new Group_Person() { Group = Groups.First(), Person = People.First(), Role = "Наблюдатель" });
            this.States.Add(new State()
            {
                Person = People.First(),
                Interval = Intervals.First(),
                StartLimitMagnitude = 5.5,
                StartMood = 5,
                Direction = 6,
                Center = "Лебедь",
                EndLimitMagnitude = 6.4,
                EndMood = 4
            });

            this.Magnitudes.Add(new Magnitude()
            {
                MagnitudeValue = 2.3,
                Person = People.First(),
                Meteor = Meteors.First()
            });

            this.EquatorialCoordinates.Add(new EquatorialCoordinate() { Meteor = Meteors.First(), Declension = 55, HourAngle = 113.68 });
        }

        public void SaveChanges()
        {

        }
    }
    
}
