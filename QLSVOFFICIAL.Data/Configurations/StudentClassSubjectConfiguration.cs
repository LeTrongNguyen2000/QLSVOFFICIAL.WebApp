using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSVOFFICIAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.Data.Configurations
{
    public class StudentClassSubjectConfiguration : IEntityTypeConfiguration<StudentClassSubject>
    {
        public void Configure(EntityTypeBuilder<StudentClassSubject> builder)
        {
            builder.HasKey(e => new { e.IdClassSubject, e.IdStudent })
                .HasName("PK__STUDENT___1703727E0184EA17");

            builder.HasOne(d => d.IdClassSubjectNavigation)
                .WithMany(p => p.StudentClassSubjects)
                .HasForeignKey(d => d.IdClassSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENT_CLASS_SUBJECT_CLASS_SUBJECT");

            builder.HasOne(d => d.IdStudentNavigation)
                .WithMany(p => p.StudentClassSubjects)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENT_CLASS_SUBJECT_STUDENT");
        }
    }
}
