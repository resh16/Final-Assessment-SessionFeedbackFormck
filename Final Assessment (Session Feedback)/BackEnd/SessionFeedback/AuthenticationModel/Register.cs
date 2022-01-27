﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SessionFeedback.AuthenticationModel
{
    public class Register
    {
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

       
        [Required(ErrorMessage = "Age Required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Conform Password")]
        [Compare("Password")]
        public string Conform_Pwd { get; set; }

    }
}
