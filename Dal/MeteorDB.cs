namespace Dal
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model;



    public partial class MeteorDB : DbContext
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

        public MeteorDB()
            : base("name=MeteorDB")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        static MeteorDB()
        {
            // ROLA - This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
            // As it is installed in the GAC, Copy Local does not work. It is required for probing.
            // Fixed "Provider not loaded" error
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
