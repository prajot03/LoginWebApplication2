using ApplicationLayer.DTO;
using DomainLayer;
using InfrastratureLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ApplicationLayer
{
    public class RoleService(AppDbContext appDbContext) : IRolesService
    {
        
        public async Task<Role> AddRole(RoleAddRequest role)
        {
          
           Role? Existing= await appDbContext.Roles.FirstOrDefaultAsync(x => x.RoleType == role.RoleName);
            if (Existing == null)
            {
                Role rr = new Role(){ RoleType = role.RoleName };
                 await appDbContext.AddAsync(rr);
                await appDbContext.SaveChangesAsync() ;
                return rr;
            }
            else
            {
                return null;
            }
           
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            var s =await appDbContext.Roles.Select(x => x).ToListAsync();
            return s;
        }

        public Task<Role> GetRoleByIdAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> GetRoleByName(RoleAddRequest role)
        {            
            Role? Existing = await appDbContext.Roles.FirstOrDefaultAsync(x => x.RoleType == role.RoleName);

            return Existing;


        }
    }
}
