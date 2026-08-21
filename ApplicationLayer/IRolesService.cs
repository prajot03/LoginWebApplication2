
using ApplicationLayer.DTO;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public interface IRolesService
    {
         
        Task<Role>GetRoleByIdAsync(int roleId);
        Task<Role> GetRoleByName(RoleAddRequest role);
        Task<Role> AddRole(RoleAddRequest role);

        Task<IEnumerable<Role>> GetAllRoles();


    }
}
