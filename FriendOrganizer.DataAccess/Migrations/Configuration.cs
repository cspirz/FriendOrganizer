namespace FriendOrganizer.DataAccess.Migrations
{
    using FriendOrganizer.Model;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(f => f.FirstName,
                new Friend { FirstName = "Charlie", LastName = "Spirz" },
                new Friend { FirstName = "Jessica", LastName = "Leasure" },
                new Friend { FirstName = "Katrina", LastName = "Thornton" },
                new Friend { FirstName = "Laura", LastName = "Spirz" });

            context.ProgrammingLanguages.AddOrUpdate(
                pl => pl.Name,
                new ProgrammingLanguage { Name = "C#" },
                new ProgrammingLanguage { Name = "TypeScript" },
                new ProgrammingLanguage { Name = "F#" },
                new ProgrammingLanguage { Name = "Swift" },
                new ProgrammingLanguage { Name = "Java" }
                );

            context.SaveChanges();

            context.FriendPhoneNumbers.AddOrUpdate(pn => pn.Number,
                new FriendPhoneNumber { Number = "+49 12345678", FriendId = context.Friends.First().Id });

            context.Meetings.AddOrUpdate(m => m.Title,
                new Meeting
                {
                    Title = "Watching Football",
                    DateFrom = new DateTime(2018, 11, 22),
                    DateTo = new DateTime(2018, 11, 22),
                    Friends = new List<Friend>
                    {
                        context.Friends.Single(f => f.FirstName == "Charlie" && f.LastName == "Spirz"),
                        context.Friends.Single(f => f.FirstName == "Jessica" && f.LastName == "Leasure")
                    }

                });

        }
    }
}
