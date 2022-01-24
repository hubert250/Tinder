using Prism;
using Prism.Ioc;
using Tinder.Services;
using Tinder.ViewModels;
using Tinder.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Tinder
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IReqresManager, ReqresManager>();
            containerRegistry.RegisterSingleton<IUserManager, UserManager>();


            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SwiperPage, SwiperPageViewModel>();
            containerRegistry.RegisterForNavigation<UserSettings, UserSettingsViewModel>();
        }
    }
}
