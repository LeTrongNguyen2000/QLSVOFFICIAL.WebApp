using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSVOFFICIAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.Data.Configurations
{
    public class CheckinConfiguration : IEntityTypeConfiguration<Checkin>
    {
        public void Configure(EntityTypeBuilder<Checkin> builder)
        {
            builder.HasKey(e => e.IdCheckin)
                    .HasName("PK__CHECKIN__1AC7AE399E0E9924");

            builder.Property(e => e.CheckRoom).IsUnicode(false);

            builder.HasOne(d => d.IdClassSubjectNavigation)
                .WithMany(p => p.Checkins)
                .HasForeignKey(d => d.IdClassSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHECKIN_CLASS_SUBJECT");

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Checkins)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHECKIN_USER");
        }
    }
}
