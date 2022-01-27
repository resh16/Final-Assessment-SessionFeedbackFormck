using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SessionFeedbackDAL.Entities
{
    public partial class AppUserRole
    {
        [Key]
        public Guid UserId { get; set; }
        [Key]
        public Guid RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(AppRole.AppUserRoles))]
        public virtual AppRole Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AppUser.AppUserRoles))]
        public virtual AppUser User { get; set; }
    }
}
