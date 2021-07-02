using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("CLASS_SUBJECT")]
    public partial class ClassSubject
    {
        public ClassSubject()
        {
            AbsenceForms = new HashSet<AbsenceForm>();
            Checkins = new HashSet<Checkin>();
            StudentClassSubjects = new HashSet<StudentClassSubject>();
        }

        [Key]
        public int IdClassSubject { get; set; }
        [Required]
        [StringLength(10)]
        public string ClassSubjectName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateStrart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateFinish { get; set; }
        public int IdSubject { get; set; }

        [ForeignKey(nameof(IdSubject))]
        [InverseProperty(nameof(Subject.ClassSubjects))]
        public virtual Subject IdSubjectNavigation { get; set; }
        [InverseProperty(nameof(AbsenceForm.IdClassSubjectNavigation))]
        public virtual ICollection<AbsenceForm> AbsenceForms { get; set; }
        [InverseProperty(nameof(Checkin.IdClassSubjectNavigation))]
        public virtual ICollection<Checkin> Checkins { get; set; }
        [InverseProperty(nameof(StudentClassSubject.IdClassSubjectNavigation))]
        public virtual ICollection<StudentClassSubject> StudentClassSubjects { get; set; }
    }
}
