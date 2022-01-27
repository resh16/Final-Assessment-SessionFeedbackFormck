﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SessionFeedback.AuthenticationModel
{
    public class Login
    {
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }



        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

    }
}
