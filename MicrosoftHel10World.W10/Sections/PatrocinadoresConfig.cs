using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Menu;
using AppStudio.Uwp.Navigation;
using MicrosoftHel10World.Config;
using MicrosoftHel10World.ViewModels;

namespace MicrosoftHel10World.Sections
{
    public class PatrocinadoresConfig : SectionConfigBase<LocalStorageDataConfig, MenuSchema>
    {
        public override DataProviderBase<LocalStorageDataConfig, MenuSchema> DataProvider
        {
            get
            {
                return new LocalStorageDataProvider<MenuSchema>();
            }
        }

        public override LocalStorageDataConfig Config
        {
            get
            {
                return new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/Patrocinadores.json"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("PatrocinadoresListPage");
            }
        }

        public override ListPageConfig<MenuSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<MenuSchema>
                {
                    Title = "Patrocinadores",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title;
                        viewModel.Image = item.Icon;
                    },
                    NavigationInfo = (item) =>
                    {
                        return item.ToNavigationInfo();
                    }
                };
            }
        }

        public override DetailPageConfig<MenuSchema> DetailPage
        {
            get { return null; }
        }

        public override string PageTitle
        {
            get { return "Patrocinadores"; }
        }
    }
}
