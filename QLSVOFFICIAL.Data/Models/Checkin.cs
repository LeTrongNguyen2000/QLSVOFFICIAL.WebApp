using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("CHECKIN")]
    public partial class Checkin
    {
        public Checkin()
        {
            StudentCheckins = new HashSet<StudentCheckin>();
        }

        [Key]
        public int IdCheckin { get; set; }
        public int IdClassSubject { get; set; }
        public int IdUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CheckinDate { get; set; }
        [Required]
        [StringLength(8)]
        public string CheckRoom { get; set; }

        [ForeignKey(nameof(IdClassSubject))]
        [InverseProperty(nameof(ClassSubject.Checkins))]
        public virtual ClassSubject IdClassSubjectNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(AppUser.Checkins))]
        public virtual AppUser IdUserNavigation { get; set; }
        [InverseProperty(nameof(StudentCheckin.IdChekinNavigation))]
        public virtual ICollection<StudentCheckin> StudentCheckins { get; set; }
    }
}
