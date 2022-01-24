using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tinder.Services;
using Xamarin.Essentials;

namespace Tinder.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        private IContainerProvider Container => ((App)Xamarin.Forms.Application.Current).Container;
        protected INavigationService NavigationService { get; private set; }
        protected IReqresManager NetworkManager { get; private set; }
        protected IUserManager UserManager { get; private set; }
        protected IReadWritePermission ReadWritePermission { get; private set; }
        protected IPageDialogService PageDialogService { get; private set; }

        public ViewModelBase()
        {
            NavigationService = Container.Resolve<INavigationService>();
            NetworkManager = Container.Resolve<IReqresManager>();
            UserManager = Container.Resolve<IUserManager>();
            ReadWritePermission = Container.Resolve<IReadWritePermission>();
            PageDialogService = Container.Resolve<IPageDialogService>();
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
