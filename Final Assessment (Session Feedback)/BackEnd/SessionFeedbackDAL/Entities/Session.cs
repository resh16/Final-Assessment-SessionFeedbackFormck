using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SessionFeedbackDAL.Entities
{
    public partial class Session
    {
        public Session()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SessionDateTimeStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SessionDateTimeEnd { get; set; }
        public Guid? Presenter { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedBy { get; set; }
        public int? Duration { get; set; }

        [ForeignKey(nameof(Presenter))]
        [InverseProperty(nameof(AppUser.Sessions))]
        public virtual AppUser PresenterNavigation { get; set; }
        [InverseProperty(nameof(Feedback.Session))]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
