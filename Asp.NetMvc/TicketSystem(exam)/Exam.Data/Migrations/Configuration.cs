namespace Exam.Data.Migrations
{
    using Exam.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Tickets.Count() > 0)
            {
                return;
            }

            Random rand = new Random();

            Category TestCat = new Category { Name = "TestTicketsCategory" };
            ApplicationUser user = new ApplicationUser() { UserName = "TestUser"};

            for (int i = 0; i < 10; i++)
            {
                Ticket ticket = new Ticket();
                ticket.Description = "JustRandomTicket";
                ticket.Title = "JustRandomTitle";
                ticket.ScreenShotUrl = "http://rlv.zcache.com/black_martini_corporate_logo_event_drink_ticket_business_card-r58e25ff4f6a64a298345ce22f75e59d3_xwjey_8byvr_512.jpg";
                ticket.Category = TestCat;
                ticket.Author = user;
                

                var commentsCount = rand.Next(0, 10);
                for (int j = 0; j < commentsCount; j++)
                {
                    ticket.Comments.Add(new Comment { Content = "Mnoo kofti bug.", Author = user });
                }

                context.Tickets.Add(ticket);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
