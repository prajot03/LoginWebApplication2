using ApplicationLayer.DTO;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public interface IUserService
    {
        Task<ResultResponse<User>> RegisterAsync(UserRegisterDTO userRegister);
    }
}
