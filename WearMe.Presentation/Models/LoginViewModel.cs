﻿using System.ComponentModel.DataAnnotations;

namespace WearMe.Presentation.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; internal set; }
    }
}
