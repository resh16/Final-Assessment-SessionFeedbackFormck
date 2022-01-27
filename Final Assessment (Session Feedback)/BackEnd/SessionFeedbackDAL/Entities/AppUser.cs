using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SessionFeedbackDAL.Entities
{
    public partial class AppUser
    {
        public AppUser()
        {
            AppUserClaims = new HashSet<AppUserClaim>();
            AppUserLogins = new HashSet<AppUserLogin>();
            AppUserRoles = new HashSet<AppUserRole>();
            AppUserTokens = new HashSet<AppUserToken>();
            Feedbacks = new HashSet<Feedback>();
            Sessions = new HashSet<Session>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(256)]
        public string UserName { get; set; }
        [StringLength(256)]
        public string NormalizedUserName { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        [StringLength(256)]
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        public int AccessFailedCount { get; set; }

        [InverseProperty(nameof(AppUserClaim.User))]
        public virtual ICollection<AppUserClaim> AppUserClaims { get; set; }
        [InverseProperty(nameof(AppUserLogin.User))]
        public virtual ICollection<AppUserLogin> AppUserLogins { get; set; }
        [InverseProperty(nameof(AppUserRole.User))]
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
        [InverseProperty(nameof(AppUserToken.User))]
        public virtual ICollection<AppUserToken> AppUserTokens { get; set; }
        [InverseProperty(nameof(Feedback.User))]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        [InverseProperty(nameof(Session.PresenterNavigation))]
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
