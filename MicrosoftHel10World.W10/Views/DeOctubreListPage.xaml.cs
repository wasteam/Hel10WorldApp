//---------------------------------------------------------------------------
//
// <copyright file="DeOctubreListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>10/15/2015 12:44:52 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.DynamicStorage;
using MicrosoftHel10World.Sections;
using MicrosoftHel10World.ViewModels;

namespace MicrosoftHel10World.Views
{
    public sealed partial class DeOctubreListPage : Page
    {
        public DeOctubreListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, DeOctubre1Schema>(new DeOctubreConfig());
            this.InitializeComponent();
        }

        public ListViewModel<DynamicStorageDataConfig, DeOctubre1Schema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
