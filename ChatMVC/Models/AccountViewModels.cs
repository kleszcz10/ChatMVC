﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatMVC.Models
{

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class UserModel : IdentityUser
    {
        public virtual ICollection<Message> Messages { get; set; }
    }

    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public DateTime SendTime { get; set; }
        public string MessageText { get; set; }

        [ForeignKey("SenderUser")]
        public string SenderUserId { get; set; }
        public ApplicationUser SenderUser { get; set; }

        [ForeignKey("ReceiverUser")]
        public string ReceiverUserId { get; set; }
        public ApplicationUser ReceiverUser { get; set; }
        [NotMapped]
        public TimeSpan TimeSinceSend
        {
            get
            {
                return DateTime.Now - SendTime;
            }
        }
    }


    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }


}
