using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIdentity.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        

    }
}
