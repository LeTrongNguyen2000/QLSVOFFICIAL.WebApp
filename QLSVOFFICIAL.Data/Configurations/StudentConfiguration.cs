using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSVOFFICIAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(e => e.IdStudent)
                .HasName("PK__STUDENT__61B35104D6218243");

            builder.Property(e => e.StudentCode).IsUnicode(false);

            builder.HasOne(d => d.IdClassNavigation)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.IdClass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENT_CLASS");

            builder.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENT_USER");
        }
    }
}
