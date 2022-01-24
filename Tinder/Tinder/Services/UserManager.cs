using Prism.Ioc;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinder.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Tinder.Services
{
    public class UserManager : IUserManager
    {
        private IContainerProvider Container => ((App)Application.Current).Container;
        private SQLiteAsyncConnection _dbConnection;
        private IReadWritePermission _readWritePermission;
        private bool _isDbSetup = false;


        public UserManager()
        {
            _dbConnection = Container.Resolve<ISQLiteDb>().GetConnection();
            _readWritePermission = Container.Resolve<IReadWritePermission>();
        }

        protected async Task<bool> CheckPermissionStatus()
        {
            var status = await _readWritePermission.CheckStatusAsync();

            if (status != PermissionStatus.Granted)
                return false;

            return true;
        }

        public async Task<bool> SetupDb()
        {
            if (await CheckPermissionStatus())
            {
                await _readWritePermission.RequestAsync();

                if (await CheckPermissionStatus())
                {
                    await _dbConnection.CreateTableAsync<LocalUser>();
                    _isDbSetup = true;
                }
            }
            else
            {
                await _dbConnection.CreateTableAsync<LocalUser>();
                _isDbSetup = true;
            }

            return _isDbSetup;
        }

        

        public async Task<LocalUser> GetLocalUserInfo()
        {
            if (await CheckPermissionStatus() == false)
                return null;


            var userInfo = await _dbConnection.Table<LocalUser>().ToListAsync();
            if (userInfo.Count == 1)
                return userInfo.First();


            return null;
        }

        public async Task CreateUser(LocalUser user)
        {
            await _dbConnection.InsertAsync(user);
        }

        public async Task UpdateUserInfo(LocalUser user)
        {
            await _dbConnection.UpdateAsync(user);
        }

        public bool IsDbSetup()
        {
            return _isDbSetup;
        }
    }
}