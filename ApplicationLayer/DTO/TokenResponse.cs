using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.DTO
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpiresAtUtc { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
