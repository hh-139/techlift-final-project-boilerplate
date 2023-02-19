using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLift.FinalProject.Roles
{
    public interface IRoleService
    {
        Task<List<IdentityRole>> GetRoles();
        Task<IdentityRole> GetRoleById(string id);
    }
}
