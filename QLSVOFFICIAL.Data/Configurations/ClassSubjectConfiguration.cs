using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSVOFFICIAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.Data.Configurations
{
    public class ClassSubjectConfiguration : IEntityTypeConfiguration<ClassSubject>
    {

        public void Configure(EntityTypeBuilder<ClassSubject> builder)
        {
            builder.HasKey(e => e.IdClassSubject)
                    .HasName("PK__CLASS_SU__4118476E48A95437");

            builder.Property(e => e.ClassSubjectName).IsUnicode(false);

            builder.HasOne(d => d.IdSubjectNavigation)
                .WithMany(p => p.ClassSubjects)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLASS_SUBJECT_SUBJECT");
        }
    }
}
