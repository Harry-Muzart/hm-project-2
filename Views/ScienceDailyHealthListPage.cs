using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Rss;
using NeuroCogFeeds;
using NeuroCogFeeds.Sections;
using NeuroCogFeeds.ViewModels;

namespace NeuroCogFeeds.Views
{
    public sealed partial class ScienceDailyHealthListPage : PageBase
    {
        public ListViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }

        public ScienceDailyHealthListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, RssSchema>(new ScienceDailyHealthConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
