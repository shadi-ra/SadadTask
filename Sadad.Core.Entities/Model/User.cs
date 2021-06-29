using System;
using System.Collections.Generic;
using System.Text;

namespace Sadad.Core.Entities.Model
{
    public class User : IHasIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
    }
}
