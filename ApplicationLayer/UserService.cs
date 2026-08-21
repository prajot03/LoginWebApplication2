using ApplicationLayer.DTO;
using DomainLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRolesService _rolesService;
        public UserService(IUserRepository u,IRolesService roles)
        {
            _userRepository = u;
            _rolesService = roles; 
        }
       

        public async Task<ResultResponse<User>> RegisterAsync(UserRegisterDTO userRegister)
        {
            if (userRegister is null)
                return ResultResponse<User>.Fail("InComplete User Information"); 

            if (string.IsNullOrWhiteSpace(userRegister.UserName) ||string.IsNullOrWhiteSpace(userRegister.Password))
            {
                return ResultResponse<User>.Fail("InComplete User Information");
            }
            

            userRegister.Roles = (userRegister.Roles ?? new List<string>())
        .Where(r => !string.IsNullOrWhiteSpace(r))
        .Select(r => r.Trim())
        .ToList();

            var allRoles= await _rolesService.GetAllRoles();
            var roles=allRoles.Select(x=>x.RoleType).ToHashSet(StringComparer.OrdinalIgnoreCase);
            bool IsValid = userRegister.Roles.ToList().All(x => roles.Contains(x));

            if (!IsValid) {
                return ResultResponse<User>.Fail("In Valid Roles");
            }

             var user = new User
            {
                UserName = userRegister.UserName
            };

           user.PasswordHash = new PasswordHasher<User>().HashPassword(user, userRegister.Password);
            if (userRegister.Roles != null)
            {
                foreach (var roleType in userRegister.Roles)
                {
                    var role = allRoles.First(x =>
             string.Equals(
                 x.RoleType,
                 roleType,
                 StringComparison.OrdinalIgnoreCase));

                    user.Roles.Add(role);

                }
            }

    
            await _userRepository.AddAsync(user);
            
            await _userRepository.SaveChangesAsync();
            return ResultResponse<User>.Success(user);
        }
    }
}
