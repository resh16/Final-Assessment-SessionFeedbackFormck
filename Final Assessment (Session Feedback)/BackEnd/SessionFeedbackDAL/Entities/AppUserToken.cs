using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SessionFeedbackDAL.Entities
{
    public partial class AppUserToken
    {
        [Key]
        public Guid UserId { get; set; }
        [Key]
        public string LoginProvider { get; set; }
        [Key]
        public string Name { get; set; }
        public string Value { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AppUser.AppUserTokens))]
        public virtual AppUser User { get; set; }
    }
}
