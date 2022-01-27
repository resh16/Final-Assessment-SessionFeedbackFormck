using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionFeedbackBL.ViewModelBL
{
   public class FeedbackVMBL
    {
        
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
       
        public IFormFile Image { get; set; }
        
       
    }
}
