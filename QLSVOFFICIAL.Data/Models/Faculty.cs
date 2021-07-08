using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("FACULTY")]
    [Index(nameof(FacultyCode), Name = "unique_FacultyCode", IsUnique = true)]
    public partial class Faculty
    {
        public Faculty()
        {
            Classes = new HashSet<Class>();
            Subjects = new HashSet<Subject>();
            Users = new HashSet<AppUser>();
        }

        [Key]
        public int IdFaculty { get; set; }
        [Required]
        [StringLength(20)]
        public string FacultyCode { get; set; }
        [Required]
        [StringLength(50)]
        public string FacultyName { get; set; }

        [InverseProperty(nameof(Class.IdFacultyNavigation))]
        public virtual ICollection<Class> Classes { get; set; }
        [InverseProperty(nameof(Subject.IdFacultyNavigation))]
        public virtual ICollection<Subject> Subjects { get; set; }
        [InverseProperty(nameof(AppUser.IdFacultyNavigation))]
        public virtual ICollection<AppUser> Users { get; set; }
    }
}
