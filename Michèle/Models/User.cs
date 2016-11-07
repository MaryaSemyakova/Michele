using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Michèle.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }

        public Guid? RoleId { get; set; }
        public Role Role { get; set; }
    }
}