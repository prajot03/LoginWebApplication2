using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.DTO
{
    public class UserRegisterDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Roles { get; set; }


    }
}
