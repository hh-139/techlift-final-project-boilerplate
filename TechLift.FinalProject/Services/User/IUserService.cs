using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLift.FinalProject.User
{
    public interface IUserService
    {
        string GetUserId();
        bool ISAuthenticated();
    }
}
