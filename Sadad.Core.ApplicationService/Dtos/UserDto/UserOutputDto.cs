using System;
using System.Collections.Generic;
using System.Text;

namespace Sadad.Core.ApplicationService.Dtos.UserDto
{
   public class UserOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
    }
}
