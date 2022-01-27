using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SessionFeedbackDAL.Entities
{
    public partial class Feedback
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public int SessionId { get; set; }
        [Required]
        [StringLength(500)]
        public string GoodFeedback { get; set; }
        [Required]
        [StringLength(500)]
        public string BadFeedback { get; set; }
        public int Rating { get; set; }
        [Required]
        [StringLength(300)]
        public string Image { get; set; }
        [Required]
        [StringLength(500)]
        public string UniqueImageName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }

        [ForeignKey(nameof(SessionId))]
        [InverseProperty("Feedbacks")]
        public virtual Session Session { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AppUser.Feedbacks))]
        public virtual AppUser User { get; set; }
    }
}
