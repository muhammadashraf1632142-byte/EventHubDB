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
    internal class OrganizerProfileConfig : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasKey(op => op.OrganizerId);
            builder.Property(op => op.Biography)
                   .HasMaxLength(500);
            builder.Property(op => op.WebsiteUrl)
                   .HasMaxLength(200);
            builder.Property(op => op.LogoUrl)
                   .HasMaxLength(200);
            builder.HasOne(op => op.Organizer).WithOne(p => p.Profile).HasForeignKey<OrganizerProfile>(op => op.OrganizerId);
        }
    }
}
