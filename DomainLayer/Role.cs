using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomainLayer
{
    public class Role
    {
        
        public int Id { get; set; }
        public string RoleType { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; } = new List<User>();
          
    }
}
