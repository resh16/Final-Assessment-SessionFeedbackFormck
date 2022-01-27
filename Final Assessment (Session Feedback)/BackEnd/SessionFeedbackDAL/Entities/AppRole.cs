using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SessionFeedbackDAL.Entities
{
    public partial class AppRole
    {
        public AppRole()
        {
            AppRoleClaims = new HashSet<AppRoleClaim>();
            AppUserRoles = new HashSet<AppUserRole>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        [InverseProperty(nameof(AppRoleClaim.Role))]
        public virtual ICollection<AppRoleClaim> AppRoleClaims { get; set; }
        [InverseProperty(nameof(AppUserRole.Role))]
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
