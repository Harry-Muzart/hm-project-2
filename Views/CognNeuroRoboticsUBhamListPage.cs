using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Rss;
using NeuroCogFeeds;
using NeuroCogFeeds.Sections;
using NeuroCogFeeds.ViewModels;

namespace NeuroCogFeeds.Views
{
    public sealed partial class CognNeuroRoboticsUBhamListPage : PageBase
    {
        public ListViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }

        public CognNeuroRoboticsUBhamListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, RssSchema>(new CognNeuroRoboticsUBhamConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
