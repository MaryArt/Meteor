namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Expedition_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expeditions", t => t.Expedition_Id, cascadeDelete: true)
                .Index(t => t.Expedition_Id);
            
            CreateTable(
                "dbo.Expeditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Mission = c.String(maxLength: 4000),
                        Latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Intervals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        TimeBegin = c.DateTime(nullable: false),
                        TimeEnd = c.DateTime(nullable: false),
                        Clouds = c.Double(nullable: false),
                        Moon = c.Double(nullable: false),
                        MoonHeight = c.Int(nullable: false),
                        RadiantHeight = c.Int(nullable: false),
                        Day_Id = c.Int(),
                        Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Days", t => t.Day_Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .Index(t => t.Day_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meteors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Length = c.Int(nullable: false),
                        Duration = c.Double(nullable: false),
                        Speed = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        Contour = c.Int(nullable: false),
                        Zenit = c.Int(nullable: false),
                        P = c.Double(nullable: false),
                        PPrime = c.Double(nullable: false),
                        Notes = c.String(maxLength: 4000),
                        TraceLength = c.Double(nullable: false),
                        TraceDuration = c.Double(nullable: false),
                        TraceContour = c.Double(nullable: false),
                        Source = c.String(maxLength: 4000),
                        Interval_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Intervals", t => t.Interval_Id)
                .Index(t => t.Interval_Id);
            
            CreateTable(
                "dbo.Magnitudes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MagnitudeValue = c.Double(nullable: false),
                        Meteor_Id = c.Int(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meteors", t => t.Meteor_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Meteor_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 4000),
                        Surname = c.String(maxLength: 4000),
                        MiddleName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartLimitMagnitude = c.Double(nullable: false),
                        StartMood = c.Int(nullable: false),
                        EndLimitMagnitude = c.Double(nullable: false),
                        EndMood = c.Int(nullable: false),
                        Center = c.String(maxLength: 4000),
                        Direction = c.Double(nullable: false),
                        Interval_Id = c.Int(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Intervals", t => t.Interval_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Interval_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.EquatorialCoordinates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Declension = c.Double(nullable: false),
                        HourAngle = c.Double(nullable: false),
                        Meteor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meteors", t => t.Meteor_Id, cascadeDelete: true)
                .Index(t => t.Meteor_Id);
            
            CreateTable(
                "dbo.Group_Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(maxLength: 4000),
                        Program = c.String(maxLength: 4000),
                        Group_Id = c.Int(nullable: false),
                        Person_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .Index(t => t.Group_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Group_Person", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Group_Person", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.EquatorialCoordinates", "Meteor_Id", "dbo.Meteors");
            DropForeignKey("dbo.States", "Person_Id", "dbo.People");
            DropForeignKey("dbo.States", "Interval_Id", "dbo.Intervals");
            DropForeignKey("dbo.Magnitudes", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Magnitudes", "Meteor_Id", "dbo.Meteors");
            DropForeignKey("dbo.Meteors", "Interval_Id", "dbo.Intervals");
            DropForeignKey("dbo.Intervals", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Intervals", "Day_Id", "dbo.Days");
            DropForeignKey("dbo.Days", "Expedition_Id", "dbo.Expeditions");
            DropIndex("dbo.Group_Person", new[] { "Person_Id" });
            DropIndex("dbo.Group_Person", new[] { "Group_Id" });
            DropIndex("dbo.EquatorialCoordinates", new[] { "Meteor_Id" });
            DropIndex("dbo.States", new[] { "Person_Id" });
            DropIndex("dbo.States", new[] { "Interval_Id" });
            DropIndex("dbo.Magnitudes", new[] { "Person_Id" });
            DropIndex("dbo.Magnitudes", new[] { "Meteor_Id" });
            DropIndex("dbo.Meteors", new[] { "Interval_Id" });
            DropIndex("dbo.Intervals", new[] { "Group_Id" });
            DropIndex("dbo.Intervals", new[] { "Day_Id" });
            DropIndex("dbo.Days", new[] { "Expedition_Id" });
            DropTable("dbo.Group_Person");
            DropTable("dbo.EquatorialCoordinates");
            DropTable("dbo.States");
            DropTable("dbo.People");
            DropTable("dbo.Magnitudes");
            DropTable("dbo.Meteors");
            DropTable("dbo.Groups");
            DropTable("dbo.Intervals");
            DropTable("dbo.Expeditions");
            DropTable("dbo.Days");
        }
    }
}
