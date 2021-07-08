using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSVOFFICIAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.Data.Configurations
{
    public class StudentCheckinConfiguration : IEntityTypeConfiguration<StudentCheckin>
    {
        public void Configure(EntityTypeBuilder<StudentCheckin> builder)
        {
            builder.HasKey(e => new { e.IdCheckin, e.IdStudent })
                .HasName("PK__STUDENT___4CDC9B29D5D84085");

            builder.HasOne(d => d.IdChekinNavigation)
                .WithMany(p => p.StudentCheckins)
                .HasForeignKey(d => d.IdCheckin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENT_CHEKIN_CHECKIN");

            builder.HasOne(d => d.IdStudentNavigation)
                .WithMany(p => p.StudentCheckins)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENT_CHEKIN_STUDENT");

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.StudentCheckins)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENT_CHEKIN_USER");
        }
    }
}
