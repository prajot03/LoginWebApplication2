using ApplicationLayer.DTO;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public interface IAuthenticateUserService
    {
        Task<ResultResponse<User>>AuthenticateAsync(string  username, string password);

    } 
}
