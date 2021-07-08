using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("STUDENT")]
    public partial class Student
    {
        public Student()
        {
            AbsenceForms = new HashSet<AbsenceForm>();
            StudentCheckins = new HashSet<StudentCheckin>();
            StudentClassSubjects = new HashSet<StudentClassSubject>();
        }

        [Key]
        public int IdStudent { get; set; }
        [Required]
        [StringLength(10)]
        public string StudentCode { get; set; }
        public int IdClass { get; set; }
        public int IdUser { get; set; }

        [ForeignKey(nameof(IdClass))]
        [InverseProperty(nameof(Class.Students))]
        public virtual Class IdClassNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(AppUser.Students))]
        public virtual AppUser IdUserNavigation { get; set; }
        [InverseProperty(nameof(AbsenceForm.IdStudentNavigation))]
        public virtual ICollection<AbsenceForm> AbsenceForms { get; set; }
        [InverseProperty(nameof(StudentCheckin.IdStudentNavigation))]
        public virtual ICollection<StudentCheckin> StudentCheckins { get; set; }
        [InverseProperty(nameof(StudentClassSubject.IdStudentNavigation))]
        public virtual ICollection<StudentClassSubject> StudentClassSubjects { get; set; }
    }
}
