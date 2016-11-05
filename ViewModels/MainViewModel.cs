using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.Rss;
using AppStudio.DataProviders.LocalStorage;
using NeuroCogFeeds.Sections;


namespace NeuroCogFeeds.ViewModels
{
    public class MainViewModel : ObservableBase
    {
        public MainViewModel(int visibleItems)
        {
            PageTitle = "NeuroCogFeeds";
            Welcome = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new WelcomeConfig(), visibleItems);
            NatureNeuroscienceCurrent = new ListViewModel<RssDataConfig, RssSchema>(new NatureNeuroscienceCurrentConfig(), visibleItems);
            NatureNeuroscienceAOP = new ListViewModel<RssDataConfig, RssSchema>(new NatureNeuroscienceAOPConfig(), visibleItems);
            CognNeuroRoboticsUBham = new ListViewModel<RssDataConfig, RssSchema>(new CognNeuroRoboticsUBhamConfig(), visibleItems);
            NobelPrize = new ListViewModel<RssDataConfig, RssSchema>(new NobelPrizeConfig(), visibleItems);
            NatureReviewsNeuroscience = new ListViewModel<RssDataConfig, RssSchema>(new NatureReviewsNeuroscienceConfig(), visibleItems);
            ComputationalNeurosci = new ListViewModel<RssDataConfig, RssSchema>(new ComputationalNeurosciConfig(), visibleItems);
            ScienceDailyHealth = new ListViewModel<RssDataConfig, RssSchema>(new ScienceDailyHealthConfig(), visibleItems);
            ScientificAmerican = new ListViewModel<RssDataConfig, RssSchema>(new ScientificAmericanConfig(), visibleItems);
            ScienceOfLearningNPJ = new ListViewModel<RssDataConfig, RssSchema>(new ScienceOfLearningNPJConfig(), visibleItems);
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

        public string PageTitle { get; set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> Welcome { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> NatureNeuroscienceCurrent { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> NatureNeuroscienceAOP { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> CognNeuroRoboticsUBham { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> NobelPrize { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> NatureReviewsNeuroscience { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> ComputationalNeurosci { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> ScienceDailyHealth { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> ScientificAmerican { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> ScienceOfLearningNPJ { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault();
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return Welcome;
            yield return NatureNeuroscienceCurrent;
            yield return NatureNeuroscienceAOP;
            yield return CognNeuroRoboticsUBham;
            yield return NobelPrize;
            yield return NatureReviewsNeuroscience;
            yield return ComputationalNeurosci;
            yield return ScienceDailyHealth;
            yield return ScientificAmerican;
            yield return ScienceOfLearningNPJ;
        }
    }
}
