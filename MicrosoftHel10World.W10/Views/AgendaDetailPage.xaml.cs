//---------------------------------------------------------------------------
//
// <copyright file="AgendaDetailPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>10/15/2015 12:44:52 PM</createdOn>
//
//---------------------------------------------------------------------------

using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.Rss;
using MicrosoftHel10World.Sections;
using MicrosoftHel10World.Services;
using MicrosoftHel10World.ViewModels;
using MicrosoftHel10World.DataProviders.Hel10;

namespace MicrosoftHel10World.Views
{
    public sealed partial class AgendaDetailPage : Page
    {
        private DataTransferManager _dataTransferManager;

        public AgendaDetailPage()
        {
            this.ViewModel = new DetailViewModel<RssDataConfig, Hel10Schema>(new AgendaConfig());

            this.InitializeComponent();
        }

        public DetailViewModel<RssDataConfig, Hel10Schema> ViewModel { get; set; }        

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync(e.Parameter as ItemViewModel);

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
            ViewModel.ShareContent(args.Request);
        }

        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            AppBarButton button = sender as AppBarButton;
            int newFontSize = Int32.Parse(button.Tag.ToString());
            mainPanel.BodyFontSize = newFontSize;
            mainPanel.UpdateFontSize();
        }
    }
}
