using AppStudio.Common;
using AppStudio.Common.Actions;
using Windows.UI.Xaml.Navigation;
using NeuroCogFeeds;
using NeuroCogFeeds.Commands;
using NeuroCogFeeds.ViewModels;

namespace NeuroCogFeeds
{
    public sealed partial class MainPage : PageBase
    {
        public MainViewModel ViewModel { get; set; }

        public MainPage()
        {
            int visibleItems = 0;
#if WINDOWS_APP
            visibleItems = 6;
#endif
            this.ViewModel = new MainViewModel(visibleItems);
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.InitializeComponent();

            ViewModel.Actions.Add(new ActionInfo
            {
                Name = "PrivacyButton",
                Style = ActionKnownStyles.Privacy,
                ActionType = ActionType.Secondary,
                Command = PlatformCommands.Privacy
            });
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }
    }
}

