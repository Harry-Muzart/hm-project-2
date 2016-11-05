using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Rss;
using NeuroCogFeeds;
using NeuroCogFeeds.Sections;
using NeuroCogFeeds.ViewModels;

namespace NeuroCogFeeds.Views
{
    public sealed partial class ComputationalNeurosciListPage : PageBase
    {
        public ListViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }

        public ComputationalNeurosciListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, RssSchema>(new ComputationalNeurosciConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
