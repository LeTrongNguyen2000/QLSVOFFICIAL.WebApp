using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSVOFFICIAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.Data.Configurations
{
    public class AbsenceFormConfiguration : IEntityTypeConfiguration<AbsenceForm>
    {

        public void Configure(EntityTypeBuilder<AbsenceForm> builder)
        {
            builder.HasKey(e => e.IdAbsenceForm)
                    .HasName("PK__ABSENCE___A7FCF44F4DC47F40");

            builder.HasOne(d => d.IdClassSubjectNavigation)
                .WithMany(p => p.AbsenceForms)
                .HasForeignKey(d => d.IdClassSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ABSENCE_FORM_CLASS_SUBJECT");

            builder.HasOne(d => d.IdStudentNavigation)
                .WithMany(p => p.AbsenceForms)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ABSENCE_FORM_STUDENT");
        }
    }
}
