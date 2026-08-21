using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.DTO
{
    public class RoleAddRequest
    {
        private string _roleType { get; set; }       
       
        public string RoleName
        {
            get => _roleType;
            set => _roleType = value?.Trim().ToUpperInvariant();
        }
    }
}
