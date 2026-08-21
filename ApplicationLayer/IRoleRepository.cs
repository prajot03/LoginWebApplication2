using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public interface IRoleRepository
    {
        Task<Role?> GetByTypeAsync(RoleType type);
        Task AddAsync(Role role);
        Task SaveChangesAsync();
    }
}
