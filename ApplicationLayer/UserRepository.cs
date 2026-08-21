using ApplicationLayer.DTO;
using DomainLayer;
using InfrastratureLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext dbContext;
        public UserRepository(AppDbContext db)
        {
            dbContext = db; 
        }

        public async Task<ResultResponse<User>> AddAsync(User user)
        {
           ResultResponse<User> existing=await GetUserNameAsync(user.UserName);
            
            
            
            if (existing.IsSuccess)
            {
                return ResultResponse<User>.Fail("UserName Already Exists");

              
            }
            else
            {
                await dbContext.Users.AddAsync(user);
                return ResultResponse<User>.Success(user);
            }
        }

        public async Task<ResultResponse<User>> GetUserByIdAsync(int id)
        {
            User? s =await dbContext.Users.Where(x => x.Id == id)
                .Include(u=>u.Roles)
                .FirstOrDefaultAsync();

            return s == null
                 ? ResultResponse<User>.Fail("User Not Found")
                 :ResultResponse<User>.Success(s);
                
            
        }

        public async Task<ResultResponse<User>> GetUserNameAsync(string username)
        {
            User? s =await dbContext.Users.Where(x => x.UserName == username)
                .FirstOrDefaultAsync();
            if(s != null)
            return ResultResponse<User>.Success(s);
            else
              return ResultResponse<User>.Fail("User Not Found");
        }

        public Task<ResultResponse<User>> RegisterAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
           await dbContext.SaveChangesAsync();
            
        }
    }
}
