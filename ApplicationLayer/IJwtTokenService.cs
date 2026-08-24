using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
