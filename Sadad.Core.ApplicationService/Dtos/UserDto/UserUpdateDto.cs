using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sadad.Core.ApplicationService.Dtos.UserDto
{
   public class UserUpdateDto
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Please Enter Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Display(Name = "BirthDate")]
        [Required(ErrorMessage = "Please Enter BirthDate")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Enter Gender")]
        public string Gender { get; set; }

        [Display(Name = "EmailAddress")]
        [Required(ErrorMessage = "Please Enter EmailAddress")]
        [EmailAddress(ErrorMessage = "The email format is wrong")]
        public string EmailAddress { get; set; }
    }
}
