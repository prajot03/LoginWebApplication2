using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.DTO
{
    public class ValidateUserLoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
