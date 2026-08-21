using ApplicationLayer.DTO;
using DomainLayer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public class AuthenticateUserService :  IAuthenticateUserService 
    {
        private IUserRepository userRepository;
        private PasswordHasher<User> passwordHasher; 

        public AuthenticateUserService(IUserRepository userRepo )
        {
            userRepository = userRepo;
            passwordHasher = new PasswordHasher<User>();
        }


        public async Task<ResultResponse<User>> AuthenticateAsync(string username, string password)
        {
            ResultResponse<User>? user= await userRepository.GetUserNameAsync(username);
            if (user.IsSuccess == false)
            {
                return ResultResponse<User>.Fail("User Not Found"); 
            }
            var result = passwordHasher.VerifyHashedPassword(user.value,user.value.PasswordHash, password);
            if( result == PasswordVerificationResult.Success)
            {
                return  ResultResponse<User>.Success(user.value);
            }
            else
            {
                return ResultResponse<User>.Fail("InCorrect UserName or Password");
            }
        }





    }
}
