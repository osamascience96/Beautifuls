using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beautifuls.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string ProfileUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }
}