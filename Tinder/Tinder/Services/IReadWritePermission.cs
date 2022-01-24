using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Tinder.Services
{
    public interface IReadWritePermission
    {
        Task<PermissionStatus> CheckStatusAsync();
        Task<PermissionStatus> RequestAsync();
    }
}
