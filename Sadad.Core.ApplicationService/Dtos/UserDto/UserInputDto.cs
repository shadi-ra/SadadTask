using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sadad.Core.ApplicationService.Dtos.UserDto
{
   public class UserInputDto
    {
        [Display(Name = "FullName")]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }

        [Display(Name = "EmailAddress")]
        [Required(ErrorMessage = "Please Enter EmailAddress")]
        [EmailAddress(ErrorMessage = "The email format is wrong")]
        public string EmailAddress { get; set; }
    }
}
