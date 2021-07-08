using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSVOFFICIAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(e => e.IdSubject)
                .HasName("PK__SUBJECT__BD949FF5026CD2E9");

            builder.Property(e => e.SubjectCode).IsUnicode(false);

            builder.HasOne(d => d.IdFacultyNavigation)
                .WithMany(p => p.Subjects)
                .HasForeignKey(d => d.IdFaculty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SUBJECT_FACULTY");
        }
    }
}
