using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TAI.Models
{
    public class messageModel
    {
        [Required(ErrorMessage = "Your name is required.")]
        [Display(Name = "Your Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Your email address is required.")]
        [EmailAddress(ErrorMessage = "Your email must be valid.")]
        [Display(Name = "Your Email Address")]
        public string email { get; set; }
        [Required(ErrorMessage = "A message is required.")]
        [Display(Name = "Your Message")]
        public string messageContent { get; set; }

    }
}