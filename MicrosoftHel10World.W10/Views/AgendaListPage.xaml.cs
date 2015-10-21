//---------------------------------------------------------------------------
//
// <copyright file="AgendaListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>10/15/2015 12:44:52 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.Rss;
using MicrosoftHel10World.Sections;
using MicrosoftHel10World.ViewModels;
using MicrosoftHel10World.DataProviders.Hel10;

namespace MicrosoftHel10World.Views
{
    public sealed partial class AgendaListPage : Page
    {
        public AgendaListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, Hel10Schema>(new AgendaConfig());
            this.InitializeComponent();
        }

        public ListViewModel<RssDataConfig, Hel10Schema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
