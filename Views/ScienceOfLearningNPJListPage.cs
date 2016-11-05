using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Rss;
using NeuroCogFeeds;
using NeuroCogFeeds.Sections;
using NeuroCogFeeds.ViewModels;

namespace NeuroCogFeeds.Views
{
    public sealed partial class ScienceOfLearningNPJListPage : PageBase
    {
        public ListViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }

        public ScienceOfLearningNPJListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, RssSchema>(new ScienceOfLearningNPJConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
