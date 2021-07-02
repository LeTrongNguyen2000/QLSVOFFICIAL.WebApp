using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    public partial class QLSVContext : DbContext
    {
        public QLSVContext()
        {
        }

        public QLSVContext(DbContextOptions<QLSVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbsenceForm> AbsenceForms { get; set; }
        public virtual DbSet<Checkin> Checkins { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassSubject> ClassSubjects { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCheckin> StudentCheckins { get; set; }
        public virtual DbSet<StudentClassSubject> StudentClassSubjects { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-AV93HC7;Initial Catalog=QLSV;User ID=adminsv;Password=29112000");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AbsenceForm>(entity =>
            {
                entity.HasKey(e => e.IdAbsenceForm)
                    .HasName("PK__ABSENCE___A7FCF44F4DC47F40");

                entity.HasOne(d => d.IdClassSubjectNavigation)
                    .WithMany(p => p.AbsenceForms)
                    .HasForeignKey(d => d.IdClassSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ABSENCE_FORM_CLASS_SUBJECT");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.AbsenceForms)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ABSENCE_FORM_STUDENT");
            });

            modelBuilder.Entity<Checkin>(entity =>
            {
                entity.HasKey(e => e.IdCheckin)
                    .HasName("PK__CHECKIN__1AC7AE399E0E9924");

                entity.Property(e => e.CheckRoom).IsUnicode(false);

                entity.HasOne(d => d.IdClassSubjectNavigation)
                    .WithMany(p => p.Checkins)
                    .HasForeignKey(d => d.IdClassSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHECKIN_CLASS_SUBJECT");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Checkins)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHECKIN_USER");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClass)
                    .HasName("PK__CLASS__003FCC7D1CC198E8");

                entity.Property(e => e.ClassName).IsUnicode(false);

                entity.HasOne(d => d.IdFacultyNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdFaculty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLASS_FACULTY");
            });

            modelBuilder.Entity<ClassSubject>(entity =>
            {
                entity.HasKey(e => e.IdClassSubject)
                    .HasName("PK__CLASS_SU__4118476E48A95437");

                entity.Property(e => e.ClassSubjectName).IsUnicode(false);

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLASS_SUBJECT_SUBJECT");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(e => e.IdFaculty)
                    .HasName("PK__FACULTY__0D72F2BFC3A486F4");

                entity.Property(e => e.FacultyCode).IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__ROLE__B43690548B1B0BEC");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PK__STUDENT__61B35104D6218243");

                entity.Property(e => e.StudentCode).IsUnicode(false);

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_CLASS");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_USER");
            });

            modelBuilder.Entity<StudentCheckin>(entity =>
            {
                entity.HasKey(e => new { e.IdCheckin, e.IdStudent })
                    .HasName("PK__STUDENT___4CDC9B29D5D84085");

                entity.HasOne(d => d.IdChekinNavigation)
                    .WithMany(p => p.StudentCheckins)
                    .HasForeignKey(d => d.IdCheckin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_CHEKIN_CHECKIN");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.StudentCheckins)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_CHEKIN_STUDENT");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.StudentCheckins)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_CHEKIN_USER");
            });

            modelBuilder.Entity<StudentClassSubject>(entity =>
            {
                entity.HasKey(e => new { e.IdClassSubject, e.IdStudent })
                    .HasName("PK__STUDENT___1703727E0184EA17");

                entity.HasOne(d => d.IdClassSubjectNavigation)
                    .WithMany(p => p.StudentClassSubjects)
                    .HasForeignKey(d => d.IdClassSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_CLASS_SUBJECT_CLASS_SUBJECT");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.StudentClassSubjects)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STUDENT_CLASS_SUBJECT_STUDENT");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject)
                    .HasName("PK__SUBJECT__BD949FF5026CD2E9");

                entity.Property(e => e.SubjectCode).IsUnicode(false);

                entity.HasOne(d => d.IdFacultyNavigation)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.IdFaculty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUBJECT_FACULTY");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__USER__B7C92638436CC53C");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.IdFacultyNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdFaculty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_FACULTY");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ROLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
