using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("STUDENT_CLASS_SUBJECT")]
    public partial class StudentClassSubject
    {
        [Key]
        public int IdClassSubject { get; set; }
        [Key]
        public int IdStudent { get; set; }

        [ForeignKey(nameof(IdClassSubject))]
        [InverseProperty(nameof(ClassSubject.StudentClassSubjects))]
        public virtual ClassSubject IdClassSubjectNavigation { get; set; }
        [ForeignKey(nameof(IdStudent))]
        [InverseProperty(nameof(Student.StudentClassSubjects))]
        public virtual Student IdStudentNavigation { get; set; }
    }
}
