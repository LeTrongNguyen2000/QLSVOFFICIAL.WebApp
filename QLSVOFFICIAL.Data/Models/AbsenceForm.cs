using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("ABSENCE_FORM")]
    public partial class AbsenceForm
    {
        [Key]
        public int IdAbsenceForm { get; set; }
        public int IdClassSubject { get; set; }
        public int IdStudent { get; set; }

        [ForeignKey(nameof(IdClassSubject))]
        [InverseProperty(nameof(ClassSubject.AbsenceForms))]
        public virtual ClassSubject IdClassSubjectNavigation { get; set; }
        [ForeignKey(nameof(IdStudent))]
        [InverseProperty(nameof(Student.AbsenceForms))]
        public virtual Student IdStudentNavigation { get; set; }
    }
}
