using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QLSVOFFICIAL.Data.Models
{
    [Table("AppRole")]
    [Index(nameof(RoleName), Name = "unique_RoleName", IsUnique = true)]
    public partial class AppRole : IdentityRole<Guid> //Khóa chính duy nhất cho toàn hệ thống
    {
        public AppRole()
        {
            Users = new HashSet<AppUser>();
        }

        [Key]
        public int IdRole { get; set; }
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [InverseProperty(nameof(AppUser.IdRoleNavigation))]
        public virtual ICollection<AppUser> Users { get; set; }
    }
}
