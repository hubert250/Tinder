using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tinder.Models;
using Xamarin.Forms;

namespace Tinder.ViewModels
{
    public class UserSettingsViewModel : ViewModelBase
    {
        private LocalUser _localUser;
        private bool _isNewUser;

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                SetProperty(ref _firstName, value);
                CheckIfCanSave();
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                SetProperty(ref _lastName, value);
                CheckIfCanSave();
            }
        }

        private string _aboutMe;
        public string AboutMe
        {
            get { return _aboutMe; }
            set { SetProperty(ref _aboutMe, value); }
        }

        private bool _canSave;
        public bool CanSave
        {
            get { return _canSave; }
            set { SetProperty(ref _canSave, value); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set 
            { 
                SetProperty(ref email, value);
                CheckIfCanSave();
            }
        }


        private DelegateCommand _saveUserInfoCommand;
        public DelegateCommand SaveUserInfoCommand =>
            _saveUserInfoCommand ?? (_saveUserInfoCommand = new DelegateCommand(ExecuteSaveUserInfoCommand));

        void ExecuteSaveUserInfoCommand()
        {
            if (!UserManager.IsDbSetup())
                return;

            PrepareUserInfo();

            if (_isNewUser)
            {
                UserManager.CreateUser(_localUser);
                _isNewUser = false;
            }
            else
                UserManager.UpdateUserInfo(_localUser);

            CanSave = false;
        }


        public UserSettingsViewModel()
        {
            Device.BeginInvokeOnMainThread(async ()=> await GetLocalUserInfo());
        }


        private void CheckIfCanSave()
        {
            if (string.IsNullOrWhiteSpace(FirstName)
                || string.IsNullOrWhiteSpace(LastName)
                || string.IsNullOrWhiteSpace(Email))
                CanSave = false;
            else
                CanSave = true;
        }

        private void PrepareUserInfo()
        {
            _localUser.FirstName = FirstName;
            _localUser.LastName = LastName;
            _localUser.AboutMe = AboutMe;
            _localUser.Email = Email;
        }

        private async Task GetLocalUserInfo()
        {
            if (await SetupDb() == false)
                return;

            _localUser = await UserManager.GetLocalUserInfo();

            if (_localUser == null)
                CreateNewUser();
            else
                SetupUserInfo();
        }

        private async Task<bool> SetupDb()
        {
            var isDbSetup = await UserManager.SetupDb();

            if (!isDbSetup)
                await PageDialogService.DisplayAlertAsync("Brak uprawnień", "Dodaj uprawnienia w ustawniach aplikacji", "OK");

            return isDbSetup;
        }

        private void CreateNewUser()
        {
            _isNewUser = true;
            _localUser = new LocalUser();
        }

        private void SetupUserInfo()
        {
            _isNewUser = false;

            FirstName = _localUser.FirstName;
            LastName = _localUser.LastName;
            Email = _localUser.Email;
            AboutMe = _localUser.AboutMe;
        }

    }
}
