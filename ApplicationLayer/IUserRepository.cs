using ApplicationLayer.DTO;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public interface IUserRepository
    {
       
        Task<ResultResponse<User>> GetUserByIdAsync(int id);
        Task<ResultResponse<User>> GetUserNameAsync(string username);
        Task<ResultResponse<User>> AddAsync(User user);
         Task SaveChangesAsync();


    }
}
