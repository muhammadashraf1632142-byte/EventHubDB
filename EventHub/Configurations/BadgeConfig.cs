using EventHub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Configurations
{
    public class BadgeConfig : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.BadgeNumber)
                   .IsUnique();
            builder.Property(b => b.Tier)
                   .HasConversion<string>()
                   .IsRequired().HasMaxLength(8);
            builder.Property(b => b.BadgeNumber)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(b => b.IssueDate)
                   .IsRequired();
            builder.HasOne(e=>e.Attendee).WithOne(a=>a.Badge).HasForeignKey<Badge>(b => b.AttendeeId);
        }
    }
}
