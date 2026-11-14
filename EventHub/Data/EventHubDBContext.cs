using EventHub.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventHub.Configurations;

namespace EventHub.Data
{
    public class EventHubDBContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EventHubDB;Trusted_Connection=true;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BadgeConfig());
            modelBuilder.ApplyConfiguration(new OrganizerProfileConfig());
            modelBuilder.Entity<Event>()
                        .HasKey(e => e.Id);
            modelBuilder.Entity<Event>()
                        .Property(e => e.Title)
                        .IsRequired()
                        .HasMaxLength(200);
            modelBuilder.Entity<Event>()
                        .Property(e => e.Description)
                        .IsRequired()
                        .HasMaxLength(1000);
            modelBuilder.Entity<Event>()
                        .Property(e => e.StartDate)
                        .IsRequired();
            modelBuilder.Entity<Event>()
                        .Property(e => e.EndDate)
                        .IsRequired(false);
            modelBuilder.Entity<Event>()
                        .Property(e => e.MaxAttendees)
                        .IsRequired();
            modelBuilder.Entity<Event>()
                        .HasOne(e => e.Organizer)
                        .WithMany(o => o.Events)
                        .HasForeignKey(e => e.OrganizerId);
        }
    }
}
