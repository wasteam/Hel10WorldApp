using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Rss;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using MicrosoftHel10World.Config;
using MicrosoftHel10World.ViewModels;
using MicrosoftHel10World.DataProviders.Hel10;
using MicrosoftHel10World.Commands;

namespace MicrosoftHel10World.Sections
{
    public class AgendaConfig : SectionConfigBase<RssDataConfig, Hel10Schema>
    {
        public override DataProviderBase<RssDataConfig, Hel10Schema> DataProvider
        {
            get
            {
                return new Hel10DataProvider();
            }
        }

        public override RssDataConfig Config
        {
            get
            {
                return new RssDataConfig
                {
                    Url = new Uri("https://www.desarrollaconmicrosoft.com/Windows10Hel10World/Rss")
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("AgendaListPage");
            }
        }

        public override ListPageConfig<Hel10Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<Hel10Schema>
                {
                    Title = "Agenda",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Author.ToSafeString();
                        viewModel.Description = FormatDates(item);
                        viewModel.ExtendedProperty1 = item.Room.ToSafeString();
                        viewModel.ExtendedProperty2 = item.Level.ToSafeString();
                        viewModel.ExtendedProperty3 = item.Category.ToSafeString();
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("AgendaDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<Hel10Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, Hel10Schema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Category.ToSafeString();
                    viewModel.Title = item.Title.ToSafeString();
                    viewModel.Description = item.Summary.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<Hel10Schema>>
                {
                    AddToCalendar("Add to calendar", item => item)
                };

                return new DetailPageConfig<Hel10Schema>
                {
                    Title = "Agenda",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Agenda"; }
        }

        private static string FormatDates(Hel10Schema item)
        {
            return string.Format("De {0:HH:mm} a {1:HH:mm}", item.StartDateTime, item.EndDateTime);
        }

        private static ActionConfig<Hel10Schema> AddToCalendar(string text, Func<Hel10Schema, Hel10Schema> param)
        {
            return new ActionConfig<Hel10Schema>
            {
                Text = text,
                Style = "AppBarCalendar",
                Command = Hel10Commands.AddToCalendar,
                CommandParameter = param
            };
        }
    }
}
