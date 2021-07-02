using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("ROLE")]
    [Index(nameof(RoleName), Name = "unique_RoleName", IsUnique = true)]
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int IdRole { get; set; }
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [InverseProperty(nameof(User.IdRoleNavigation))]
        public virtual ICollection<User> Users { get; set; }
    }
}
