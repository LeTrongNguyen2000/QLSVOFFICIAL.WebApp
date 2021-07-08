using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLSVOFFICIAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(e => e.IdUser)
                .HasName("PK__USER__B7C92638436CC53C");

            builder.Property(e => e.Email).IsUnicode(false);

            builder.Property(e => e.Password).IsUnicode(false);

            builder.Property(e => e.Phone).IsUnicode(false);

            builder.Property(e => e.UserName).IsUnicode(false);

            builder.HasOne(d => d.IdFacultyNavigation)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.IdFaculty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_FACULTY");

            builder.HasOne(d => d.IdRoleNavigation)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_ROLE");
        }
    }
}
