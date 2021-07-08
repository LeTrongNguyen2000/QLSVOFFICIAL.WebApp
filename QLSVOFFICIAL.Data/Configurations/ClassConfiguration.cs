using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSVOFFICIAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.Data.Configurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(e => e.IdClass)
                    .HasName("PK__CLASS__003FCC7D1CC198E8");

            builder.Property(e => e.ClassName).IsUnicode(false);

            builder.HasOne(d => d.IdFacultyNavigation)
                .WithMany(p => p.Classes)
                .HasForeignKey(d => d.IdFaculty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLASS_FACULTY");
        }
    }
}
