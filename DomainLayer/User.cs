using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
