//---------------------------------------------------------------------------
//
// <copyright file="ColaboradoresListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>10/15/2015 12:44:52 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Menu;
using MicrosoftHel10World.Sections;
using MicrosoftHel10World.ViewModels;

namespace MicrosoftHel10World.Views
{
    public sealed partial class ColaboradoresListPage : Page
    {
        public ColaboradoresListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new ColaboradoresConfig());
            this.InitializeComponent();
        }

        public ListViewModel<LocalStorageDataConfig, MenuSchema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
