using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("SUBJECT")]
    [Index(nameof(SubjectName), Name = "unique_SubjectName", IsUnique = true)]
    public partial class Subject
    {
        public Subject()
        {
            ClassSubjects = new HashSet<ClassSubject>();
        }

        [Key]
        public int IdSubject { get; set; }
        [Required]
        [StringLength(10)]
        public string SubjectCode { get; set; }
        [Required]
        [StringLength(50)]
        public string SubjectName { get; set; }
        public int IdFaculty { get; set; }

        [ForeignKey(nameof(IdFaculty))]
        [InverseProperty(nameof(Faculty.Subjects))]
        public virtual Faculty IdFacultyNavigation { get; set; }
        [InverseProperty(nameof(ClassSubject.IdSubjectNavigation))]
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
