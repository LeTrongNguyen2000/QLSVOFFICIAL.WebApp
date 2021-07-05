using QLSVOFFICIAL.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSVOFFICIAL.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);
    }
}
