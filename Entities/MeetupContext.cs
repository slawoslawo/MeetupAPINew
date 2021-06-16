using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAPINew.Entities
{
 public class MeetupContext : DbContext
 {
  public MeetupContext(DbContextOptions options) : base(options)
  {

  }
  //private string _connectionString = "Data source= mm.db";

  public DbSet<Meetup> Meetups { get; set; }
  public DbSet<Location> Locations { get; set; }
  public DbSet<Lecture> Lectures { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
   modelBuilder.Entity<Meetup>()
       .HasOne(m => m.Location)
       .WithOne(l => l.Meetup)
       .HasForeignKey<Location>(l => l.MeetupId);

   modelBuilder.Entity<Meetup>()
       .HasMany(m => m.Lectures)
       .WithOne(l => l.Meetup)
       .HasForeignKey( l => l.MeetupId);
  }

  //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  //{
  // optionsBuilder.UseSqlite(_connectionString);
  //}
 }
}
