using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionFeedbackBL.ViewModelBL
{
   public class SessionVMBL
    {

        public int RowNum { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        public DateTime SessionDateTimeStart { get; set; }
       
        public DateTime SessionDateTimeEnd { get; set; }
        public string Presenter { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime CreatedBy { get; set; }
        public int Duration { get; set; }
    }
}
