using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("AppUser")]
    [Index(nameof(UserName), Name = "unique_UserName", IsUnique = true)]
    public partial class AppUser : IdentityUser<Guid> //Khóa chính duy nhất cho toàn hệ thống
    {
        public AppUser()
        {
            Checkins = new HashSet<Checkin>();
            StudentCheckins = new HashSet<StudentCheckin>();
            Students = new HashSet<Student>();
        }

        [Key]
        public int IdUser { get; set; }
        [Required]
        [StringLength(10)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }
        public bool? IsLocked { get; set; }
        public int IdRole { get; set; }
        public int IdFaculty { get; set; }

        [ForeignKey(nameof(IdFaculty))]
        [InverseProperty(nameof(Faculty.Users))]
        public virtual Faculty IdFacultyNavigation { get; set; }
        [ForeignKey(nameof(IdRole))]
        [InverseProperty(nameof(AppRole.Users))]
        public virtual AppRole IdRoleNavigation { get; set; }
        [InverseProperty(nameof(Checkin.IdUserNavigation))]
        public virtual ICollection<Checkin> Checkins { get; set; }
        [InverseProperty(nameof(StudentCheckin.IdUserNavigation))]
        public virtual ICollection<StudentCheckin> StudentCheckins { get; set; }
        [InverseProperty(nameof(Student.IdUserNavigation))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
