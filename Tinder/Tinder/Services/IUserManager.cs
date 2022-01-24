using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tinder.Models;

namespace Tinder.Services
{
    public interface IUserManager
    {
        Task<LocalUser> GetLocalUserInfo();
        Task CreateUser(LocalUser user);
        Task UpdateUserInfo(LocalUser user);
        bool IsDbSetup();
        Task<bool> SetupDb();
    }
}
