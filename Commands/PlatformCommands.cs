using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AppStudio.Common;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
#if WINDOWS_APP
using NeuroCogFeeds.AppFlyouts;
#endif
using NeuroCogFeeds.ViewModels;

namespace NeuroCogFeeds.Commands
{
    public class PlatformCommands
    {

        public static ICommand Privacy
        {
            get
            {
                return new RelayCommand(() =>
                {
#if WINDOWS_APP
                    var flyout = new PrivacyFlyout();
                    flyout.Show();
#endif
#if WINDOWS_PHONE_APP
                    PrivacyViewModel vm = new PrivacyViewModel();
                    NavigationService.NavigateTo(vm.Url).RunAndForget();
#endif

                });
            }
        }
    }
}
