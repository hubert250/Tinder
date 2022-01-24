using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Tinder.Models;
using Xamarin.Forms;

namespace Tinder.ViewModels
{
    public class SwiperPageViewModel : ViewModelBase
    {
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        private bool _noMoreUsers;
        public bool NoMoreUsers
        {
            get { return _noMoreUsers; }
            set { SetProperty(ref _noMoreUsers, value); }
        }


        public SwiperPageViewModel()
        {
            Device.BeginInvokeOnMainThread(async () => await GetUsers());
        }

        private async Task GetUsers()
        {
            var users = await NetworkManager.GetUsers();
            AddUsersToList(users);
        }

        private void AddUsersToList(IEnumerable<User> users)
        {
            foreach (var user in users)
                Users.Add(user);
        }

        public void UserSwipped(User user)
        {
            if (Users.IndexOf(user) >= Users.Count - 2)
            {
                Device.BeginInvokeOnMainThread(async () => await GetUsers());
            }
        }

        public bool IsLastUser(User user)
        {
            var isLast = Users.Last() == user;

            if (isLast)
                NoMoreUsers = true;

            return isLast;
        }
    }
}
