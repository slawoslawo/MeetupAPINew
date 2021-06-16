using MeetupAPINew.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPINew
{
 public class MeetupSeeder
 {
  private readonly MeetupContext _meetupContext;

  public MeetupSeeder(MeetupContext meetupContext)
  {
   _meetupContext = meetupContext;
  }

  public void Seed()
  {
   if (_meetupContext.Database.CanConnect())
   {
    if (!_meetupContext.Meetups.Any())
    {
     InsertSampleData();
    }
   }
  }

  private void InsertSampleData()
  {
   var meetups = new List<Meetup>
            {
                new Meetup
                {
                    Name = "C# Meeting",
                    Date = DateTime.Now.AddDays(7),
                    IsPrivate = false,
                    Organizer = "Microsoft",
                    Location = new Location
                    {
                        City = "Berlin",
                        Street = "Sonnenstraße 33",
                        PostCode = "10001"
                    },
                    Lectures = new List<Lecture>
                    {
                        new Lecture
                        {
                            Author = "Mads Torgersen",
                            Topic = "C# 10",
                            Description = "New things in C# 10"
                        }
                    }
                },
                new Meetup
                {
                    Name = ".NET Meeting",
                    Date = DateTime.Now.AddDays(7),
                    IsPrivate = false,
                    Organizer = "Microsoft",
                    Location = new Location
                    {
                        City = "London",
                        Street = "Sun street 4",
                        PostCode = "8200"
                    },
                    Lectures = new List<Lecture>
                    {
                        new Lecture
                        {
                            Author = "Tilman Börner",
                            Topic = ".NET 6.0",
                            Description = "New things in .NET 6.0"
                        }

                    }
                },
            };

   _meetupContext.AddRange(meetups);
   _meetupContext.SaveChanges();
  }
 }
}
