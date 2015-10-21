using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.DynamicStorage;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using Windows.Storage;
using MicrosoftHel10World.Config;
using MicrosoftHel10World.ViewModels;

namespace MicrosoftHel10World.Sections
{
    public class DeOctubreConfig : SectionConfigBase<DynamicStorageDataConfig, DeOctubre1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, DeOctubre1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<DeOctubre1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds-pre.winappstudio.net/api/data/collection?dataRowListId=922e9ac5-59af-40d1-861d-5d0a524a3f41&appId=9dcfe777-b057-4e64-8440-cca810901659"),
                    AppId = "9dcfe777-b057-4e64-8440-cca810901659",
                    StoreId = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.StoreId] as string,
                    DeviceType = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.DeviceType] as string
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("DeOctubreListPage");
            }
        }

        public override ListPageConfig<DeOctubre1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<DeOctubre1Schema>
                {
                    Title = "22 de Octubre",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Name.ToSafeString();
                        viewModel.SubTitle = item.Description.ToSafeString();
                        viewModel.Description = item.Description.ToSafeString();
                        viewModel.Image = item.Image.ToSafeString();
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("DeOctubreDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<DeOctubre1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, DeOctubre1Schema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "22 de Octubre";
                    viewModel.Title = item.Name.ToSafeString();
                    viewModel.Description = item.Description.ToSafeString();
                    viewModel.Image = item.Image.ToSafeString();
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<DeOctubre1Schema>>
                {
                };

                return new DetailPageConfig<DeOctubre1Schema>
                {
                    Title = "22 de Octubre",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "22 de Octubre"; }
        }
    }
}
