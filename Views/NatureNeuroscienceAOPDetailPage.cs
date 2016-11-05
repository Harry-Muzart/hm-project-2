using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.Rss;
using NeuroCogFeeds;
using NeuroCogFeeds.Sections;
using NeuroCogFeeds.ViewModels;

namespace NeuroCogFeeds.Views

{
    public sealed partial class NatureNeuroscienceAOPDetailPage : PageBase
    {
        private DataTransferManager _dataTransferManager;
        public DetailViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }

        public NatureNeuroscienceAOPDetailPage()
        {
            this.ViewModel = new DetailViewModel<RssDataConfig, RssSchema>(new NatureNeuroscienceAOPConfig());
            this.InitializeComponent();            
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync(navParameter as ItemViewModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            bool supportsHtml = true;
#if WINDOWS_PHONE_APP
            supportsHtml = false;
#endif
            ViewModel.ShareContent(args.Request, supportsHtml);
        }
    }
}
