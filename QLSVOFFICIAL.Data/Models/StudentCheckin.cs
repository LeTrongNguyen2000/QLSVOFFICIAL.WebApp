using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("STUDENT_CHECKIN")]
    public partial class StudentCheckin
    {
        [Key]
        public int IdCheckin { get; set; }
        [Key]
        public int IdStudent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CheckIn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CheckOut { get; set; }
        public int IdUser { get; set; }

        [ForeignKey(nameof(IdCheckin))]
        [InverseProperty(nameof(Checkin.StudentCheckins))]
        public virtual Checkin IdChekinNavigation { get; set; }
        [ForeignKey(nameof(IdStudent))]
        [InverseProperty(nameof(Student.StudentCheckins))]
        public virtual Student IdStudentNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.StudentCheckins))]
        public virtual User IdUserNavigation { get; set; }
    }
}
