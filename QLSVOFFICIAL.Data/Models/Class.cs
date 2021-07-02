using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("CLASS")]
    [Index(nameof(ClassName), Name = "unique_ClassName", IsUnique = true)]
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public int IdClass { get; set; }
        [Required]
        [StringLength(7)]
        public string ClassName { get; set; }
        public int IdFaculty { get; set; }

        [ForeignKey(nameof(IdFaculty))]
        [InverseProperty(nameof(Faculty.Classes))]
        public virtual Faculty IdFacultyNavigation { get; set; }
        [InverseProperty(nameof(Student.IdClassNavigation))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
