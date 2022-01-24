using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tinder.Models;

namespace Tinder.Services
{
    public interface IReqresManager
    {
        Task<List<User>> GetUsers();
    }
}
