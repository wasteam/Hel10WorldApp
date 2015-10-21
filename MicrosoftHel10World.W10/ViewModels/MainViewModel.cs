using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using AppStudio.DataProviders;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using AppStudio.DataProviders.Rss;
using AppStudio.DataProviders.Twitter;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.Menu;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.DynamicStorage;
using MicrosoftHel10World.Sections;
using MicrosoftHel10World.DataProviders.Hel10;

namespace MicrosoftHel10World.ViewModels
{
    public class MainViewModel : PageViewModel
    {
        public MainViewModel(int visibleItems) : base()
        {
            PageTitle = "Microsoft Hel10 World";
            DeOctubre = new ListViewModel<DynamicStorageDataConfig, DeOctubre1Schema>(new DeOctubreConfig(), visibleItems);
            Agenda = new ListViewModel<RssDataConfig, Hel10Schema>(new AgendaConfig(), visibleItems);
            Twitter = new ListViewModel<TwitterDataConfig, TwitterSchema>(new TwitterConfig(), visibleItems);
            YSiVienesEnTren = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new YSiVienesEnTrenConfig(), visibleItems);
            Patrocinadores = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new PatrocinadoresConfig());
            Colaboradores = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new ColaboradoresConfig());
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
        public ListViewModel<DynamicStorageDataConfig, DeOctubre1Schema> DeOctubre { get; private set; }
        public ListViewModel<RssDataConfig, Hel10Schema> Agenda { get; private set; }
        public ListViewModel<TwitterDataConfig, TwitterSchema> Twitter { get; private set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> YSiVienesEnTren { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> Patrocinadores { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> Colaboradores { get; private set; }

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

		public override void UpdateCommonProperties(SplitViewDisplayMode splitViewDisplayMode)
        {
            base.UpdateCommonProperties(splitViewDisplayMode);
            if (splitViewDisplayMode == SplitViewDisplayMode.Overlay)
            {
                AppBarRow = 3;
                AppBarColumn = 0;
                AppBarColumnSpan = 2;
            }
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
            yield return DeOctubre;
            yield return Agenda;
            yield return Twitter;
            yield return YSiVienesEnTren;
            yield return Patrocinadores;
            yield return Colaboradores;
        }
    }
}
